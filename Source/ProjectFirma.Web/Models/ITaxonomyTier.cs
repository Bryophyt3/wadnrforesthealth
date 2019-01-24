﻿using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFirma.Web.Models
{
    public interface ITaxonomyTier : IHaveASortOrder
    {
        int TaxonomyTierID { get; }
        string ThemeColor { get; }
        HtmlString GetDisplayNameAsUrl();
        List<IGrouping<PerformanceMeasure, ProjectTypePerformanceMeasure>> GetTaxonomyTierPerformanceMeasures();
        string SummaryUrl { get; }
        FancyTreeNode ToFancyTreeNode(Person currentPerson);
    }
}
