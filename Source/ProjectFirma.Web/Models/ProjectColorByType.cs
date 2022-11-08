﻿/*-----------------------------------------------------------------------
<copyright file="ProjectColorByType.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectColorByType
    {
        public abstract string DisplayName { get; }
        public abstract bool IsRelevantToTenant { get; }
    }

    public partial class ProjectColorByTypeTaxonomyTrunk
    {
        public override string DisplayName => FieldDefinition.TaxonomyTrunk.GetFieldDefinitionLabel();

        public override bool IsRelevantToTenant => MultiTenantHelpers.IsTaxonomyLevelTrunk();
    }

    public partial class ProjectColorByTypeProjectStage
    {
        public override string DisplayName => ProjectColorByTypeDisplayName;

        public override bool IsRelevantToTenant => true;
    }

    public partial class ProjectColorByTypeTaxonomyBranch
    {
        public override string DisplayName => FieldDefinition.TaxonomyBranch.GetFieldDefinitionLabel();

        public override bool IsRelevantToTenant => MultiTenantHelpers.IsTaxonomyLevelBranch();
    }

}
