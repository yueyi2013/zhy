CREATE PROCEDURE GetLeftMenu
	@RoleId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT MenuID,MenuName,FunPage,ParantID,MenuPicPath from RightConfig rc
	left join Functions fun on rc.FunID = fun.FunID 
	left join Menus mu on fun.FunID = mu.FunID
	where RoleID = @RoleId
    order by MenuOrder;
END