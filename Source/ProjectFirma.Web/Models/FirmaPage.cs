﻿/*-----------------------------------------------------------------------
<copyright file="FirmaPage.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class FirmaPage : IFirmaPage
    {
        public string FirmaPageDisplayName => FirmaPageType.FirmaPageTypeDisplayName;
        public bool HasPageContent => !string.IsNullOrWhiteSpace(FirmaPageContent);

        public static FirmaPage GetFirmaPageByPageType(FirmaPageType firmaPageType)
        {
            Check.EnsureNotNull(firmaPageType, "firmaPageType must not be null!");
            var firmaPage = HttpRequestStorage.DatabaseEntities.FirmaPages.SingleOrDefault(x => x.FirmaPageTypeID == firmaPageType.FirmaPageTypeID);
            Check.RequireNotNull(firmaPage, $"Could not find FirmaPage with FirmaPageType \"{firmaPageType.FirmaPageTypeDisplayName}\" ({firmaPageType.FirmaPageTypeID})");
            return firmaPage;
        }

        public string GetEditPageContentUrl()
        {
            return SitkaRoute<FirmaPageController>.BuildUrlFromExpression(t => t.EditInDialog(this));
        }
    }
}
