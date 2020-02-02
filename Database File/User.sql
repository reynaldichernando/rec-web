CREATE PROC bn_RecDB_GetUserLogin
@Email varchar(50),
@Password varchar(30)
as
BEGIN
	SELECT *
	FROM [User]
	where Email = @Email and [Password] = @Password
END

GO
create PROC bn_RecDB_UpdatePassword
@Email varchar(50),
@Password varchar(30)
as
begin
	update [User] set [Password] = @Password where Email = @Email
end

create proc bn_RecDB_RegisterUser
@Name varchar(50),
@Email varchar(50),
@Password varchar(50),
@Role varchar(10) = 'Recruitee'
as
begin
	insert into [User] values (@Name,@Email,@Password,@Role)
end