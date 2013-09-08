
/****** Object:  Table [dbo].[VirtualSite]    Script Date: 09/08/2013 18:45:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VirtualSite](
	[VSId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[VSCode] [varchar](16) NULL,
	[VSName] [varchar](32) NULL,
	[VSURL] [varchar](128) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_VIRTUALSITE] PRIMARY KEY CLUSTERED 
(
	[VSId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网站编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualSite', @level2type=N'COLUMN',@level2name=N'VSId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网站编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualSite', @level2type=N'COLUMN',@level2name=N'VSCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网站名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualSite', @level2type=N'COLUMN',@level2name=N'VSName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualSite', @level2type=N'COLUMN',@level2name=N'VSURL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网站' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualSite'
GO

ALTER TABLE [dbo].[VirtualSite] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[VirtualSite] ADD  DEFAULT ('syihy.com') FOR [CreateBy]
GO

ALTER TABLE [dbo].[VirtualSite] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

ALTER TABLE [dbo].[VirtualSite] ADD  DEFAULT ('syihy.com') FOR [UpdateBy]
GO
