if exists (select 1
            from  sysobjects
           where  id = object_id('PersonType')
            and   type = 'U')
   drop table PersonType
go

/*==============================================================*/
/* Table: PersonType                                            */
/*==============================================================*/
create table PersonType (
   PsnTypeId            int                  identity,
   PsnTypeName          varchar(30)          null,
   PsnTypeDesc          varchar(64)          null,
   CreateAt             datetime             null default getdate(),
   CreateBy             varchar(64)          null default 'syihy.com',
   UpdateDT             datetime             null default getdate(),
   UpdateBy             varchar(64)          null default 'syihy.com',
   constraint PK_PERSONTYPE primary key (PsnTypeId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '人员类别',
   'user', @CurrentUser, 'table', 'PersonType'
go