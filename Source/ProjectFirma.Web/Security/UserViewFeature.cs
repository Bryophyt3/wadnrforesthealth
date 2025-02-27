﻿/*-----------------------------------------------------------------------
<copyright file="UserViewFeature.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View User")]
    public class UserViewFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Person>
    {
        private readonly FirmaFeatureWithContextImpl<Person> _firmaFeatureWithContextImpl;

        public UserViewFeature()
            : base(Role.All)
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Person>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, Person contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }


        public PermissionCheckResult HasPermission(Person person, Person contextModelObject)
        {
            if (contextModelObject == null)
            {
                return PermissionCheckResult.MakeFailurePermissionCheckResult("The Person whose details you are requesting to see doesn't exist.");
            }
            var userHasEditPermission = new UserEditBasicsFeature().HasPermissionByPerson(person);
            var userHasManagePermission = new ContactManageFeature().HasPermission(person);
            var userViewingOwnPage = person.PersonID == contextModelObject.PersonID;

            #pragma warning disable 612
            var userHasAppropriateRole = HasPermissionByPerson(person);
            #pragma warning restore 612
            if (!userHasAppropriateRole)
            {
                return PermissionCheckResult.MakeFailurePermissionCheckResult("You don't permissions to view user details. If you aren't logged in, do that and try again.");
            }

            //Only SitkaAdmin users should be able to see other SitkaAdmin users
            if (!person.HasRole(Role.EsaAdmin) && contextModelObject.HasRole(Role.EsaAdmin))
            {
                return PermissionCheckResult.MakeFailurePermissionCheckResult("You don\'t have permission to view this user.");
            }

            if (userViewingOwnPage || userHasEditPermission || userHasManagePermission)
            {
                return PermissionCheckResult.MakeSuccessPermissionCheckResult();
            }

            return PermissionCheckResult.MakeFailurePermissionCheckResult("You don\'t have permission to view this user.");
        }

    }
}
