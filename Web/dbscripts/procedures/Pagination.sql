USE [syihy]
GO

/****** Object:  StoredProcedure [dbo].[Pagination]    Script Date: 06/24/2013 19:53:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Batch submitted through debugger: SQLQuery1.sql|7|0|C:\Documents and Settings\Administrator\Local Settings\Temp\~vs8FE.sql
CREATE   procedure   [dbo].[Pagination]
 @tablename   varchar ( 200 ) ,    -- 表名 
 @strGetFields   varchar (800)  =   ' * ' ,   -- 查询列名 
 @PageIndex   int   =   1  ,          -- 页码 
 @pageSize   int   =   15 ,          -- 页面大小 
 @strWhere    varchar ( 100 )  =   '' ,      -- 查询条件 
 @strOrder   varchar ( 100 )  =   '' ,  -- 排序列名 
 @intOrder   bit =  0 ,         -- 排序类型  1为升序 
 @CountAll   bigint  output               -- 返回纪录总数用于计算页面数     
 as 
 begin 
 declare   @strSql   varchar (1000)   -- 主语句 
 declare   @strTemp   varchar (100)  -- 临时变量 
 declare   @strOrders   varchar (50)  -- 排序语句 
 declare   @table   varchar (70)
 declare     @SQL     nvarchar (1000)
 declare     @R   bigint 
declare   @strChar varchar ( 100 )  --处理a.LMId取.右边的字符
 declare  @len int

 set @len=CHARINDEX('.',@strOrder)+1
 if(@len!=0)
	begin
		set @strChar = SUBSTRING(@strOrder,@len,datalength(@strOrder)-@len+1)
	end
 else
   begin
		set @strChar = @strOrder
   end
print @strChar

if @strWhere !=''
	begin
		set     @SQL = N' select @R=count(*)  from  '+convert(nvarchar(200), @TableName)+'  where  ' +@strWhere
	end 
 else
	begin
		set     @SQL = N' select @R=count(*)  from  '+convert(nvarchar(200), @TableName)
	end

 exec   SP_EXECUTESQL    @SQL ,  N'  @R  BIGINT  OUTPUT ' ,@R  OUTPUT

 set     @CountAll = @R 

 if @intOrder = 0 

 begin 
     -- 为0是升序 
      set   @strTemp   =   ' >(select max ' 
     set   @strOrders   =    '  order by   ' + @strOrder + '  asc  ' 
 end 
 else 
 begin 
     -- 否则为降序 
      set   @strTemp   =   ' <(select min ' 
     set   @strOrders   =   '  order by   ' + @strOrder + '  desc  ' 
 end 
 if   @PageIndex   = 1          -- 第一页直接读出纪录 
 begin 
     if @strWhere = '' 
     begin 
          set   @strSql   =   ' select top  ' + str ( @pageSize ) + '   ' + @strGetFields + '  from  ' + @tablename + '   ' + @strOrders 
      end 
     else   
     begin 
          set   @strSql   =   ' select top  ' + str ( @pageSize ) + '   ' + @strGetFields +   '  from  ' + @tablename + '  where  ' + @strWhere + '   ' + @strOrders 
    
     end 
 end 
 else 
 begin 
     set   @strSql   =   ' select top ' + str ( @pageSize ) + '   ' + @strGetFields + '  from  ' + @tablename + '  where  ' + @strOrder + '   ' + @strTemp + '  ( ' + @strChar + ' ) ' 
                   + '  from (select top  ' + str (( @pageIndex - 1 ) * @pageSize ) + '   ' + @strGetFields + '  from  ' + @tablename +   '   ' + @strOrders +   ' ) as tempTable )  ' + @strOrders 
         
     if   @strWhere   !=   '   ' 
     begin 
        set   @strSql   =   ' select top  ' + str ( @pageSize ) +   '   ' + @strGetFields + '  from  ' + @tablename +   '  where  ' + @strOrder +   '   ' + @strTemp + '  ( ' + @strChar + ' )  ' 
                    + '  from (select top  ' + str (( @pageIndex - 1 ) * @pageSize ) + '   ' + @strGetFields + '  from  ' + @tablename + '  where  ' + @strWhere + '   '   + @strOrders + ' ) as tempTable)  and ' + @strWhere + '   ' + @strOrders 
   
     end 
 end  
 exec ( @strSql ) 
 end 











GO

