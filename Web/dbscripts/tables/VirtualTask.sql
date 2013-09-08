
/****** Object:  Table [dbo].[VirtualTask]    Script Date: 09/08/2013 18:45:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VirtualTask](
	[VTId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[VTUserName] [varchar](32) NOT NULL,
	[VTPassword] [varchar](32) NOT NULL,
	[VTProxy] [varchar](32) NULL,
	[VSCode] [varchar](16) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_VIRTUALTASK] PRIMARY KEY CLUSTERED 
(
	[VTId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualTask', @level2type=N'COLUMN',@level2name=N'VTId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualTask', @level2type=N'COLUMN',@level2name=N'VTUserName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualTask', @level2type=N'COLUMN',@level2name=N'VTPassword'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代理地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualTask', @level2type=N'COLUMN',@level2name=N'VTProxy'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网站编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualTask', @level2type=N'COLUMN',@level2name=N'VSCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'虚拟任务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualTask'
GO

ALTER TABLE [dbo].[VirtualTask] ADD  DEFAULT ('61.175.223.139:3128') FOR [VTProxy]
GO

ALTER TABLE [dbo].[VirtualTask] ADD  DEFAULT ('ONE') FOR [VSCode]
GO

ALTER TABLE [dbo].[VirtualTask] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[VirtualTask] ADD  DEFAULT ('syihy.com') FOR [CreateBy]
GO

ALTER TABLE [dbo].[VirtualTask] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

ALTER TABLE [dbo].[VirtualTask] ADD  DEFAULT ('syihy.com') FOR [UpdateBy]
GO


