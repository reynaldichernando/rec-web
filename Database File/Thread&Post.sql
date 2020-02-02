CREATE PROC bn_RecDB_InsertThread
@UserID int,
@Title varchar(30),
@Content varchar(max)
as
begin
	insert into Thread (UserID,Title,Content) values(@UserID,@Title,@Content)
end

GO
CREATE PROC bn_RecDB_InsertPost
@UserID int,
@ThreadID int,
@Content varchar(max)
as
begin
	insert into Post values(@ThreadID,@UserID,@Content)
end