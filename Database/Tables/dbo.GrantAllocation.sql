SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrantAllocation](
	[GrantAllocationID] [int] IDENTITY(1,1) NOT NULL,
	[GrantAllocationName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[AllocationAmount] [money] NULL,
	[FederalFundCodeID] [int] NULL,
	[OrganizationID] [int] NULL,
	[DNRUplandRegionID] [int] NULL,
	[DivisionID] [int] NULL,
	[GrantManagerID] [int] NULL,
	[GrantModificationID] [int] NOT NULL,
 CONSTRAINT [PK_GrantAllocation_GrantAllocationID] PRIMARY KEY CLUSTERED 
(
	[GrantAllocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[GrantAllocation]  WITH CHECK ADD  CONSTRAINT [FK_GrantAllocation_Division_DivisionID] FOREIGN KEY([DivisionID])
REFERENCES [dbo].[Division] ([DivisionID])
GO
ALTER TABLE [dbo].[GrantAllocation] CHECK CONSTRAINT [FK_GrantAllocation_Division_DivisionID]
GO
ALTER TABLE [dbo].[GrantAllocation]  WITH CHECK ADD  CONSTRAINT [FK_GrantAllocation_DNRUplandRegion_DNRUplandRegionID] FOREIGN KEY([DNRUplandRegionID])
REFERENCES [dbo].[DNRUplandRegion] ([DNRUplandRegionID])
GO
ALTER TABLE [dbo].[GrantAllocation] CHECK CONSTRAINT [FK_GrantAllocation_DNRUplandRegion_DNRUplandRegionID]
GO
ALTER TABLE [dbo].[GrantAllocation]  WITH CHECK ADD  CONSTRAINT [FK_GrantAllocation_FederalFundCode_FederalFundCodeID] FOREIGN KEY([FederalFundCodeID])
REFERENCES [dbo].[FederalFundCode] ([FederalFundCodeID])
GO
ALTER TABLE [dbo].[GrantAllocation] CHECK CONSTRAINT [FK_GrantAllocation_FederalFundCode_FederalFundCodeID]
GO
ALTER TABLE [dbo].[GrantAllocation]  WITH CHECK ADD  CONSTRAINT [FK_GrantAllocation_GrantModification_GrantModificationID] FOREIGN KEY([GrantModificationID])
REFERENCES [dbo].[GrantModification] ([GrantModificationID])
GO
ALTER TABLE [dbo].[GrantAllocation] CHECK CONSTRAINT [FK_GrantAllocation_GrantModification_GrantModificationID]
GO
ALTER TABLE [dbo].[GrantAllocation]  WITH CHECK ADD  CONSTRAINT [FK_GrantAllocation_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[GrantAllocation] CHECK CONSTRAINT [FK_GrantAllocation_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[GrantAllocation]  WITH CHECK ADD  CONSTRAINT [FK_GrantAllocation_Person_GrantManagerID_PersonID] FOREIGN KEY([GrantManagerID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[GrantAllocation] CHECK CONSTRAINT [FK_GrantAllocation_Person_GrantManagerID_PersonID]