﻿/*-----------------------------------------------------------------------
<copyright file="LocationDetailedViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Common;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class LocationDetailedViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly SectionCommentsViewData SectionCommentsViewData;

        public readonly ProjectLocationDetailViewData ProjectLocationDetailViewData;
        public readonly string UploadGisFileUrl;
        public readonly bool CanRevert;

        public LocationDetailedViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ProjectLocationDetailViewData projectLocationDetailViewData, string uploadGisFileUrl, UpdateStatus updateStatus)
            : base(currentPerson, projectUpdateBatch, updateStatus, new List<string>(), ProjectUpdateSection.LocationDetailed.ProjectUpdateSectionDisplayName)
        {
            ProjectLocationDetailViewData = projectLocationDetailViewData;
            UploadGisFileUrl = uploadGisFileUrl;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshProjectLocationDetailed(projectUpdateBatch.Project));
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.LocationDetailedComment, projectUpdateBatch.IsReturned);
            CanRevert = CanRevertLocationDetailed(projectUpdateBatch);
        }

        private bool CanRevertLocationDetailed(ProjectUpdateBatch projectUpdateBatch)
        {
            var projectLocations = projectUpdateBatch.Project.ProjectLocations.ToList();
            var projectLocationUpdates = projectUpdateBatch.ProjectLocationUpdates.ToList();
            var isValid = true;

            var newProjectLocationUpdates = projectLocationUpdates.Where(x => !x.ProjectLocationID.HasValue).ToList();  // These ProjectLocationUpdates are new
            var exisitingProjectLocationUpdates = projectLocationUpdates.Where(x => x.ProjectLocationID.HasValue).ToList();  // These ProjectLocationUpdates were created from ProjectLocations

            // these were created as part of the update, and thus will get deleted by the refresh
            foreach (var newProjectLocationUpdate in newProjectLocationUpdates)
            {
                if (newProjectLocationUpdate.TreatmentUpdates.Any())
                {
                    isValid = false;
                    break;
                }
            }
            if (!isValid) return false;

            // type changed to Treatment Area and associated with a TreatmentUpdate; refresh will cause the TreatmentUpdate to refer to a ProjectLocationUpdate that is no longer a Treatment Area
            foreach (var exisitingProjectLocationUpdate in exisitingProjectLocationUpdates)
            {
                if (exisitingProjectLocationUpdate.TreatmentUpdates.Any())
                {
                    var correspondingProjectLocation = projectLocations.SingleOrDefault(x => x.ProjectLocationID == exisitingProjectLocationUpdate.ProjectLocationID);
                    if (correspondingProjectLocation?.ProjectLocationTypeID != ProjectLocationType.TreatmentArea.ProjectLocationTypeID)
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }
    }
}
