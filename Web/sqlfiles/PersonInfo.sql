if exists (select 1
            from  sysobjects
           where  id = object_id('PersonInfo')
            and   type = 'U')
   drop table PersonInfo
go

/*==============================================================*/
/* Table: PersonInfo                                            */
/*==============================================================*/
create table PersonInfo (
   PsnId                numeric              identity,
   PsnTypeId            int                  null,
   PsnNickName          varchar(30)          null,
   PsnIsMarried         char(1)              null default '‘N’',
   PsnHeadPic           varchar(64)          null,
   PsnRealName          varchar(64)          null,
   "PsnSex 性别"          char(1)              null default '0',
   PsnBirthday          datetime             null default getdate(),
   PsnConstellation     varchar(30)          null,
   PsnCellPhone         int                  null,
   PsnPhone             varchar(12)          null,
   PsnAddress           varchar(120)         null,
   PsnAtProvince        varchar(10)          null,
   PsnAtCity            varchar(10)          null,
   PsnQQ                int                  null,
   PsnJob               varchar(30)          null,
   PsnWorkUnit          varchar(64)          null,
   PsnBackUpMail        varchar(30)          null,
   CreateAt             datetime             null default getdate(),
   CreateBy             varchar(64)          null default '‘syihy.com’',
   UpdateDT             datetime             null default getdate(),
   UpdateBy             varchar(64)          null default '‘syihy.com’',
   constraint PK_PERSONINFO primary key (PsnId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '人员信息',
   'user', @CurrentUser, 'table', 'PersonInfo'
go
