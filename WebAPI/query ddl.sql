--use master
--GO
--drop database RecDB

create database RecDB
GO
use RecDB

GO
create table [User](
	UserID INT PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50),
	Email varchar(50),
	[Password] varchar(50),
	[Role] varchar(10)
)

GO
create table Assignment(
	AssignmentID int primary key identity(1,1),
	Title varchar(30),
	Duedate datetime,
	DateUploaded datetime default(GETDATE()),
	[Description] varchar(max),
	AssignmentFilepath varchar(50)
)

GO
create table Answer(
	AnswerID int primary key identity(1,1),
	UserID int REFERENCES [User](UserID),
	AssignmentID int REFERENCES Assignment(AssignmentID),
	AnswerFilepath varchar(50),
	DateUploaded datetime default(GETDATE())
)

GO
create table Thread(
	ThreadID int primary key identity(1,1),
	UserID int REFERENCES [User](UserID),
	Title varchar(20),
	Content varchar(MAX),
	isPinned smallint default(0)
)

GO
create table Post(
	PostID int primary key identity(1,1),
	ThreadID int REFERENCES Thread(ThreadID),
	UserID int REFERENCES [User](UserID),
	Content varchar(MAX)
)

GO
create table Schedule(
	ScheduleID int primary key identity(1,1),
	[StartTime] datetime,
	[EndTime] datetime,
	Place varchar(20),
	Topic varchar(30),
	[Description] varchar(max)
)

select * from Schedule

--INSERT INTO Schedule VALUES
--('2020-01-20 20:59:59.999', '2020-01-21 20:59:59.999', 'Sunib bruh', 'Test test', 'This is test'),
--('2020-02-20 23:59:59.999', '2020-02-22 01:59:59.999', 'Curhat Sunib', 'Test test 2', 'This is da test')

GO
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

GO
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

GO
create proc bn_RecDB_InsertSchedule
@StartTime datetime,
@EndTime datetime,
@Place varchar(30),
@Topic varchar(30),
@Description varchar(max)
as
begin
	insert into Schedule (StartTime,EndTime,Place,Topic,[Description]) values(@StartTime,@EndTime,@Place,@Topic,@Description)
end

insert into [User] values('name','email','password','admin')

select * from [User]


--GO
--DROP proc bn_RecDB_GetUserLoginTest
--@Username varchar(30),
--@Password varchar(30)
--as
--begin
--	select 'usernameSukses: '+@Username,'passwordSukses: '+@Password
--end

GO
INSERT INTO [User] VALUES
('Reynaldi', 'reynaldi@chernando.com', 'chernando', 'admin')