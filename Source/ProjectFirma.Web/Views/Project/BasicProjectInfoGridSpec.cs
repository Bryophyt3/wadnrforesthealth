﻿/*-----------------------------------------------------------------------
<copyright file="BasicProjectInfoGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
    public class BasicProjectInfoGridSpec : GridSpec<Models.Project>
    {
        public BasicProjectInfoGridSpec(Person currentPerson, bool allowTaggingFunctionality)
        {
            var userHasTagManagePermissions = new FirmaAdminFeature().HasPermissionByPerson(currentPerson);
            if (userHasTagManagePermissions && allowTaggingFunctionality)
            {
                BulkTagModalDialogForm = new BulkTagModalDialogForm(SitkaRoute<TagController>.BuildUrlFromExpression(x => x.BulkTagProjects(null)), $"Tag Checked {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", $"Tag {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}");
                AddCheckBoxColumn();
                Add("ProjectID", x => x.ProjectID, 0);
            }

            Add(string.Empty, x => UrlTemplate.MakeHrefString(x.GetFactSheetUrl(), FirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString()), 30, DhtmlxGridColumnFilterType.None);
            Add(Models.FieldDefinition.FhtProjectNumber.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.FhtProjectNumber), 100, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.ProjectName.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(Models.FieldDefinition.ProjectsStewardOrganizationRelationshipToProject.ToGridHeaderString(), x => x.GetCanStewardProjectsOrganization().GetShortNameAsUrl(), 150,
                    DhtmlxGridColumnFilterType.Html);
            }
            Add(Models.FieldDefinition.PrimaryContactOrganization.ToGridHeaderString(), x => x.GetPrimaryContactOrganization().GetShortNameAsUrl(), 150, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderString(), x => x.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.ProjectInitiationDate.ToGridHeaderString(), x => x.GetPlannedDate(), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.ExpirationDate.ToGridHeaderString(), x => x.GetExpirationDateFormatted(), 115, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.CompletionDate.ToGridHeaderString(), x => x.GetCompletionDateFormatted(), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.EstimatedTotalCost.ToGridHeaderString(), x => x.EstimatedTotalCost, 110, DhtmlxGridColumnFormatType.CurrencyWithCents, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.ProjectGrantAllocationRequestTotalAmount.ToGridHeaderString(), x => x.GetTotalFunding(), 110, DhtmlxGridColumnFormatType.CurrencyWithCents, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.ProjectDescription.ToGridHeaderString(), x => x.ProjectDescription, 300);
            if (userHasTagManagePermissions)
            {
                Add("Tags", x => new HtmlString(!x.ProjectTags.Any() ? string.Empty : string.Join(", ", x.ProjectTags.Select(pt => pt.Tag.DisplayNameAsUrl))), 100, DhtmlxGridColumnFilterType.Html);    
            }            
        }
    }
}
