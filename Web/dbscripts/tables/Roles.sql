/****** Object:  Table [dbo].[Roles]    Script Date: 06/30/2013 09:42:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](128) NULL,
	[RoleDes] [varchar](256) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_ROLES] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_CreateAt]  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_UpdateDT]  DEFAULT (getdate()) FOR [UpdateDT]
GO


