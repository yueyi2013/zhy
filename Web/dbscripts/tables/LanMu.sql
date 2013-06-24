USE [syihy]
GO

/****** Object:  Table [dbo].[LanMu]    Script Date: 06/24/2013 20:00:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LanMu](
	[LMID] [int] IDENTITY(1,1) NOT NULL,
	[LMCode] [varchar](128) NULL,
	[ParantID] [int] NULL,
	[LMName] [varchar](128) NULL,
	[LMOrder] [int] NULL,
	[LMStyleID] [int] NULL,
	[LMPage] [varchar](128) NULL,
	[LMStatus] [char](1) NULL,
	[LMDes] [varchar](256) NULL,
 CONSTRAINT [PK_LANMU] PRIMARY KEY CLUSTERED 
(
	[LMID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[LanMu] ADD  DEFAULT ((0)) FOR [ParantID]
GO

ALTER TABLE [dbo].[LanMu] ADD  DEFAULT ('1') FOR [LMStatus]
GO

