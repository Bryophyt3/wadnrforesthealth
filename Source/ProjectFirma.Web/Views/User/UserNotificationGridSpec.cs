﻿/*-----------------------------------------------------------------------
<copyright file="UserNotificationGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.User
{
    public class UserNotificationGridSpec : GridSpec<Notification>
    {
        public UserNotificationGridSpec()
        {
            Add("Date", x => x.NotificationDate, 120);
            Add("Notification Type", x => x.NotificationType.NotificationTypeDisplayName, 140, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Notification",
                x => x.NotificationType.GetFullDescriptionFromUserPerspective(x),
                500,
                DhtmlxGridColumnFilterType.Html);
            Add($"# of {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", x => x.NotificationProjects.Count, 100);
            Add($"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()}", x =>
            {
                if (x.NotificationType == NotificationType.ProjectUpdateReminder)
                {
                    return new HtmlString(string.Empty);
                }
                var notificationProject = x.NotificationProjects.SingleOrDefault();
                if (notificationProject == null)
                {
                    return new HtmlString(string.Empty);
                }
                return notificationProject.Project.DisplayNameAsUrl;
            }, 200, DhtmlxGridColumnFilterType.Html);
        }
    }
}
