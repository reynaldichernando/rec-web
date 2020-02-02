ALTER PROC bn_RecDB_GetUserLogin
@Email varchar(50),
@Password varchar(30)
as
BEGIN
	SELECT *
	FROM [msUser]
	where Email = @Email
	AND [Password] = @Password
	--AND [Role] IN ('approved', 'admin')
END

GO
create PROC bn_RecDB_UpdatePassword
@Email varchar(50),
@Password varchar(50)
as
begin
	update [msUser] set [Password] = @Password
	where Email = @Email
end

GO
CREATE PROC bn_RecDB_RegisterUser
@Name varchar(50),
@Email varchar(50),
@Password varchar(50),
@Role varchar(10) = 'unapproved'
as
begin
	insert into [msUser] values (@Name,@Email,@Password,@Role)
end
