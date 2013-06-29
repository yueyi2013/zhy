/****** Object:  Table [dbo].[QRTZ_LOCKS]    Script Date: 06/24/2013 19:57:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QRTZ_LOCKS](
	[SCHED_NAME] [nvarchar](100) NOT NULL,
	[LOCK_NAME] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_QRTZ_LOCKS] PRIMARY KEY CLUSTERED 
(
	[SCHED_NAME] ASC,
	[LOCK_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

