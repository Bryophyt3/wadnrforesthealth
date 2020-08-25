SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InteractionEvent](
	[InteractionEventID] [int] IDENTITY(1,1) NOT NULL,
	[InteractionEventTypeID] [int] NOT NULL,
	[StaffPersonID] [int] NULL,
	[InteractionEventTitle] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[InteractionEventDescription] [varchar](3000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[InteractionEventDate] [datetime] NOT NULL,
	[InteractionEventLocationSimple] [geometry] NULL,
 CONSTRAINT [PK_InteractionEvent_InteractionEventID] PRIMARY KEY CLUSTERED 
(
	[InteractionEventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[InteractionEvent]  WITH CHECK ADD  CONSTRAINT [FK_InteractionEvent_InteractionEventType_InteractionEventTypeID] FOREIGN KEY([InteractionEventTypeID])
REFERENCES [dbo].[InteractionEventType] ([InteractionEventTypeID])
GO
ALTER TABLE [dbo].[InteractionEvent] CHECK CONSTRAINT [FK_InteractionEvent_InteractionEventType_InteractionEventTypeID]
GO
ALTER TABLE [dbo].[InteractionEvent]  WITH CHECK ADD  CONSTRAINT [FK_InteractionEvent_Person_StaffPersonID_PersonID] FOREIGN KEY([StaffPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[InteractionEvent] CHECK CONSTRAINT [FK_InteractionEvent_Person_StaffPersonID_PersonID]