﻿
/****** Object:  Table [dbo].[AdCategory]    Script Date: 07/06/2013 19:32:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AdCategory](
	[AdCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[AdCategoryName] [varchar](64) NULL,
	[AdCategoryDesc] [varchar](128) NULL,
	[Status] [char](1) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_ADCATEGORY] PRIMARY KEY CLUSTERED 
(
	[AdCategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'广告分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdCategory'
GO

ALTER TABLE [dbo].[AdCategory] ADD  DEFAULT ('A') FOR [Status]
GO

ALTER TABLE [dbo].[AdCategory] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[AdCategory] ADD  DEFAULT ('syihy.com') FOR [CreateBy]
GO

ALTER TABLE [dbo].[AdCategory] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

ALTER TABLE [dbo].[AdCategory] ADD  DEFAULT ('syihy.com') FOR [UpdateBy]
GO