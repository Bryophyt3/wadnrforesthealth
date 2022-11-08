﻿/*-----------------------------------------------------------------------
<copyright file="EditUserStewardshipAreasViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.UserStewardshipAreas
{
    public class EditUserStewardshipAreasViewModel : FormViewModel
    {

        [Required]
        public int PersonID { get; set; }

        public List<PersonStewardshipAreaSimple> PersonStewardshipAreaSimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditUserStewardshipAreasViewModel()
        {
        }

        public EditUserStewardshipAreasViewModel(Person person, ProjectStewardshipAreaType projectStewardshipAreaType)
        {
            PersonID = person.PersonID;
            PersonStewardshipAreaSimples = projectStewardshipAreaType.GetPersonStewardshipAreaSimples(person);
        }

        public void UpdateModel(Person person, IList<PersonStewardOrganization> allPersonStewardOrganizations)
        {
            if (PersonStewardshipAreaSimples == null)
            {
                PersonStewardshipAreaSimples = new List<PersonStewardshipAreaSimple>();
            }

            var personStewardOrganizationsUpdated = PersonStewardshipAreaSimples.Select(x =>
            {
                var personStewardOrganization = new PersonStewardOrganization(
                    x.PersonStewardshipAreaID ?? ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(), person.PersonID,
                    x.StewardshipAreaID.GetValueOrDefault()); // will never be null due to RequiredAttribute
                return personStewardOrganization;
            }).ToList();

            person.PersonStewardOrganizations.Merge(personStewardOrganizationsUpdated, 
                allPersonStewardOrganizations, 
                (x, y) => x.PersonStewardOrganizationID == y.PersonStewardOrganizationID,
                (x, y) =>
                {
                    x.PersonID = y.PersonID;
                    x.OrganizationID = y.OrganizationID;
                });

        }

        public void UpdateModel(Person person, IList<PersonStewardTaxonomyBranch> allPersonStewardTaxonomyBranches)
        {
            if (PersonStewardshipAreaSimples == null)
            {
                PersonStewardshipAreaSimples = new List<PersonStewardshipAreaSimple>();
            }

            var personStewardTaxonomyBranchesUpdated = PersonStewardshipAreaSimples.Select(x =>
            {
                var personStewardTaxonomyBranch = new PersonStewardTaxonomyBranch(
                    x.PersonStewardshipAreaID ?? ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(), person.PersonID,
                    x.StewardshipAreaID.GetValueOrDefault()); // will never be null due to RequiredAttribute
                return personStewardTaxonomyBranch;
            }).ToList();

            person.PersonStewardTaxonomyBranches.Merge(personStewardTaxonomyBranchesUpdated,
                allPersonStewardTaxonomyBranches,
                (x, y) => x.PersonStewardTaxonomyBranchID == y.PersonStewardTaxonomyBranchID,
                (x, y) =>
                {
                    x.PersonID = y.PersonID;
                    x.TaxonomyBranchID = y.TaxonomyBranchID;
                });
        }
       

        public void UpdateModel(Person person, ObservableCollection<PersonStewardRegion> allPersonStewardRegions)
        {
            if (PersonStewardshipAreaSimples == null)
            {
                PersonStewardshipAreaSimples = new List<PersonStewardshipAreaSimple>();
            }

            var personStewardRegionsUpdated = PersonStewardshipAreaSimples.Select(x =>
            {
                var personStewardRegion = new PersonStewardRegion(
                    x.PersonStewardshipAreaID ?? ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(), person.PersonID,
                    x.StewardshipAreaID.GetValueOrDefault()); // will never be null due to RequiredAttribute
                return personStewardRegion;
            }).ToList();

            person.PersonStewardRegions.Merge(personStewardRegionsUpdated,
                allPersonStewardRegions,
                (x, y) => x.PersonStewardRegionID == y.PersonStewardRegionID,
                (x, y) =>
                {
                    x.PersonID = y.PersonID;
                    x.DNRUplandRegionID = y.DNRUplandRegionID;
                });
        }
    }
}