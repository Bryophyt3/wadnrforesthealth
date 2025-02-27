﻿using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View JSON API landing page", FieldDefinitionEnum.Job)]
    public class ViewJsonApiLandingPageFeature : FirmaFeature
    {
        public ViewJsonApiLandingPageFeature()
            : base(new List<Role> { Role.EsaAdmin, Role.Admin, Role.ProjectSteward, Role.Normal })
        {
        }
    }
}