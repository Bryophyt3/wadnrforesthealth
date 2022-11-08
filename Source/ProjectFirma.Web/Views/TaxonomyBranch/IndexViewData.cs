﻿/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyBranch
{
    public class IndexViewData : FirmaViewData
    {        
        public IndexGridSpec GridSpec{ get; }
        public string GridName{ get; }
        public string GridDataUrl{ get; }
        public string EditSortOrderUrl { get; }
        public bool OfferEditSortOrder { get; }
        public bool HasTaxonomyBranchManagePermissions { get; }

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            var taxonomyBranchDisplayNamePluralized = Models.FieldDefinition.TaxonomyBranch.GetFieldDefinitionLabelPluralized();
            PageTitle = taxonomyBranchDisplayNamePluralized;

            // only let them sort tier two taxonomy if that's the highest level.
            OfferEditSortOrder = MultiTenantHelpers.IsTaxonomyLevelBranch();

            HasTaxonomyBranchManagePermissions = new TaxonomyBranchManageFeature().HasPermissionByPerson(currentPerson);
            var taxonomyBranchDisplayName = Models.FieldDefinition.TaxonomyBranch.GetFieldDefinitionLabel();
            GridSpec = new IndexGridSpec(currentPerson)
            {
                ObjectNameSingular = taxonomyBranchDisplayName,
                ObjectNamePlural = taxonomyBranchDisplayNamePluralized,
                SaveFiltersInCookie = true
            };

            if (HasTaxonomyBranchManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(t => t.New()), string.Format("Create a new {0}", taxonomyBranchDisplayName));
            }

            GridName = "taxonomyBranchesGrid";
            GridDataUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
            EditSortOrderUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(tc => tc.EditSortOrder());
        }
    }
}
