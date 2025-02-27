﻿/*-----------------------------------------------------------------------
<copyright file="ProjectFocusAreasGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.FocusArea
{
    public class ProjectsIncludingLeadImplementingGridSpec : GridSpec<Models.Project>
    {
        public ProjectsIncludingLeadImplementingGridSpec(Person currentPerson, bool showSubmittalStatus)
        {
            Add(Models.FieldDefinition.FhtProjectNumber.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.FhtProjectNumber), 100, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.Project.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.DisplayName), 350, DhtmlxGridColumnFilterType.Html);

            if (showSubmittalStatus)
            {
                Add("Submittal Status", a => a.ProjectApprovalStatus.ProjectApprovalStatusDisplayName, 110, DhtmlxGridColumnFilterType.SelectFilterStrict);
            }
            
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderString(), a => a.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            //Add(Models.FieldDefinition.ProjectRelationshipType.ToGridHeaderStringPlural(Models.FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabelPluralized()),
            //    a => a.AssocatedFocusAreaNames(focusArea), 180, DhtmlxGridColumnFilterType.Text);

            Add(Models.FieldDefinition.ProjectInitiationDate.ToGridHeaderString(), x => x.GetPlannedDate(), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.ExpirationDate.ToGridHeaderString(), x => x.ExpirationDate, 115, DhtmlxGridColumnFormatType.Date);
            Add(Models.FieldDefinition.CompletionDate.ToGridHeaderString(), x => x.CompletionDate, 90, DhtmlxGridColumnFormatType.Date);
            Add($"Number Of Reported {MultiTenantHelpers.GetPerformanceMeasureName()} Records", x => x.PerformanceMeasureActuals.Count, 100);
            Add($"Number Of {Models.FieldDefinition.ReportedExpenditure.GetFieldDefinitionLabel()} Records", x => x.ProjectGrantAllocationExpenditures.Count, 100);
            Add(Models.FieldDefinition.EstimatedTotalCost.ToGridHeaderString(), x => x.EstimatedTotalCost, 85, DhtmlxGridColumnFormatType.CurrencyWithCents, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.ProjectGrantAllocationRequestTotalAmount.ToGridHeaderString(), x => x.GetTotalFunding(), 85, DhtmlxGridColumnFormatType.CurrencyWithCents, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.ProjectDescription.ToGridHeaderString(), x => x.ProjectDescription, 200);
            if (new FirmaAdminFeature().HasPermissionByPerson(currentPerson))
            {
                Add("Tags", x => new HtmlString(!x.ProjectTags.Any() ? string.Empty : string.Join(", ", x.ProjectTags.Select(pt => pt.Tag.DisplayNameAsUrl))), 100, DhtmlxGridColumnFilterType.Html);
            }
            Add("# of Photos", x => x.ProjectImages.Count, 60);
        }
    }
}
