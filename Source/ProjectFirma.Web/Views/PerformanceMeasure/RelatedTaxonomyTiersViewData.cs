﻿/*-----------------------------------------------------------------------
<copyright file="RelatedTaxonomyTiersViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common.HtmlHelperExtensions;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class RelatedTaxonomyTiersViewData : FirmaUserControlViewData
    {
        public TaxonomyLevel AssociatePerformanceMeasureTaxonomyLevel { get; }
        public string TaxonomyTierDisplayNamePluralized { get; set; }
        public string TaxonomyTierDisplayName { get; set; }
        public string PerformanceMeasureDisplayName { get; set; }
        public IEnumerable<IGrouping<ITaxonomyTier, ProjectTypePerformanceMeasure>> ProjectTypePerformanceMeasures { get; }
        public HtmlString TaxonomyTierHeaderDisplayName { get; }
        public HtmlString IsPrimaryTaxonomyTierHeaderDisplayName { get; }

        public RelatedTaxonomyTiersViewData(Models.PerformanceMeasure performanceMeasure, TaxonomyLevel associatePerformanceMeasureTaxonomyLevel, bool showHelpLinks)
        {
            ProjectTypePerformanceMeasures = performanceMeasure.GetTaxonomyTiers();
            PerformanceMeasureDisplayName = MultiTenantHelpers.GetPerformanceMeasureName();
            var fieldDefinitionForTaxonomyTier = associatePerformanceMeasureTaxonomyLevel.GetFieldDefinition();
            TaxonomyTierDisplayName = fieldDefinitionForTaxonomyTier.GetFieldDefinitionLabel();
            TaxonomyTierHeaderDisplayName = showHelpLinks
                ? LabelWithSugarForExtensions.LabelWithSugarFor(
                    fieldDefinitionForTaxonomyTier, LabelWithSugarForExtensions.DefaultPopupWidth,
                    LabelWithSugarForExtensions.DisplayStyle.HelpIconWithLabel, TaxonomyTierDisplayName)
                : new HtmlString(TaxonomyTierDisplayName);
            var fieldDefinitionIsPrimaryTaxonomyBranch = Models.FieldDefinition.IsPrimaryTaxonomyBranch;
            var isPrimaryTaxonomyBranchLabel = $"Is Primary {TaxonomyTierDisplayName}";
            IsPrimaryTaxonomyTierHeaderDisplayName = showHelpLinks
                ? LabelWithSugarForExtensions.LabelWithSugarFor(
                    fieldDefinitionIsPrimaryTaxonomyBranch, LabelWithSugarForExtensions.DefaultPopupWidth,
                    LabelWithSugarForExtensions.DisplayStyle.HelpIconWithLabel, isPrimaryTaxonomyBranchLabel)
                : new HtmlString(isPrimaryTaxonomyBranchLabel);
            TaxonomyTierDisplayNamePluralized = fieldDefinitionForTaxonomyTier.GetFieldDefinitionLabelPluralized();
            AssociatePerformanceMeasureTaxonomyLevel = associatePerformanceMeasureTaxonomyLevel;
        }
    }
}
