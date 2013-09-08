
/****** Object:  Table [dbo].[ProxyAddress]    Script Date: 09/08/2013 09:48:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProxyAddress](
	[PAId] [int] IDENTITY(1,1) NOT NULL,
	[PAName] [varchar](32) NULL,
	[PAType] [varchar](8) NULL,
	[PAAnonymity] [varchar](8) NULL,
	[PACountry] [varchar](16) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_PROXYADDRESS] PRIMARY KEY CLUSTERED 
(
	[PAId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
