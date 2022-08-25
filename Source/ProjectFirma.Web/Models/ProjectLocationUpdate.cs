﻿/*-----------------------------------------------------------------------
<copyright file="ProjectLocationUpdate.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.Models;
using Microsoft.SqlServer.Types;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectLocationUpdate : IAuditableEntity, IProjectLocation, IHaveSqlGeometry
    {
        public ProjectLocationUpdate(ProjectUpdateBatch projectUpdateBatch, DbGeometry projectLocationGeometry, string projectLocationNotes, ProjectLocationType projectLocationType, string projectLocationName, int? arcGisObjectID, string arcGisGlobalID) : this(projectUpdateBatch, projectLocationGeometry, projectLocationType, projectLocationName)
        {
            ProjectLocationUpdateNotes = projectLocationNotes;
            ArcGisObjectID = arcGisObjectID;
            ArcGisGlobalID = arcGisGlobalID;
        }

        public ProjectLocationUpdate(ProjectUpdateBatch projectUpdateBatch, int projectLocationID, DbGeometry projectLocationGeometry, string projectLocationNotes, ProjectLocationType projectLocationType, string projectLocationName, int? arcGisObjectID, string arcGisGlobalID) : this(projectUpdateBatch, projectLocationGeometry, projectLocationType, projectLocationName)
        {
            ProjectLocationID = projectLocationID;
            ProjectLocationUpdateNotes = projectLocationNotes;
            ArcGisObjectID = arcGisObjectID;
            ArcGisGlobalID = arcGisGlobalID;
        }

        public string AuditDescriptionString
        {
            get
            {
                return "Shape deleted";
            }
        }

        public DbGeometry ProjectLocationGeometry
        {
            get { return ProjectLocationUpdateGeometry; }
            set { ProjectLocationUpdateGeometry = value; }
        }

        public string ProjectLocationNotes
        {
            get { return ProjectLocationUpdateNotes; }
            set { ProjectLocationUpdateNotes = value; }
        }

        public DbGeometry DbGeometry
        {
            get { return ProjectLocationUpdateGeometry; }
            set { ProjectLocationUpdateGeometry = value; }
        }

        public SqlGeometry SqlGeometry
        {
            get { return ProjectLocationUpdateGeometry.ToSqlGeometry(); }
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectLocationUpdates = project.ProjectLocations.Select(
                                                                      projectLocationToClone => new ProjectLocationUpdate(projectUpdateBatch,
                                                                                                    projectLocationToClone.ProjectLocationID,
                                                                                                    projectLocationToClone.ProjectLocationGeometry, 
                                                                                                    projectLocationToClone.ProjectLocationNotes, 
                                                                                                    projectLocationToClone.ProjectLocationType, 
                                                                                                    projectLocationToClone.ProjectLocationName, 
                                                                                                    projectLocationToClone.ArcGisObjectID, 
                                                                                                    projectLocationToClone.ArcGisGlobalID)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectLocation> allProjectLocations)
        {
            var project = projectUpdateBatch.Project;
            var projectLocationsFromProjectUpdate = projectUpdateBatch.ProjectLocationUpdates.Select(
                plu => new ProjectLocation(project, (plu.ProjectLocationID ?? ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue()), plu.ProjectLocationUpdateName, plu.ProjectLocationUpdateGeometry, plu.ProjectLocationTypeID, plu.ProjectLocationUpdateNotes)
            ).ToList();
            project.ProjectLocations.Merge(
                projectLocationsFromProjectUpdate,
                allProjectLocations,
                (x, y) => x.ProjectID == y.ProjectID && x.ProjectLocationID == y.ProjectLocationID,
                (x, y) =>
                {
                    x.ProjectLocationName = y.ProjectLocationName;
                    x.ProjectLocationGeometry = y.ProjectLocationGeometry;
                    x.ProjectLocationTypeID = y.ProjectLocationTypeID;
                    x.ProjectLocationNotes = y.ProjectLocationNotes;
                }
            );
        }
    }
}
