﻿using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ReportTemplateModelExtensions
    {
        public static HtmlString DownloadTemplateLink(this ReportTemplate reportTemplate)
        {
            var linkText = reportTemplate.FileResource.OriginalBaseFilename +
                           reportTemplate.FileResource.OriginalFileExtension;
            return UrlTemplate.MakeHrefString(reportTemplate.FileResource.FileResourceUrl, linkText);
        }

        public static string FileResourceName(this ReportTemplate reportTemplate)
        {
            return $"{reportTemplate.FileResource.OriginalBaseFilename}{reportTemplate.FileResource.OriginalFileExtension}";
        }

    }
}