
/****** Object:  Table [dbo].[AdCode]    Script Date: 07/07/2013 10:27:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AdCode](
	[AdCodeId] [int] IDENTITY(1,1) NOT NULL,
	[AdId] [int] NULL,
	[AdCodeCont] [varchar](1024) NULL,
	[AdCodeDesc] [varchar](128) NULL,
	[AdDefault] [char](1) NULL,
	[Status] [char](1) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_ADCODE] PRIMARY KEY CLUSTERED 
(
	[AdCodeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'广告代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdCode'
GO

ALTER TABLE [dbo].[AdCode] ADD  DEFAULT ('N') FOR [AdDefault]
GO

ALTER TABLE [dbo].[AdCode] ADD  DEFAULT ('A') FOR [Status]
GO

ALTER TABLE [dbo].[AdCode] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[AdCode] ADD  DEFAULT ('syihy.com') FOR [CreateBy]
GO

ALTER TABLE [dbo].[AdCode] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

ALTER TABLE [dbo].[AdCode] ADD  DEFAULT ('syihy.com') FOR [UpdateBy]
GO
