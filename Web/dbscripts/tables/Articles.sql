USE [syihy]
GO

/****** Object:  Table [dbo].[Articles]    Script Date: 06/24/2013 19:59:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Articles](
	[ArId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ArTitle] [varchar](200) NULL,
	[ACId] [int] NULL,
	[ArTypeId] [int] NULL,
	[ArContent] [varchar](max) NULL,
	[ArAuthor] [char](32) NULL,
	[ArPubDate] [datetime] NULL,
	[ArClicks] [int] NULL,
	[ArCmtNumber] [int] NULL,
	[ArRecommend] [char](1) NULL,
	[ArIsTop] [char](1) NULL,
	[ArForbidComt] [char](1) NULL,
	[ArStatus] [char](1) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_ARTICLES] PRIMARY KEY CLUSTERED 
(
	[ArId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Y-es,N-o' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'ArIsTop'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Y-es,N-o' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'ArForbidComt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布文章' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles'
GO

ALTER TABLE [dbo].[Articles] ADD  DEFAULT (getdate()) FOR [ArPubDate]
GO

ALTER TABLE [dbo].[Articles] ADD  DEFAULT ((0)) FOR [ArClicks]
GO

ALTER TABLE [dbo].[Articles] ADD  DEFAULT ((0)) FOR [ArCmtNumber]
GO

ALTER TABLE [dbo].[Articles] ADD  DEFAULT ('N') FOR [ArRecommend]
GO

ALTER TABLE [dbo].[Articles] ADD  DEFAULT ('N') FOR [ArIsTop]
GO

ALTER TABLE [dbo].[Articles] ADD  DEFAULT ('N') FOR [ArForbidComt]
GO

ALTER TABLE [dbo].[Articles] ADD  DEFAULT ('A') FOR [ArStatus]
GO

ALTER TABLE [dbo].[Articles] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[Articles] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

