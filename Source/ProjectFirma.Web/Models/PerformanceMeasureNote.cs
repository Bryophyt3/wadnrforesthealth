﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureNote.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureNote : IAuditableEntity, IEntityNote
    {

        public DateTime Created
        {
            get { return CreateDate; }
        }

        public string CreatedBy
        {
            get
            {
                if (CreatePersonID.HasValue)
                {
                    return CreatePerson.FullNameFirstLast;
                }
                return "System";
            }
        }

        public DateTime LastUpdated
        {
            get { return UpdateDate ?? CreateDate; }
        }

        public string LastUpdatedBy
        {
            get
            {
                if (UpdatePersonID.HasValue)
                {
                    return UpdatePerson.FullNameFirstLast;
                }
                return string.Empty;
            }
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<PerformanceMeasureNoteController>.BuildUrlFromExpression(c => c.DeletePerformanceMeasureNote(PerformanceMeasureNoteID)); }
        }

        public string EditUrl
        {
            get { return SitkaRoute<PerformanceMeasureNoteController>.BuildUrlFromExpression(c => c.Edit(PerformanceMeasureNoteID)); }
        }



        public string AuditDescriptionString
        {
            get
            {
                var performanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Find(PerformanceMeasureID);
                var pmName = performanceMeasure != null ? performanceMeasure.AuditDescriptionString : ViewUtilities.NotFoundString;
                return $"Performance Measure: {pmName}";
            }
        }
    }
}
