--USE master
--GO
--DROP DATABASE RecDB

create database RecDB
GO
use RecDB

GO
create table [msUser](
	UserID INT PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(50),
	Email varchar(50),
	[Password] varchar(50),
	[Role] varchar(10) CHECK([Role] IN ('approved', 'unapproved', 'admin')) DEFAULT('unapproved')
)

GO
create table msAssignment(
	AssignmentID int primary key identity(1,1),
	Title varchar(30),
	DateDue datetime,
	DateUploaded datetime default(GETDATE()),
	[Description] varchar(max),
	AssignmentFilepath varchar(MAX)
)

GO
create table trAnswer(
	AnswerID int primary key identity(1,1),
	UserID int REFERENCES [msUser](UserID),
	AssignmentID int REFERENCES msAssignment(AssignmentID),
	AnswerFilepath varchar(MAX),
	DateUploaded datetime default(GETDATE())
)

GO
create table trThread(
	ThreadID int primary key identity(1,1),
	UserID int REFERENCES [msUser](UserID),
	Title varchar(20),
	Content varchar(MAX)
)

GO
create table trPost(
	PostID int primary key identity(1,1),
	ThreadID int REFERENCES trThread(ThreadID),
	UserID int REFERENCES [msUser](UserID),
	Content varchar(MAX)
)

GO
create table msSchedule(
	ScheduleID int primary key identity(1,1),
	[StartTime] datetime,
	[EndTime] datetime,
	Place varchar(20),
	Topic varchar(30),
	[Description] varchar(max)
)
