/****** Object:  Table [dbo].[Users]    Script Date: 06/24/2013 20:01:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](64) NULL,
	[UserPsw] [varchar](32) NULL,
	[UserMedium] [varchar](512) NULL,
	[UserUnitTel] [varchar](32) NULL,
	[UserShotNum] [varchar](16) NULL,
	[UserMobile] [varchar](16) NULL,
	[UserRealName] [varchar](80) NULL,
	[RoleID] [int] NULL,
	[UserStatus] [char](1) NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT ('1') FOR [UserStatus]
GO

