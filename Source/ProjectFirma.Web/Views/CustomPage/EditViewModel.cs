﻿/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.CustomPage
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        public int CustomPageID { get; set; }

        [Required]
        [StringLength(Models.CustomPage.FieldLengths.CustomPageDisplayName)]
        [DisplayName("Page Name")]
        public string CustomPageDisplayName { get; set; }

        [Required]
        [StringLength(Models.CustomPage.FieldLengths.CustomPageVanityUrl)]
        [DisplayName("Vanity Url")]
        public string CustomPageVanityUrl { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CustomPageDisplayType)]
        [Required]
        public int? CustomPageDisplayTypeID { get; set; }

        [DisplayName("Navigation Section")]
        [Required]
        public int CustomPageNavigationSectionID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.CustomPage customPage)
        {
            CustomPageID = customPage.CustomPageID;
            CustomPageDisplayName = customPage.CustomPageDisplayName;
            CustomPageVanityUrl = customPage.CustomPageVanityUrl;
            CustomPageDisplayTypeID = customPage.CustomPageDisplayTypeID;
            CustomPageNavigationSectionID = customPage.CustomPageNavigationSectionID;
        }

        public void UpdateModel(Models.CustomPage customPage, Person currentPerson)
        {
            customPage.CustomPageDisplayName = CustomPageDisplayName;
            customPage.CustomPageVanityUrl = CustomPageVanityUrl;
            customPage.CustomPageDisplayTypeID = CustomPageDisplayTypeID.Value;
            customPage.CustomPageNavigationSectionID = CustomPageNavigationSectionID;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            var existingCustomPages = MultiTenantHelpers.GetAllCustomPages();
            if (!CustomPageModelExtensions.IsDisplayNameUnique(existingCustomPages, CustomPageDisplayName, CustomPageID))
            {
                validationResults.Add(new SitkaValidationResult<EditViewModel, string>("Custom Page with the provided Display Name already exists.", x => x.CustomPageDisplayName));
            }
           
            if (!string.IsNullOrWhiteSpace(CustomPageVanityUrl))
            {
                if (!new Regex("^[a-zA-Z0-9]*$").IsMatch(CustomPageVanityUrl))
                {
                    validationResults.Add(new SitkaValidationResult<EditViewModel, string>("Vanity Url must not contain any special characters or spaces.", x => x.CustomPageVanityUrl));
                }
                else if (!CustomPageModelExtensions.IsVanityUrlUnique(existingCustomPages, CustomPageVanityUrl, CustomPageID))
                {
                    validationResults.Add(new SitkaValidationResult<EditViewModel, string>("A Custom Page with the provided Vanity Url already exists.", x => x.CustomPageVanityUrl));
                }
            }

            return validationResults;
        }

    }
}
