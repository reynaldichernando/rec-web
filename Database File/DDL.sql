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
