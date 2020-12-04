SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Program](
	[ProgramID] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[ProgramName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProgramShortName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProgramPrimaryContactPersonID] [int] NULL,
	[ProgramIsActive] [bit] NOT NULL,
	[ProgramCreateDate] [datetime] NOT NULL,
	[ProgramCreatePersonID] [int] NOT NULL,
	[ProgramLastUpdatedDate] [datetime] NULL,
	[ProgramLastUpdatedByPersonID] [int] NULL,
 CONSTRAINT [PK_Program_ProgramID] PRIMARY KEY CLUSTERED 
(
	[ProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Program_ProgramName_OrganizationID] UNIQUE NONCLUSTERED 
(
	[ProgramName] ASC,
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Program_ProgramShortName_OrganizationID] UNIQUE NONCLUSTERED 
(
	[ProgramShortName] ASC,
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Program]  WITH CHECK ADD  CONSTRAINT [FK_Program_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[Program] CHECK CONSTRAINT [FK_Program_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[Program]  WITH CHECK ADD  CONSTRAINT [FK_Program_Person_ProgramCreatePersonID_PersonID] FOREIGN KEY([ProgramCreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[Program] CHECK CONSTRAINT [FK_Program_Person_ProgramCreatePersonID_PersonID]
GO
ALTER TABLE [dbo].[Program]  WITH CHECK ADD  CONSTRAINT [FK_Program_Person_ProgramLastUpdatedByPersonID_PersonID] FOREIGN KEY([ProgramLastUpdatedByPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[Program] CHECK CONSTRAINT [FK_Program_Person_ProgramLastUpdatedByPersonID_PersonID]
GO
ALTER TABLE [dbo].[Program]  WITH CHECK ADD  CONSTRAINT [FK_Program_Person_ProgramPrimaryContactPersonID_PersonID] FOREIGN KEY([ProgramPrimaryContactPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[Program] CHECK CONSTRAINT [FK_Program_Person_ProgramPrimaryContactPersonID_PersonID]