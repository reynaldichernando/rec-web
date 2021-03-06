USE RecDB

GO
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
	SELECT ThreadID, trThread.UserID, Title, Content, [Name], [Role]
	FROM trThread JOIN msUser ON trThread.UserID = msUser.UserID 
END

go

CREATE PROC bn_RecDB_GetOneThread
@ThreadID int
AS
BEGIN
	SET NOCOUNT ON
	SELECT ThreadID, trThread.UserID, Title, Content, [Name], [Role]
	FROM trThread JOIN msUser ON trThread.UserID = msUser.UserID 
	WHERE ThreadID = @ThreadID
END

go
select * from trThread
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

alter PROC bn_RecDB_DeleteThread
@ThreadID int
as
begin
	delete from trPost
	where ThreadID = @ThreadID
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

exec bn_RecDB_InsertPost 4, 35, 'admin'
exec bn_RecDB_InsertPost 5, 35, 'approved'
select * from trPost

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

alter PROC bn_RecDB_UpdatePost
@PostID int,
@Content varchar(max)
as
begin
	update trPost
	set Content = @Content
	where PostID = @PostID
end

go
select * from trThread
select * from trPost

alter PROC bn_RecDB_DeletePost
@PostID int
as
begin
	delete from trPost
	where PostID = @PostID

end
go

CREATE PROC bn_RecDB_GetPostByID
@PostID int
AS
BEGIN
	SET NOCOUNT ON
	SELECT PostID, ThreadID, msUser.UserID, Content, [Name]
	FROM trPost JOIN msUser ON trPost.UserID = msUser.UserID
	WHERE PostID = @PostID
END

exec bn_RecDB_GetPostByID 3

go

select * from trThread

select * from trPost

INSERT INTO msUser VALUES ('Admin', 'admin@admin.com', '123', 'admin')
INSERT INTO msUser VALUES ('User', 'user@user.com', '123', 'approved')
INSERT INTO trThread VALUES (5, 'Not announcement', 'This is not an announcement'),
(4, 'Announcement', 'This is an announcement')

select * from trThread

select * from trPost
update msUser
set Role = 'approved'
where UserID = 5

select * from msUser