﻿/*-----------------------------------------------------------------------
<copyright file="PersonModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    /// <summary>
    /// These have been implemented as extension methods on <see cref="Person"/> so we can handle the anonymous user as a null person object
    /// </summary>
    public static class PersonModelExtensions
    {
        public static HtmlString GetFullNameFirstLastAsUrl(this Person person)
        {
            return person != null ? UrlTemplate.MakeHrefString(person.GetDetailUrl(), person.FullNameFirstLast) : new HtmlString(null);
        }

        public static HtmlString GetFullNameLastFirstAsUrl(this Person person)
        {
            return person != null ? UrlTemplate.MakeHrefString(person.GetDetailUrl(), person.FullNameLastFirst) : new HtmlString(null);
        }

        public static HtmlString GetFullNameFirstLastAndOrgAsUrl(this Person person)
        {
            if (person == null)
            {
                return new HtmlString(null);
            }
            var userUrl = person.GetFullNameFirstLastAsUrl();
            var orgUrl = person.Organization?.GetDisplayNameAsUrl();
            return new HtmlString($"{userUrl} - {orgUrl}");
        }

        public static HtmlString GetFullNameFirstLastAndOrgShortNameAsUrl(this Person person)
        {
            if (person == null)
            {
                return new HtmlString(null);
            }
            var userUrl = person.GetFullNameFirstLastAsUrl();
            var orgUrl = person.Organization?.GetShortNameAsUrl();
            return new HtmlString($"{userUrl} ({orgUrl})");
        }

        public static HtmlString GetFullNameFirstLastAsStringAndOrgAsUrl(this Person person)
        {
            if (person == null)
            {
                return new HtmlString(null);
            }
            var userString = person.FullNameFirstLast;
            var orgUrl = person.Organization?.GetShortNameAsUrl();
            return new HtmlString($"{userString} - {orgUrl}");
        }

        public static HtmlString GetFirstNameAsUrl(this Person person)
        {
            return person != null ? UrlTemplate.MakeHrefString(person.GetDetailUrl(), person.FirstName) : new HtmlString(null);
        }

        public static HtmlString GetLastNameAsUrl(this Person person)
        {
            return person != null ? UrlTemplate.MakeHrefString(person.GetDetailUrl(), person.LastName) : new HtmlString(null);
        }

        public static string GetEditUrl(this Person person)
        {
            return SitkaRoute<UserController>.BuildUrlFromExpression(t => t.EditRoles(person));
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<UserController>.BuildUrlFromExpression(t => t.Delete(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this Person person)
        {
            return DeleteUrlTemplate.ParameterReplace(person.PersonID);
        }

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<UserController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this Person person)
        {
            return DetailUrlTemplate.ParameterReplace(person.PersonID);
        }

        public static bool IsSitkaAdministrator(this Person person)
        {
            return person != null && person.Role == Role.SitkaAdmin;

        }

        public static bool IsAdministrator(this Person person)
        {
            return person != null && (person.Role == Role.Admin || IsSitkaAdministrator(person));
        }

        public static bool IsApprover(this Person person)
        {
            return person != null && (person.IsAdministrator() || person.IsSitkaAdministrator());
        }
        
        public static bool ShouldReceiveNotifications(this Person person)
        {
            return person.ReceiveSupportEmails;
        }
    }
}
