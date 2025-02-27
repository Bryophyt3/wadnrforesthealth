﻿/*-----------------------------------------------------------------------
<copyright file="ProjectBasicsUpdateDiff.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
namespace ProjectFirma.Web.Models
{
    public class ProjectBasicsUpdateDiff
    {
        public readonly ProjectUpdate OriginalProjectUpdate;
        public readonly ProjectUpdate ModifiedProjectUpdate;

        public ProjectBasicsUpdateDiff(ProjectUpdate originalProjectUpdate, ProjectUpdate modifiedProjectUpdate)
        {
            OriginalProjectUpdate = originalProjectUpdate;
            ModifiedProjectUpdate = modifiedProjectUpdate;
        }

        public bool HasChanged()
        {
            return
                HasProjectDescriptionChanged() ||
                HasProjectStageChanged() ||
                HasPlannedDateChanged() ||
                HasImplementationStartYearChanged() ||
                HasCompletionDateChanged() ||
                HasEstimatedTotalCostChanged();
        }

        private bool HasEstimatedTotalCostChanged()
        {
            return OriginalProjectUpdate.EstimatedTotalCost != ModifiedProjectUpdate.EstimatedTotalCost;
        }

        private bool HasCompletionDateChanged()
        {
            return OriginalProjectUpdate.GetCompletionYear() != ModifiedProjectUpdate.GetCompletionYear();
        }

        private bool HasImplementationStartYearChanged()
        {
            return OriginalProjectUpdate.GetImplementationStartYear() != ModifiedProjectUpdate.GetImplementationStartYear();
        }

        private bool HasPlannedDateChanged()
        {
            return OriginalProjectUpdate.PlannedDate != ModifiedProjectUpdate.PlannedDate;
        }

        private bool HasProjectStageChanged()
        {
            return OriginalProjectUpdate.ProjectStageID != ModifiedProjectUpdate.ProjectStageID;
        }

        private bool HasProjectDescriptionChanged()
        {
            return OriginalProjectUpdate.ProjectDescription != ModifiedProjectUpdate.ProjectDescription;
        }
    }
}
