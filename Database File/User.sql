alter PROC bn_RecDB_GetUserLogin 'dsa@dsa.com','8FC93F70B750B3BBF9D8DD693676A89ABBAA76169E0448079D7C66DE9A0FE53F06F5DB0EC965BA9787544B5845477EBF2998D793E6CB80E18AB105D26CA85282'
@Email varchar(50),
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
alter PROC bn_RecDB_UpdatePassword
@Email varchar(50),
@Password varchar(150)
as
begin
	update [msUser] set [Password] = @Password
	where Email = @Email
end

GO
alter PROC bn_RecDB_RegisterUser 'name','cs@cs.com','55E98C1345D7A43A777A12843E8A0962EB6C33002BF27CB9284760128F31BC12242831EA696634B20ECC6852AB9337177F12C0386D2CB3A39737561994A944DB'

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
alter proc bn_RecDB_InsertUserToken 'dsa@dsa.com','test'
@Email varchar(50),
@Token varchar(50)
as
begin
	update msUser set Token = @Token where Email=@Email
end
GO
create proc bn_RecDB_GetUserToken 'dsa@dsa.com'
@Email varchar(50)
as
begin
	select Token from msUser where Email=@Email
end

go
alter proc bn_RecDB_DeleteUserToken'dsa@dsa.com'
@Email varchar(50)
as
begin
	update msUser set Token=null where Email=@Email
end

use recDB
select * from msUser


delete from msUser where Password is null
update msUser set Role='approved'
update msUser set Role='admin'


