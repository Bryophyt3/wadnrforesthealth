﻿/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.ProjectType
{
    public class IndexGridSpec : GridSpec<Models.ProjectType>
    {
        public IndexGridSpec(Person currentPerson)
        {
            if (new ProjectTypeManageFeature().HasPermissionByPerson(currentPerson))
            {
                Add(string.Empty,
                    x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, !x.HasDependentObjects(), true),
                    30, DhtmlxGridColumnFilterType.None);
            }

            if (MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                Add(Models.FieldDefinition.TaxonomyTrunk.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.TaxonomyBranch.TaxonomyTrunk.SummaryUrl, a.TaxonomyBranch.TaxonomyTrunk.TaxonomyTrunkName), 250);
            }
            if (!MultiTenantHelpers.IsTaxonomyLevelLeaf())
            {
                Add(Models.FieldDefinition.TaxonomyBranch.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.TaxonomyBranch.SummaryUrl, a.TaxonomyBranch.TaxonomyBranchName), 300);
            }
            Add(Models.FieldDefinition.ProjectType.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.ProjectTypeName), 350, DhtmlxGridColumnFilterType.Html);
            Add("Description", a => a.ProjectTypeDescriptionHtmlString, 350);
            Add($"# of {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", a => a.GetAssociatedProjects(currentPerson).Count, 90);
            Add($"# of {Models.FieldDefinition.PerformanceMeasure.GetFieldDefinitionLabelPluralized()}", a => a.ProjectTypePerformanceMeasures.Count, 90);
            Add("Sort Order", a => a.ProjectTypeSortOrder, 90, DhtmlxGridColumnFormatType.None);
        }
    }
}
