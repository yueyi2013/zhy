/****** Object:  Table [dbo].[SystemMail]    Script Date: 06/24/2013 20:01:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SystemMail](
	[SMId] [int] IDENTITY(1,1) NOT NULL,
	[SMHost] [varchar](32) NULL,
	[SMTimeout] [int] NULL,
	[SMFromAddress] [varchar](64) NULL,
	[SMOrder] [int] NULL,
	[SMMailPsw] [varchar](64) NULL,
	[SMStatus] [char](1) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_SYSTEMMAIL] PRIMARY KEY CLUSTERED 
(
	[SMId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMail'
GO

ALTER TABLE [dbo].[SystemMail] ADD  DEFAULT ((0)) FOR [SMOrder]
GO

ALTER TABLE [dbo].[SystemMail] ADD  DEFAULT ('A') FOR [SMStatus]
GO

ALTER TABLE [dbo].[SystemMail] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[SystemMail] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

