//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExemptReportingYear]
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
        public static ProjectExemptReportingYear GetProjectExemptReportingYear(this IQueryable<ProjectExemptReportingYear> projectExemptReportingYears, int projectExemptReportingYearID)
        {
            var projectExemptReportingYear = projectExemptReportingYears.SingleOrDefault(x => x.ProjectExemptReportingYearID == projectExemptReportingYearID);
            Check.RequireNotNullThrowNotFound(projectExemptReportingYear, "ProjectExemptReportingYear", projectExemptReportingYearID);
            return projectExemptReportingYear;
        }

        // Delete using an IDList (WADNR style)
        public static void DeleteProjectExemptReportingYear(this IQueryable<ProjectExemptReportingYear> projectExemptReportingYears, List<int> projectExemptReportingYearIDList)
        {
            if(projectExemptReportingYearIDList.Any())
            {
                var projectExemptReportingYearsInSourceCollectionToDelete = projectExemptReportingYears.Where(x => projectExemptReportingYearIDList.Contains(x.ProjectExemptReportingYearID));
                foreach (var projectExemptReportingYearToDelete in projectExemptReportingYearsInSourceCollectionToDelete.ToList())
                {
                    projectExemptReportingYearToDelete.Delete(HttpRequestStorage.DatabaseEntities);
                }
            }
        }

        // Delete using an object list (WADNR style)
        public static void DeleteProjectExemptReportingYear(this IQueryable<ProjectExemptReportingYear> projectExemptReportingYears, ICollection<ProjectExemptReportingYear> projectExemptReportingYearsToDelete)
        {
            if(projectExemptReportingYearsToDelete.Any())
            {
                var projectExemptReportingYearIDList = projectExemptReportingYearsToDelete.Select(x => x.ProjectExemptReportingYearID).ToList();
                var projectExemptReportingYearsToDeleteFromSourceList = projectExemptReportingYears.Where(x => projectExemptReportingYearIDList.Contains(x.ProjectExemptReportingYearID)).ToList();

                foreach (var projectExemptReportingYearToDelete in projectExemptReportingYearsToDeleteFromSourceList)
                {
                    projectExemptReportingYearToDelete.Delete(HttpRequestStorage.DatabaseEntities);
                }
            }
        }

        public static void DeleteProjectExemptReportingYear(this IQueryable<ProjectExemptReportingYear> projectExemptReportingYears, int projectExemptReportingYearID)
        {
            DeleteProjectExemptReportingYear(projectExemptReportingYears, new List<int> { projectExemptReportingYearID });
        }

        public static void DeleteProjectExemptReportingYear(this IQueryable<ProjectExemptReportingYear> projectExemptReportingYears, ProjectExemptReportingYear projectExemptReportingYearToDelete)
        {
            DeleteProjectExemptReportingYear(projectExemptReportingYears, new List<ProjectExemptReportingYear> { projectExemptReportingYearToDelete });
        }
    }
}