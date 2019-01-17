//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectOrganization]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectOrganization GetProjectOrganization(this IQueryable<ProjectOrganization> projectOrganizations, int projectOrganizationID)
        {
            var projectOrganization = projectOrganizations.SingleOrDefault(x => x.ProjectOrganizationID == projectOrganizationID);
            Check.RequireNotNullThrowNotFound(projectOrganization, "ProjectOrganization", projectOrganizationID);
            return projectOrganization;
        }

        public static void DeleteProjectOrganization(this IQueryable<ProjectOrganization> projectOrganizations, List<int> projectOrganizationIDList)
        {
            if(projectOrganizationIDList.Any())
            {
                projectOrganizations.Where(x => projectOrganizationIDList.Contains(x.ProjectOrganizationID)).Delete();
            }
        }

        public static void DeleteProjectOrganization(this IQueryable<ProjectOrganization> projectOrganizations, ICollection<ProjectOrganization> projectOrganizationsToDelete)
        {
            if(projectOrganizationsToDelete.Any())
            {
                var projectOrganizationIDList = projectOrganizationsToDelete.Select(x => x.ProjectOrganizationID).ToList();
                projectOrganizations.Where(x => projectOrganizationIDList.Contains(x.ProjectOrganizationID)).Delete();
            }
        }

        public static void DeleteProjectOrganization(this IQueryable<ProjectOrganization> projectOrganizations, int projectOrganizationID)
        {
            DeleteProjectOrganization(projectOrganizations, new List<int> { projectOrganizationID });
        }

        public static void DeleteProjectOrganization(this IQueryable<ProjectOrganization> projectOrganizations, ProjectOrganization projectOrganizationToDelete)
        {
            DeleteProjectOrganization(projectOrganizations, new List<ProjectOrganization> { projectOrganizationToDelete });
        }
    }
}