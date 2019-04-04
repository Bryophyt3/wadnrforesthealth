SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectFundingSourceExpenditureUpdate](
	[ProjectFundingSourceExpenditureUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[ExpenditureAmount] [money] NOT NULL,
	[GrantAllocationID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectFundingSourceExpenditureUpdate_ProjectFundingSourceExpenditureUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectFundingSourceExpenditureUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectFundingSourceExpenditureUpdate_ProjectUpdateBatchID_FundingSourceID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[FundingSourceID] ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_FundingSource_FundingSourceID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_GrantAllocation_GrantAllocationID] FOREIGN KEY([GrantAllocationID])
REFERENCES [dbo].[GrantAllocation] ([GrantAllocationID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_GrantAllocation_GrantAllocationID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]