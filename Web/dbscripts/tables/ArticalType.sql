/****** Object:  Table [dbo].[ArticalType]    Script Date: 06/24/2013 19:59:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ArticalType](
	[ATId] [int] IDENTITY(1,1) NOT NULL,
	[ATName] [varchar](32) NULL,
	[ATDesc] [varchar](64) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_ARTICALTYPE] PRIMARY KEY CLUSTERED 
(
	[ATId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticalType'
GO

ALTER TABLE [dbo].[ArticalType] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[ArticalType] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

