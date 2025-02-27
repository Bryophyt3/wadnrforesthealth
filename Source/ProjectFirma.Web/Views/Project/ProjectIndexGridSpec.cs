﻿/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Project
{
    public class ProjectIndexGridSpec : GridSpec<Models.Project>
    {
        public ProjectIndexGridSpec(Person currentPerson
            , bool allowTaggingFunctionality
            , bool allowDeleteFunctionality
            , Dictionary<int, vTotalTreatedAcresByProject> totalTreatedAcresByProjectDictionary)
        {
            var userHasTagManagePermissions = new FirmaAdminFeature().HasPermissionByPerson(currentPerson);
            var userHasDeletePermissions = new ProjectDeleteFeature().HasPermissionByPerson(currentPerson);

            if (userHasTagManagePermissions && allowTaggingFunctionality)
            {
                BulkTagModalDialogForm = new BulkTagModalDialogForm(SitkaRoute<TagController>.BuildUrlFromExpression(x => x.BulkTagProjects(null)), $"Tag Checked {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", $"Tag {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}");
                AddCheckBoxColumn();
                Add("ProjectID", x => x.ProjectID, 0);
            }

            if (userHasDeletePermissions && allowDeleteFunctionality)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, true), 30, DhtmlxGridColumnFilterType.None);
            }


            Add(string.Empty, x => MakeFactSheetUrl(x), 30, DhtmlxGridColumnFilterType.None);

            Add(Models.FieldDefinition.FhtProjectNumber.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.FhtProjectNumber), 100, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.ProjectName.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName),200, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectType.ToGridHeaderString(), x => x.ProjectType.DisplayName, 120, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderString(), x => x.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);

            Add(Models.FieldDefinition.ProjectTotalCompletedTreatmentAcres.ToGridHeaderString(), x => TotalTreatedAcres(x,totalTreatedAcresByProjectDictionary), 100, DhtmlxGridColumnFormatType.Decimal );
            Add($"{MultiTenantHelpers.GetIsPrimaryContactOrganizationRelationship().RelationshipTypeName} Organization", x => x.GetPrimaryContactOrganization()?.DisplayName, 200, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.Program.ToGridHeaderStringPlural("Programs"), x => x.ProjectPrograms.ToProgramListDisplay(false), 90, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add($"Associated {Models.FieldDefinition.PriorityLandscape.ToGridHeaderString()}", x => x.ProjectPriorityLandscapes.FirstOrDefault()?.PriorityLandscape?.DisplayName, 125, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add($"Associated {Models.FieldDefinition.County.ToGridHeaderString()}", x => x.ProjectCounties.FirstOrDefault()?.County?.CountyName, 125, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }

        private static HtmlString MakeFactSheetUrl(Models.Project project)
        {
            // Only offer FactSheet viewer if one is actually available
            if (ProjectController.FactSheetIsAvailable(project))
            {
                return UrlTemplate.MakeHrefString(project.GetFactSheetUrl(), FirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString());
            }

            return new HtmlString(string.Empty);
        }
        

        private decimal TotalTreatedAcres(Models.Project project,
            Dictionary<int, vTotalTreatedAcresByProject> totalTreatedAcresByProjectDictionary)
        {
            var total = totalTreatedAcresByProjectDictionary.ContainsKey(project.ProjectID) && totalTreatedAcresByProjectDictionary[project.ProjectID].TotalTreatedAcres.HasValue
                ?  totalTreatedAcresByProjectDictionary[project.ProjectID].TotalTreatedAcres.Value
                : (decimal) 0.0;
           return Math.Round(total, 2);
        }
    }
}