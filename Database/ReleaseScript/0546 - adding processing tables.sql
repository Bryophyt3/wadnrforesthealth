
CREATE TABLE dbo.TabularDataImportTableType(
	[TabularDataImportTableTypeID] [int] NOT NULL,
	[TabularDataImportTableTypeName] [varchar](200) NOT NULL,
 CONSTRAINT [PK_TabularDataImportTableType_TabularDataImportTableTypeID] PRIMARY KEY CLUSTERED 
(
	[TabularDataImportTableTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE dbo.[TabularDataImport](
	[TabularDataImportID] [int] IDENTITY(1,1) NOT NULL,
	[TabularDataImportTableTypeID] [int] NOT NULL,
	[UploadDate] [datetime] NULL,
	[UploadPersonID] [int] NULL,
	[LastProcessedDate] [datetime] NULL,
	[LastProcessedPersonID] [int] NULL,
 CONSTRAINT [PK_TabularDataImport_TabularDataImportID] PRIMARY KEY CLUSTERED 
(
	[TabularDataImportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE dbo.TabularDataImport  WITH CHECK ADD  CONSTRAINT [FK_TabularDataImport_TabularDataImportTableType_TabularDataImportTableTypeID] FOREIGN KEY(TabularDataImportTableTypeID)
REFERENCES dbo.TabularDataImportTableType (TabularDataImportTableTypeID)
GO


ALTER TABLE dbo.TabularDataImport  WITH CHECK ADD  CONSTRAINT [FK_TabularDataImport_Person_LastProcessedPersonID_PersonID] FOREIGN KEY([LastProcessedPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO



ALTER TABLE dbo.TabularDataImport  WITH CHECK ADD  CONSTRAINT [FK_TabularDataImport_Person_UploadPersonID_PersonID] FOREIGN KEY([UploadPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO


