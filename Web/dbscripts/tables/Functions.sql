USE [syihy]
GO

/****** Object:  Table [dbo].[Functions]    Script Date: 06/24/2013 20:00:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Functions](
	[FunID] [int] IDENTITY(1,1) NOT NULL,
	[FunCode] [varchar](128) NULL,
	[FunName] [varchar](256) NULL,
	[FunPage] [varchar](128) NULL,
	[FunDes] [varchar](512) NULL,
 CONSTRAINT [PK_Functions] PRIMARY KEY CLUSTERED 
(
	[FunID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

