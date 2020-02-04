CREATE PROC bn_RecDB_InsertThread
@UserID int,
@Title varchar(30),
@Content varchar(max)
as
begin
	insert into trThread VALUES
	(@UserID,@Title,@Content)
end

go

CREATE PROC bn_RecDB_GetAllThread
AS
BEGIN
	SET NOCOUNT ON
	SELECT ThreadID, trThread.UserID, Title, Content, [Name]
	FROM trThread JOIN msUser ON trThread.UserID = msUser.UserID 
END

go

CREATE PROC bn_RecDB_GetOneThread
@ThreadID int
AS
BEGIN
	SET NOCOUNT ON
	SELECT ThreadID, trThread.UserID, Title, Content, [Name]
	FROM trThread JOIN msUser ON trThread.UserID = msUser.UserID 
	WHERE ThreadID = @ThreadID
END

go

CREATE PROC bn_RecDB_UpdateThread
@ThreadID int,
@Title varchar(30),
@Content varchar(max)
as
begin
	update trThread
	set Title = @Title,
	Content = @Content
	where ThreadID = @ThreadID
end

go

CREATE PROC bn_RecDB_DeleteThread
@ThreadID int
as
begin
	delete from trThread
	where ThreadID = @ThreadID
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

go

CREATE PROC bn_RecDB_GetPost
@ThreadID int
AS
BEGIN
	SET NOCOUNT ON
	SELECT PostID, ThreadID, msUser.UserID, Content, [Name]
	FROM trPost JOIN msUser ON trPost.UserID = msUser.UserID
	WHERE ThreadID = @ThreadID
END

go

CREATE PROC bn_RecDB_UpdatePost
@PostID int,
@Content varchar(max)
as
begin
	update trPost
	set Content = @Content
	where PostID = @PostID
end

go

CREATE PROC bn_RecDB_DeletePost
@PostID int
as
begin
	delete from trPost
	where PostID = @PostID
end
