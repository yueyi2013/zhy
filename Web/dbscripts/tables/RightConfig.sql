/****** Object:  Table [dbo].[RightConfig]    Script Date: 06/24/2013 20:02:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RightConfig](
	[RiCId] [int] IDENTITY(1,1) NOT NULL,
	[FunID] [int] NULL,
	[RoleID] [int] NULL,
	[RiCIdStatus] [char](1) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_RIGHTCONFIG] PRIMARY KEY CLUSTERED 
(
	[RiCId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限配置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RightConfig'
GO

ALTER TABLE [dbo].[RightConfig] ADD  DEFAULT ('A') FOR [RiCIdStatus]
GO

ALTER TABLE [dbo].[RightConfig] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[RightConfig] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

