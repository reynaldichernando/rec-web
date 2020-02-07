USE RecDB
GO
CREATE PROC bn_RecDB_GetUserLogin
@Email VARCHAR(50),
@Password varchar(250)
as
BEGIN
	SELECT *
	FROM [msUser]
	where Email = @Email
	AND [Password] = @Password
	AND [Role] IN ('approved', 'admin')
END

GO
CREATE PROC bn_RecDB_UpdatePassword
@Email varchar(50),
@Password varchar(150)
as
begin
	update [msUser] set [Password] = @Password
	where Email = @Email
end

GO
CREATE PROC bn_RecDB_RegisterUser
@Name varchar(50),
@Email varchar(50),
@Password varchar(250)
as
begin
	insert into [msUser](Name,Email,Password) values (@Name,@Email,@Password)
end

GO
create proc bn_RecDB_GetUnapprovedUser
as
begin
	select * from msUser where Role = 'unapproved'
end

GO
CREATE proc bn_RecDB_InsertUserToken
@Email varchar(50),
@Token varchar(50)
as
begin
	update msUser set Token = @Token where Email=@Email
end

GO
create proc bn_RecDB_GetUserToken
@Email varchar(50)
as
begin
	select Token from msUser where Email=@Email
end

go
CREATE proc bn_RecDB_DeleteUserToken
@Email varchar(50)
as
begin
	update msUser set Token=null where Email=@Email
end


