﻿/*-----------------------------------------------------------------------
<copyright file="IPerformanceMeasureValue.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

namespace ProjectFirma.Web.Models
{
    public interface IPerformanceMeasureValue
    {
        Int32 PerformanceMeasureID { get; set; }
        List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureSubcategoryOptions { get; }
        PerformanceMeasure PerformanceMeasure { get; set; }
        double? ReportedValue { get; }
        string PerformanceMeasureSubcategoriesAsString { get; }
    }

    /// <summary>
    /// This exists so that overrides of <see cref="PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues"/> can set their Subcategory/Options in a customized way
    /// </summary>
    public class VirtualPerformanceMeasureValue : IPerformanceMeasureValue
    {
        public VirtualPerformanceMeasureValue(PerformanceMeasureReportedValue performanceMeasureReportedValue)
        {
            PerformanceMeasure = performanceMeasureReportedValue.PerformanceMeasure;
            PerformanceMeasureID = PerformanceMeasure.PerformanceMeasureID;
            ReportedValue = performanceMeasureReportedValue.ReportedValue;
            PerformanceMeasureSubcategoryOptions = performanceMeasureReportedValue.PerformanceMeasureSubcategoryOptions;
            PerformanceMeasureSubcategoriesAsString =
                performanceMeasureReportedValue.PerformanceMeasureSubcategoriesAsString;
            ProjectID = performanceMeasureReportedValue.Project.ProjectID;
            Project = performanceMeasureReportedValue.Project;
            CalendarYear = performanceMeasureReportedValue.CalendarYear;
        }

        public int CalendarYear { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; private set; }
        public int PerformanceMeasureID { get; set; }
        public List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureSubcategoryOptions { get; }
        public PerformanceMeasure PerformanceMeasure { get; set; }
        public double? ReportedValue { get; }
        public string PerformanceMeasureSubcategoriesAsString { get; }
    }
}
