/****** Object:  Table [dbo].[MemberMenu]    Script Date: 06/24/2013 20:02:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MemberMenu](
	[MMId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MMName] [varchar](64) NULL,
	[MMOrder] [int] NULL,
	[MMPicPath] [varchar](128) NULL,
	[MMDesc] [varchar](128) NULL,
	[MMStatus] [char](1) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_MEMBERMENU] PRIMARY KEY CLUSTERED 
(
	[MMId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员菜单栏' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberMenu'
GO

ALTER TABLE [dbo].[MemberMenu] ADD  DEFAULT ((1)) FOR [MMOrder]
GO

ALTER TABLE [dbo].[MemberMenu] ADD  DEFAULT ('A') FOR [MMStatus]
GO

ALTER TABLE [dbo].[MemberMenu] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[MemberMenu] ADD  DEFAULT ('‘syihy.com’') FOR [CreateBy]
GO

ALTER TABLE [dbo].[MemberMenu] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

ALTER TABLE [dbo].[MemberMenu] ADD  DEFAULT ('‘syihy.com’') FOR [UpdateBy]
GO

