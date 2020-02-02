CREATE PROC bn_RecDB_InsertThread
@UserID int,
@Title varchar(30),
@Content varchar(max)
as
begin
	insert into trThread VALUES
	(@UserID,@Title,@Content)
end

GO
CREATE PROC bn_RecDB_InsertPost
@UserID int,
@ThreadID int,
@Content varchar(max)
as
begin
	insert into trPost values
	(@ThreadID,@UserID,@Content)
end