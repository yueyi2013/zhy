/****** Object:  Table [dbo].[SiteFlash]    Script Date: 06/30/2013 12:13:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SiteFlash](
	[SFId] [int] IDENTITY(1,1) NOT NULL,
	[SFPicPath] [varchar](200) NULL,
	[SFDetailsURL] [varchar](200) NULL,
	[SFConTitle] [varchar](200) NULL,
	[SFOrder] [int] NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_SITEFLASH] PRIMARY KEY CLUSTERED 
(
	[SFId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ÍøÕ¾¶¯»­' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SiteFlash'
GO

ALTER TABLE [dbo].[SiteFlash] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[SiteFlash] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO


