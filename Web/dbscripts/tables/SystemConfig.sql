/****** Object:  Table [dbo].[SystemConfig]    Script Date: 06/24/2013 20:01:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SystemConfig](
	[SCId] [int] IDENTITY(1,1) NOT NULL,
	[SCAttrName] [varchar](10) NULL,
	[SCGroup] [varchar](20) NULL,
	[SCAttrValue] [varchar](20) NULL,
	[SCAttrValue2] [varchar](20) NULL,
	[SCAttrType] [varchar](10) NULL,
	[SCDescription] [varchar](50) NULL,
	[SCStatus] [char](1) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_SYSTEMCONFIG] PRIMARY KEY CLUSTERED 
(
	[SCId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SystemConfig] ADD  DEFAULT ('A') FOR [SCStatus]
GO

ALTER TABLE [dbo].[SystemConfig] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[SystemConfig] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

