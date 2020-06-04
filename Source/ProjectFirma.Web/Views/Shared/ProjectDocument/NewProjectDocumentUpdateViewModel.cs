﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Shared.ProjectDocument
{
    // exists because validating a document requires making sure its name is unique, and to do that requires knowing if it's a Document or a Document Update
    public class NewProjectDocumentUpdateViewModel: NewProjectDocumentViewModel
    {
        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public NewProjectDocumentUpdateViewModel() { }

        public NewProjectDocumentUpdateViewModel(Models.ProjectUpdateBatch projectUpdateBatch)
        {
            ParentID = projectUpdateBatch.ProjectUpdateBatchID;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            // todo: multi-file upload
            //if (HttpRequestStorage.DatabaseEntities.ProjectDocumentUpdates.Where(x => x.ProjectUpdateBatchID == ParentID)
            //    .Any(x => x.DisplayName.ToLower() == DisplayName.ToLower()))
            //{
            //    validationResults.Add(new SitkaValidationResult<NewProjectDocumentViewModel, string>($"The Display Name must be unique for each Document attached to a {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Update", m => m.DisplayName));
            //}

            return validationResults;
        }
    }
}
