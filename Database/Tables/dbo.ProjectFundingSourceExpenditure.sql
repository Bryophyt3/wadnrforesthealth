SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectFundingSourceExpenditure](
	[ProjectFundingSourceExpenditureID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[ExpenditureAmount] [money] NOT NULL,
	[GrantAllocationID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectFundingSourceExpenditure_ProjectFundingSourceExpenditureID] PRIMARY KEY CLUSTERED 
(
	[ProjectFundingSourceExpenditureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectFundingSourceExpenditure_ProjectID_FundingSourceID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[FundingSourceID] ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditure]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceExpenditure_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditure] CHECK CONSTRAINT [FK_ProjectFundingSourceExpenditure_FundingSource_FundingSourceID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditure]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceExpenditure_GrantAllocation_GrantAllocationID] FOREIGN KEY([GrantAllocationID])
REFERENCES [dbo].[GrantAllocation] ([GrantAllocationID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditure] CHECK CONSTRAINT [FK_ProjectFundingSourceExpenditure_GrantAllocation_GrantAllocationID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditure]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceExpenditure_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditure] CHECK CONSTRAINT [FK_ProjectFundingSourceExpenditure_Project_ProjectID]