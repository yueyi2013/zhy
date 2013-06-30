/****** Object:  Table [dbo].[Menus]    Script Date: 06/30/2013 10:52:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Menus](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [varchar](128) NULL,
	[MenuDes] [varchar](256) NULL,
	[MenuPicPath] [varchar](256) NULL,
	[ParantID] [int] NULL,
	[MenuOrder] [int] NULL,
	[FunID] [int] NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF__Menus__ParantID__7D78A4E7]  DEFAULT ((0)) FOR [ParantID]
GO

ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF_Menus_CreateAt]  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF_Menus_CreateBy]  DEFAULT ('syihy.com') FOR [CreateBy]
GO

ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF_Menus_UpdateDT]  DEFAULT (getdate()) FOR [UpdateDT]
GO

ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF_Menus_UpdateBy]  DEFAULT ('syihy.com') FOR [UpdateBy]
GO


