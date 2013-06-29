/****** Object:  Table [dbo].[Members]    Script Date: 06/24/2013 20:02:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Members](
	[MemID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MemAccount] [varchar](64) NULL,
	[MemPsw] [varchar](64) NULL,
	[PsnLevelId] [int] NULL,
	[MemMail] [varchar](64) NULL,
	[MemStatus] [char](1) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_MEMBERS] PRIMARY KEY CLUSTERED 
(
	[MemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'I-nactive,A-ctive' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'MemStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员维护' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members'
GO

ALTER TABLE [dbo].[Members] ADD  DEFAULT ('123456789') FOR [MemPsw]
GO

ALTER TABLE [dbo].[Members] ADD  DEFAULT ('I') FOR [MemStatus]
GO

ALTER TABLE [dbo].[Members] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[Members] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO

