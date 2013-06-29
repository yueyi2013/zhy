/****** Object:  Table [dbo].[NewsTop]    Script Date: 06/24/2013 20:03:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[NewsTop](
	[NTId] [numeric](18, 0) NOT NULL,
	[NTTitle] [varchar](200) NULL,
	[NTAuthor] [varchar](10) NULL,
	[NTPubDate] [datetime] NULL,
	[NTContent] [varchar](max) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_NewsTop] PRIMARY KEY CLUSTERED 
(
	[NTId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新闻TOP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NewsTop'
GO

ALTER TABLE [dbo].[NewsTop] ADD  CONSTRAINT [DF__NewsTop__NTPubDa__3D2915A8]  DEFAULT (getdate()) FOR [NTPubDate]
GO

ALTER TABLE [dbo].[NewsTop] ADD  CONSTRAINT [DF__NewsTop__CreateA__3E1D39E1]  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[NewsTop] ADD  CONSTRAINT [DF__NewsTop__UpdateD__3F115E1A]  DEFAULT (getdate()) FOR [UpdateDT]
GO

