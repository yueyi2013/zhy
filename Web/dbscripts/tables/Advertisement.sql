
/****** Object:  Table [dbo].[Advertisement]    Script Date: 07/06/2013 20:41:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Advertisement](
	[AdId] [int] IDENTITY(1,1) NOT NULL,
	[AdLogo] [varchar](512) NULL,
	[AdName] [varchar](200) NULL,
	[AdCategoryId] [int] NULL,
	[AdBgCode] [varchar](64) NULL,
	[AdUnitPrice] [decimal](4, 2) NULL,
	[AdUnit] [varchar](32) NULL,
	[AdBillingCycle] [varchar](64) NULL,
	[AdSource] [varchar](128) NULL,
	[AdCode] [varchar](1024) NULL,
	[AdDesc] [varchar](512) NULL,
	[Status] [char](1) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_ADVERTISEMENT] PRIMARY KEY CLUSTERED 
(
	[AdId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'广告' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Advertisement'
GO

ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT ('A') FOR [Status]
GO

ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT ('syihy.com') FOR [CreateBy]
GO

ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT ('syihy.com') FOR [UpdateBy]
GO

