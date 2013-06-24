USE [syihy]
GO

/****** Object:  StoredProcedure [dbo].[GetLeftMenu]    Script Date: 06/24/2013 19:51:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetLeftMenu]
	-- Add the parameters for the stored procedure here
	@RoleId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT MenuID,MenuName,FunPage,ParantID,MenuPicPath from RightConfig rc
	left join Functions fun on rc.FunID = fun.FunID 
	left join Menus mu on fun.FunID = mu.FunID
	where RoleID = @RoleId
    order by MenuOrder;
END





GO

