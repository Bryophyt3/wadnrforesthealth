SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectUpdateHistory](
	[ProjectUpdateHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[ProjectUpdateStateID] [int] NOT NULL,
	[UpdatePersonID] [int] NOT NULL,
	[TransitionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectUpdateHistory_ProjectUpdateHistoryID] PRIMARY KEY CLUSTERED 
(
	[ProjectUpdateHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectUpdateHistory]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateHistory_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ProjectUpdateHistory] CHECK CONSTRAINT [FK_ProjectUpdateHistory_Person_UpdatePersonID_PersonID]
GO
ALTER TABLE [dbo].[ProjectUpdateHistory]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateHistory_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectUpdateHistory] CHECK CONSTRAINT [FK_ProjectUpdateHistory_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectUpdateHistory]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateHistory_ProjectUpdateState_ProjectUpdateStateID] FOREIGN KEY([ProjectUpdateStateID])
REFERENCES [dbo].[ProjectUpdateState] ([ProjectUpdateStateID])
GO
ALTER TABLE [dbo].[ProjectUpdateHistory] CHECK CONSTRAINT [FK_ProjectUpdateHistory_ProjectUpdateState_ProjectUpdateStateID]