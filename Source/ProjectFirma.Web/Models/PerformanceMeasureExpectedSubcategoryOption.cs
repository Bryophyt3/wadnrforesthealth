﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureExpectedSubcategoryOption.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureExpectedSubcategoryOption : IAuditableEntity, IPerformanceMeasureValueSubcategoryOption
    {
        public string PerformanceMeasureSubcategoryOptionName =>
            PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;

        public string AuditDescriptionString
        {
            get
            {
                var performanceMeasureSubcategoryOption = HttpRequestStorage.DatabaseEntities.PerformanceMeasureSubcategoryOptions.Find(PerformanceMeasureSubcategoryOptionID);
                var performanceMeasureSubcategory = HttpRequestStorage.DatabaseEntities.PerformanceMeasureSubcategories.Find(PerformanceMeasureSubcategoryID);
                var performanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Find(PerformanceMeasureID);
                var performanceMeasureSubcategoryOptionName = performanceMeasureSubcategoryOption != null ? performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName : ViewUtilities.NotFoundString;
                var performanceMeasureSubcategoryName = performanceMeasureSubcategory != null ? performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : ViewUtilities.NotFoundString;
                var performanceMeasureName = performanceMeasure != null ? performanceMeasure.PerformanceMeasureDisplayName : ViewUtilities.NotFoundString;
                return $"Performance Measure: {performanceMeasureName}, Subcategory: {performanceMeasureSubcategoryName}, Subcategory Option: {performanceMeasureSubcategoryOptionName}";
            }
        }
    }
}
