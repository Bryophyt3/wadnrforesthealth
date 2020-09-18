SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriorityLandscape](
	[PriorityLandscapeID] [int] NOT NULL,
	[PriorityLandscapeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PriorityLandscapeLocation] [geometry] NULL,
	[PriorityLandscapeDescription] [varchar](3000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_PriorityLandscape_PriorityLandscapeID] PRIMARY KEY CLUSTERED 
(
	[PriorityLandscapeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PriorityLandscape_PriorityLandscapeName] UNIQUE NONCLUSTERED 
(
	[PriorityLandscapeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
