insert into dbo.ReportTemplateModelType
	(ReportTemplateModelTypeID, ReportTemplateModelTypeName, ReportTemplateModelTypeDisplayName, ReportTemplateModelTypeDescription)
select 1, 'SingleModel', 'Single Model', 'Reports with the "Single Model" model type will be provided a single model per report. If multiple elements are selected and generated with this model type, the template will be run for each of the elements and then joined into a final word document.'
union
select 2, 'MultipleModels', 'Multiple Models', 'Reports with the "Multiple Models" model type will be provided with a list of the elements selected for the report. The template will be run once, but will have access to all of the models selected for iteration within it.'

go

insert into dbo.ReportTemplate(FileResourceID, DisplayName, Description, ReportTemplateModelTypeID, ReportTemplateModelID, IsSystemTemplate)
select 
	FileResourceID,
	'LOA Approval Letter' as DisplayName,
	NULL as Description,
	2 as ReportTemplateModelTypeID,
	1 as ReportTemplateModelID,
	1 as IsSystemTemplate
 from
	dbo.FileResource where OriginalBaseFilename = 'LOA Approval Letter'