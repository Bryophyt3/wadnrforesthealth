SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tmpTreatmentsFromArcGis](
	[OBJECTID] [int] NULL,
	[PROJECT_NM] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GRANT_FUND_INFO] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TRT_LOCAL_ID] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UNIT_ID] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TRT_STATUS] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[COLLECT_DATE] [datetime2](7) NULL,
	[COLLECT_METH] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OWNER_NM] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FY] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[COMMENTS] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GIS_ACRES] [float] NULL,
	[CHIPPING] [float] NULL,
	[PRUNING] [float] NULL,
	[THINNING] [float] NULL,
	[MAST_MOW] [float] NULL,
	[GRAZING] [float] NULL,
	[LOP_SCATTER] [float] NULL,
	[BIOMASS_REM] [float] NULL,
	[HAND_PLE] [float] NULL,
	[BRN_BRD_CST] [float] NULL,
	[BRN_HAND_PLE] [float] NULL,
	[BRN_MACH_PLE] [float] NULL,
	[OTHER] [float] NULL,
	[ACT_CMP_DT] [datetime2](7) NULL,
	[CONTRACTOR] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CONTRACT_NUM] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TRT_SUM] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[created_user] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[created_date] [datetime2](7) NULL,
	[last_edited_user] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[last_edited_date] [datetime2](7) NULL,
	[GlobalID] [varchar](38) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SHAPE_Length] [float] NULL,
	[SHAPE_Area] [float] NULL,
	[GEOM] [geometry] NULL,
	[tmpTreatmentsFromArcGisID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tmpTreatmentsFromArcGis_tmpTreatmentsFromArcGisID] PRIMARY KEY CLUSTERED 
(
	[tmpTreatmentsFromArcGisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
