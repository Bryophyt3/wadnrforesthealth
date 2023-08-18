﻿using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Documents for {0} Updates", FieldDefinitionEnum.Project)]
    public class ProjectDocumentUpdateEditFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectDocumentUpdate>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectDocumentUpdate> _firmaFeatureWithContextImpl;

        public ProjectDocumentUpdateEditFeature()
            : base(new List<Role> { Role.Normal, Role.EsaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectDocumentUpdate>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProjectDocumentUpdate contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProjectDocumentUpdate contextModelObject)
        {
            var hasPermissionByPerson = HasPermissionByPerson(person);
            if (!hasPermissionByPerson)
            {
                return new PermissionCheckResult(false, $"You don't have permission to Edit {FieldDefinition.Project.GetFieldDefinitionLabel()} {contextModelObject.DisplayName}");
            }
            return new ProjectUpdateCreateEditSubmitFeature().HasPermission(person, contextModelObject.ProjectUpdateBatch.Project);
        }
    }
}