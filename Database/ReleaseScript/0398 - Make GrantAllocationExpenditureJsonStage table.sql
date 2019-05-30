
-- Table to be used in JSON imports
CREATE TABLE [dbo].[GrantAllocationExpenditureJsonStage]
(
    [GrantAllocationExpenditureJsonStageID] int identity(1,1) constraint PK_GrantAllocationExpenditureJsonStage_GrantAllocationExpenditureJsonStageID primary key,
    [Biennium] [int] NULL,
    [FiscalMo] [int] NULL,
    [FiscalAdjMo] [int] NULL,
    [CalYr] [int] NULL,
    [MoString] [varchar](20) NULL,
    [SourceSystem] [varchar](50) NULL,
    [DocNo] [varchar](200) NULL,
    [DocSuffix] [varchar](10) NULL,
    [DocDate] [datetime] NULL,
    [InvoiceDesc] [varchar](max) NULL,
    [InvoiceDate] [datetime] NULL,
    [GlAcctNo] [int] NULL,
    [ObjCd] [varchar](20) NULL,
    [ObjName] [varchar](max) NULL,
    [SubObjCd] [varchar](20) NULL,
    [SubObjName] [varchar](max) NULL,
    [SubSubObjCd] [varchar](20) NULL,
    [SubSubObjName] [varchar](max) NULL,
    [ApprnCd] [varchar](20) NULL,
    [ApprnName] [varchar](max) NULL,
    [FundCd] [varchar](20) NULL,
    [FundName] [varchar](max) NULL,
    [OrgCd] [varchar](20) NULL,
    [OrgName] [varchar](max) NULL,
    [ProgIdxCd] [varchar](20) NULL,
    [ProgIdxName] [varchar](max) NULL,
    [ProgCd] [varchar](20) NULL,
    [ProgName] [varchar](max) NULL,
    [SubProgCd] [varchar](20) NULL,
    [SubProgName] [varchar](max) NULL,
    [ActivityCd] [varchar](20) NULL,
    [ActivityName] [varchar](max) NULL,
    [SubActivityCd] [varchar](20) NULL,
    [SubActivityName] [varchar](max) NULL,
    [ProjectCd] [varchar](20) NULL,
    [ProjectName] [varchar](max) NULL,
    [VendorNo] [varchar](100) NULL,
    [VendorName] [varchar](max) NULL,
    [ExpendAccrued] [money] NULL
) 
GO






