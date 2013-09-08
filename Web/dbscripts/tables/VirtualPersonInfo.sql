
/****** Object:  Table [dbo].[VirtualPersonInfo]    Script Date: 09/08/2013 15:37:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VirtualPersonInfo](
	[VPID] [int] IDENTITY(1,1) NOT NULL,
	[VPFullName] [varchar](32) NULL,
	[VPFirstName] [varchar](16) NULL,
	[VPMiddleName] [varchar](16) NULL,
	[VPLastName] [varchar](16) NULL,
	[VPSex] [varchar](8) NULL,
	[VPBirthday] [datetime] NULL,
	[VPMail] [varchar](64) NULL,
	[VPNickName] [varchar](64) NULL,
	[VPPassword] [varchar](32) NULL,
	[VPAge] [int] NULL,
	[VPCollege] [varchar](128) NULL,
	[VPOccupation] [varchar](64) NULL,
	[VPSsn] [varchar](16) NULL,
	[VPHeight] [int] NULL,
	[VPWeight] [int] NULL,
	[VPBloodType] [varchar](8) NULL,
	[VPState] [varchar](8) NULL,
	[VPCity] [varchar](16) NULL,
	[VPStreet] [varchar](32) NULL,
	[VPZip] [int] NULL,
	[VPPhone] [varchar](16) NULL,
	[VPVisa] [numeric](18, 0) NULL,
	[VPVisaExpirDate] [datetime] NULL,
	[VPCVV2] [int] NULL,
	[VPBank] [varchar](32) NULL,
	[VPRoutingNumber] [numeric](18, 0) NULL,
	[VPBankAcct] [numeric](18, 0) NULL,
	[VPMasterCard] [numeric](18, 0) NULL,
	[VPMExpirDate] [datetime] NULL,
	[VPMCVC2] [int] NULL,
	[VPSite] [varchar](32) NULL,
	[VPNationality] [varchar](32) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [varchar](64) NULL,
	[UpdateDT] [datetime] NULL,
	[UpdateBy] [varchar](64) NULL,
 CONSTRAINT [PK_VIRTUALPERSONINFO] PRIMARY KEY CLUSTERED 
(
	[VPID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'全名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPFullName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPFirstName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中间名字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPMiddleName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPLastName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPSex'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPBirthday'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPMail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPNickName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPPassword'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年龄' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPAge'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'毕业院校' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPCollege'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职业' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPOccupation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'社会保险号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPSsn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身高' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPHeight'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'体重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPWeight'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'血型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPBloodType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'美国州' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPState'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPCity'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'街道' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPStreet'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮编' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPZip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPPhone'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Visa信用卡' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPVisa'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPVisaExpirDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CVV2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPCVV2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPBank'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行账户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPBankAcct'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPMExpirDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'个人网站' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPSite'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' 国籍' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo', @level2type=N'COLUMN',@level2name=N'VPNationality'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'虚拟人物' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VirtualPersonInfo'
GO

ALTER TABLE [dbo].[VirtualPersonInfo] ADD  DEFAULT ('male') FOR [VPSex]
GO

ALTER TABLE [dbo].[VirtualPersonInfo] ADD  DEFAULT ((175)) FOR [VPHeight]
GO

ALTER TABLE [dbo].[VirtualPersonInfo] ADD  DEFAULT ((65)) FOR [VPWeight]
GO

ALTER TABLE [dbo].[VirtualPersonInfo] ADD  DEFAULT ('CA') FOR [VPState]
GO

ALTER TABLE [dbo].[VirtualPersonInfo] ADD  DEFAULT ('La Mesa') FOR [VPCity]
GO

ALTER TABLE [dbo].[VirtualPersonInfo] ADD  DEFAULT ('7481 Mohawk St') FOR [VPStreet]
GO

ALTER TABLE [dbo].[VirtualPersonInfo] ADD  DEFAULT ((91941)) FOR [VPZip]
GO

ALTER TABLE [dbo].[VirtualPersonInfo] ADD  DEFAULT ('United States') FOR [VPNationality]
GO

ALTER TABLE [dbo].[VirtualPersonInfo] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[VirtualPersonInfo] ADD  DEFAULT (getdate()) FOR [UpdateDT]
GO
