﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureReportedValuesGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class PerformanceMeasureReportedValuesGridSpec : GridSpec<PerformanceMeasureReportedValue>
    {
        public PerformanceMeasureReportedValuesGridSpec(Models.PerformanceMeasure performanceMeasure)
        {
            Add(Models.FieldDefinition.ReportingYear.ToGridHeaderString(), a => a.GetCalendarYearDisplay(), 60, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.Project.ToGridHeaderString(),
                a => UrlTemplate.MakeHrefString(a.ProjectUrl, a.ProjectName),
                350,
                DhtmlxGridColumnFilterType.Html);
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(Models.FieldDefinition.ProjectsStewardOrganizationRelationshipToProject.ToGridHeaderString(), x => x.Project.GetCanStewardProjectsOrganization().GetShortNameAsUrl(), 150,
                    DhtmlxGridColumnFilterType.Html);
            }
            Add(Models.FieldDefinition.PrimaryContactOrganization.ToGridHeaderString(), x => x.Project.GetPrimaryContactOrganization().GetShortNameAsUrl(), 150, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderString(), a => a.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            if (performanceMeasure.HasRealSubcategories)
            {
                foreach (var performanceMeasureSubcategory in
                    performanceMeasure.PerformanceMeasureSubcategories.OrderBy(x =>
                        x.PerformanceMeasureSubcategoryDisplayName))
                {
                    Add(performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName,
                        a =>
                        {
                            var performanceMeasureActualSubcategoryOption =
                                a.PerformanceMeasureActualSubcategoryOptions.SingleOrDefault(x =>
                                    x.PerformanceMeasureSubcategoryID ==
                                    performanceMeasureSubcategory.PerformanceMeasureSubcategoryID);
                            if (performanceMeasureActualSubcategoryOption != null)
                            {
                                return performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOption
                                    .PerformanceMeasureSubcategoryOptionName;
                            }

                            return string.Empty;
                        }, 120, DhtmlxGridColumnFilterType.SelectFilterStrict);
                }
            }
            var reportedValueColumnName = $"{Models.FieldDefinition.ReportedValue.ToGridHeaderString()} ({performanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName})";

            if (performanceMeasure.IsAggregatable)
            {
                Add(reportedValueColumnName, a => a.ReportedValue, 150, DhtmlxGridColumnFormatType.Decimal,
                    DhtmlxGridColumnAggregationType.Total);
            }
            else
            {
                Add(reportedValueColumnName, a => a.ReportedValue, 150, DhtmlxGridColumnFormatType.Decimal);
            }
        }
    }
}
