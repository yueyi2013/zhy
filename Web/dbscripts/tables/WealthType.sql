if exists (select 1
            from  sysobjects
           where  id = object_id('WealthType')
            and   type = 'U')
   drop table WealthType
go

/*==============================================================*/
/* Table: WealthType                                            */
/*==============================================================*/
create table WealthType (
   WTId                 numeric              identity,
   WTName               varchar(64)          null,
   WTPicPath            varchar(150)         null,
   CreateAt             datetime             null default getdate(),
   CreateBy             varchar(64)          null,
   UpdateDT             datetime             null default getdate(),
   UpdateBy             varchar(64)          null,
   constraint PK_WEALTHTYPE primary key (WTId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '财富类型',
   'user', @CurrentUser, 'table', 'WealthType'
go
