USE [syihy]
GO

/****** Object:  Table [dbo].[ArticleComments]    Script Date: 06/24/2013 19:59:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ArticleComments](
	[ACMId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ArId] [numeric](18, 0) NULL,
	[ACMContent] [varchar](1024) NULL,
	[ACMDate] [datetime] NULL,
	[ACMTop] [int] NULL,
	[ACMDown] [int] NULL,
	[ACMCmtPsn] [varchar](64) NULL,
	[ACMStatus] [char](1) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_ARTICLECOMMENTS] PRIMARY KEY CLUSTERED 
(
	[ACMId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章评论' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleComments'
GO

ALTER TABLE [dbo].[ArticleComments] ADD  DEFAULT (getdate()) FOR [ACMDate]
GO

ALTER TABLE [dbo].[ArticleComments] ADD  DEFAULT ((0)) FOR [ACMTop]
GO

ALTER TABLE [dbo].[ArticleComments] ADD  DEFAULT ((0)) FOR [ACMDown]
GO

ALTER TABLE [dbo].[ArticleComments] ADD  DEFAULT ('A') FOR [ACMStatus]
GO

ALTER TABLE [dbo].[ArticleComments] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[ArticleComments] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

