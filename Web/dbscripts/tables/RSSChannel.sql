USE [syihy]
GO

/****** Object:  Table [dbo].[RSSChannel]    Script Date: 06/24/2013 20:01:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RSSChannel](
	[RCId] [int] IDENTITY(1,1) NOT NULL,
	[RSSId] [int] NULL,
	[RCTitle] [varchar](100) NULL,
	[RCLink] [varchar](200) NULL,
	[RCDescription] [varchar](100) NULL,
	[RCLanguage] [varchar](20) NULL,
	[RCGenerator] [varchar](20) NULL,
	[RCPubDate] [datetime] NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_RSSCHANNEL] PRIMARY KEY CLUSTERED 
(
	[RCId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'RSS频道' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSSChannel'
GO

ALTER TABLE [dbo].[RSSChannel] ADD  DEFAULT (getdate()) FOR [RCPubDate]
GO

ALTER TABLE [dbo].[RSSChannel] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[RSSChannel] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

