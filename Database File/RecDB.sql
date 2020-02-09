--Uncomment to drop databASe
/*USE master
GO
DROP DATABASE RecDB*/

CREATE DATABASE RecDB
GO
USE RecDB

GO
CREATE TABLE [msUser](
	UserID INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50),
	Email VARCHAR(50),
	[Password] VARCHAR(250),
	[Role] VARCHAR(10) CHECK([Role] IN ('approved', 'unapproved', 'admin')) DEFAULT('unapproved'),
	Token VARCHAR(50)
)

GO
CREATE TABLE msAssignment(
	AssignmentID INT PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(30),
	DateDue DATETIME,
	DateUploaded DATETIME DEFAULT(GETDate()),
	[Description] VARCHAR(MAX),
	AssignmentFilepath VARCHAR(MAX)
)

GO
CREATE TABLE trAnswer(
	AnswerID INT PRIMARY KEY IDENTITY(1,1),
	UserID INT REFERENCES [msUser](UserID) ON UPDATE CASCADE ON DELETE CASCADE,
	AssignmentID INT REFERENCES msAssignment(AssignmentID) ON UPDATE CASCADE ON DELETE CASCADE,
	AnswerFilepath VARCHAR(MAX),
	DateUploaded DATETIME DEFAULT(GETDate())
)

GO
CREATE TABLE trThread(
	ThreadID INT PRIMARY KEY IDENTITY(1,1),
	UserID INT REFERENCES [msUser](UserID) ON UPDATE CASCADE ON DELETE CASCADE,
	Title VARCHAR(50),
	Content VARCHAR(MAX)
)

GO
CREATE TABLE trPost(
	PostID INT PRIMARY KEY IDENTITY(1,1),
	ThreadID INT REFERENCES trThread(ThreadID) ON UPDATE NO ACTION ON DELETE NO ACTION,
	UserID INT REFERENCES [msUser](UserID) ON UPDATE NO ACTION ON DELETE NO ACTION,
	Content VARCHAR(MAX)
)

GO
CREATE TABLE msSchedule(
	ScheduleID INT PRIMARY KEY IDENTITY(1,1),
	[StartTime] DATETIME,
	[EndTime] DATETIME,
	Place VARCHAR(40),
	Topic VARCHAR(50),
	[Description] VARCHAR(MAX)
)

GO
CREATE PROC bn_RecDB_GetUserLogin
@Email VARCHAR(50),
@Password VARCHAR(250)
AS
BEGIN
	SELECT 
		UserID, [Name], Email, [Password], [Role], Token
	FROM 
		[msUser]
	WHERE 
		Email = @Email
		AND [Password] = @Password
END


GO
CREATE PROC bn_RecDB_UpdatePassword
@Email VARCHAR(50),
@Password VARCHAR(150)
AS
BEGIN
	UPDATE 
		[msUser] 
	SET 
		[Password] = @Password
	WHERE 
		Email = @Email
END

GO
CREATE PROC bn_RecDB_RegisterUser
@Name VARCHAR(50),
@Email VARCHAR(50),
@Password VARCHAR(250)
AS
BEGIN
	INSERT INTO 
		[msUser](Name,Email,Password) 
	VALUES 
		(@Name,@Email,@Password)
END

GO
CREATE PROC bn_RecDB_VerifyUser
@Email VARCHAR(50)
AS
BEGIN
	UPDATE 
		msUser 
	SET 
		Role='approved' 
	WHERE 
		Email=@Email
END

GO
CREATE PROC bn_RecDB_GetUnapprovedUser
AS
BEGIN
	SELECT 
		UserID, [Name], Email, [Password], [Role], Token 
	FROM 
		[msUser] 
	WHERE 
		Role = 'unapproved'
END

GO
CREATE PROC bn_RecDB_InsertUserToken
@Email VARCHAR(50),
@Token VARCHAR(50)
AS
BEGIN
	UPDATE 
		msUser 
	SET 
		Token = @Token 
	WHERE 
		Email=@Email
END

GO
CREATE PROC bn_RecDB_GetUserToken
@Email VARCHAR(50)
AS
BEGIN
	SELECT 
		Token 
	FROM 
		msUser 
	WHERE 
		Email = @Email
END

GO
CREATE PROC bn_RecDB_DeleteUserToken
@Email VARCHAR(50)
AS
BEGIN
	UPDATE 
		msUser 
	SET 
		Token=null 
	WHERE 
		Email=@Email
END

GO
CREATE PROC bn_RecDB_GetAllAssignment
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
		AssignmentID, Title, DateDue, DateUploaded, [Description], AssignmentFilepath 
	FROM 
		msAssignment
END

GO
CREATE PROC bn_RecDB_InsertAssignment 
@Title VARCHAR(30),
@Description VARCHAR(MAX),
@AssignmentFilePath VARCHAR(MAX),
@DateDue DATETIME
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO 
		msAssignment(Title, [Description], AssignmentFilepath, DateDue) 
	VALUES
		(@Title, @Description, @AssignmentFilePath, @DateDue)
END

GO
CREATE PROC bn_RecDB_UpdateAssignment
@AssignmentID INT,
@Title VARCHAR(30),
@Description VARCHAR(MAX),
@AssignmentFilePath VARCHAR(MAX),
@DateDue DATETIME
AS
BEGIN
	SET NOCOUNT ON
	UPDATE 
		msAssignment
	SET 
		Title = @Title,
		[Description] = @Description,
		[AssignmentFilepath] = @AssignmentFilePath,
		[DateDue] = @DateDue
	WHERE 
		AssignmentID = @AssignmentID
END

GO
CREATE PROC bn_RecDB_DeleteAssignment
@AssignmentID INT
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM 
		msAssignment
	WHERE 
		AssignmentID = @AssignmentID
END

GO
CREATE PROC bn_RecDB_GetAssignment
@AssignmentID INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
		AssignmentID, Title, DateDue, DateUploaded, [Description], AssignmentFilepath 
	FROM 
		msAssignment
	WHERE 
		AssignmentID = @AssignmentID
END

GO
CREATE PROC bn_RecDB_InsertAnswer
@UserID INT,
@AssignmentID INT,
@AnswerFilePath VARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS(SELECT AnswerID, UserID, AssignmentID, AnswerFilepath, DateUploaded FROM trAnswer WHERE UserID = @UserID AND AssignmentID = @AssignmentID)
	BEGIN
		UPDATE 
			trAnswer
		SET 
			AnswerFilepath = @AnswerFilePath
		WHERE 
			UserID = @UserID 
			AND AssignmentID = @AssignmentID
	END
	ELSE
	BEGIN
		INSERT INTO 
			trAnswer(UserID, AssignmentID, AnswerFilepath) 
		VALUES
			(@UserID, @AssignmentID, @AnswerFilePath)
	END
END

GO
CREATE PROC bn_RecDB_GetAllAnswer
@AssignmentID INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
		B.AnswerID, A.[Name], B.AssignmentID, B.AnswerFilepath, A.UserID, B.DateUploaded
	FROM 
		msUser A LEFT 
			JOIN trAnswer B	
				ON A.UserID = B.UserID
		AND B.AssignmentID = @AssignmentID
END

GO
CREATE PROC bn_RecDB_GetAnswer
@AssignmentID INT,
@UserID INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
		AnswerID, UserID, AssignmentID, AnswerFilepath, DateUploaded 
	FROM 
		trAnswer
	WHERE 
		AssignmentID = @AssignmentID AND UserID = @UserID
END

GO
CREATE PROC bn_RecDB_InsertThread
@UserID INT,
@Title VARCHAR(50),
@Content VARCHAR(MAX)
AS
BEGIN
	INSERT INTO 
		trThread(UserID,Title,Content) 
	VALUES
		(@UserID,@Title,@Content)
END

GO
CREATE PROC bn_RecDB_GetAllThread
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
		ThreadID, trThread.UserID, Title, Content, [Name], [Role]
	FROM 
		trThread 
			JOIN msUser 
				ON trThread.UserID = msUser.UserID 
END

go

CREATE PROC bn_RecDB_GetOneThread
@ThreadID INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
		ThreadID, trThread.UserID, Title, Content, [Name], [Role]
	FROM 
		trThread JOIN msUser ON trThread.UserID = msUser.UserID 
	WHERE 
		ThreadID = @ThreadID
END

GO
CREATE PROC bn_RecDB_UpdateThread
@ThreadID INT,
@Title VARCHAR(50),
@Content VARCHAR(MAX)
AS
BEGIN
	UPDATE
		trThread
	SET 
		Title = @Title,
		Content = @Content
	WHERE 
		ThreadID = @ThreadID
END

GO
CREATE PROC bn_RecDB_DeleteThread
@ThreadID INT
AS
BEGIN
	DELETE FROM 
		trPost
	WHERE 
		ThreadID = @ThreadID
	DELETE FROM 
		trThread
	WHERE 
		ThreadID = @ThreadID
END

GO
CREATE PROC bn_RecDB_InsertPost
@UserID INT,
@ThreadID INT,
@Content VARCHAR(MAX)
AS
BEGIN
	INSERT INTO 
		trPost(ThreadID, UserID, Content) 
	VALUES
		(@ThreadID,@UserID,@Content)
END

GO
CREATE PROC bn_RecDB_GetPost
@ThreadID INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT
		PostID, ThreadID, msUser.UserID, Content, [Name]
	FROM
		trPost JOIN msUser ON trPost.UserID = msUser.UserID
	WHERE
		ThreadID = @ThreadID
END

GO
CREATE PROC bn_RecDB_UpdatePost
@PostID INT,
@Content VARCHAR(MAX)
AS
BEGIN
	UPDATE
		trPost
	SET 
		Content = @Content
	WHERE 
		PostID = @PostID
END

GO
CREATE PROC bn_RecDB_DeletePost
@PostID INT
AS
BEGIN
	DELETE FROM 
		trPost
	WHERE 
		PostID = @PostID

END

GO
CREATE PROC bn_RecDB_GetPostByID
@PostID INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT
		PostID, ThreadID, msUser.UserID, Content, [Name]
	FROM
		trPost JOIN msUser ON trPost.UserID = msUser.UserID
	WHERE
		PostID = @PostID
END

GO
CREATE PROC bn_RecDB_GetAllSchedule
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
		ScheduleID, StartTime, EndTime, Place, Topic, [Description]
	FROM 
		msSchedule
END

GO
CREATE PROC bn_RecDB_InsertSchedule
@StartTime DATETIME,
@EndTime DATETIME,
@Place VARCHAR(40),
@Topic VARCHAR(50),
@Description VARCHAR(MAX)
AS
BEGIN
	INSERT INTO 
		msSchedule(StartTime,EndTime,Place,Topic,[Description]) 
	VALUES
		(@StartTime,@EndTime,@Place,@Topic,@Description)
END

GO
CREATE PROC bn_RecDB_UpdateSchedule
@ScheduleID INT,
@StartTime DATETIME,
@EndTime DATETIME,
@Place VARCHAR(40),
@Topic VARCHAR(50),
@Description VARCHAR(MAX)
AS
BEGIN
	UPDATE 
		msSchedule 
	SET 
		StartTime=@StartTime,
		EndTime=@EndTime,
		Place = @Place,
		Topic = @Topic,
		[Description] = @Description
	WHERE 
		ScheduleID = @ScheduleID
END

GO
CREATE PROC bn_RecDB_DeleteSchedule
@ScheduleID INT
AS
BEGIN
	DELETE FROM
		msSchedule 
	WHERE 
		ScheduleID = @ScheduleID
END

GO
CREATE PROC bn_RecDB_GetScheduleByID
@ScheduleID INT
AS
BEGIN
	SELECT 
		ScheduleID, StartTime, EndTime, Place, Topic, [Description] 
	FROM 
		msSchedule 
	WHERE 
		ScheduleID = @ScheduleID
END

GO

/*Note: Password untuk data di bawah ini telah di hash, 
jadi tolong gunakan email dan password yang dicomment untuk login,
atau register sendiri melalui web*/

INSERT INTO msUser VALUES('Admin', 'admin@admin.com', '58B42B81B23E32BA2BBA109FEAD7C5C085BB1F02BE4A087DEE6D25F4D0D6A5265B9AEE57462E76EE5760137A9CFAE136802B8A6A659936180346432341EBD80B', 'admin', null)
--Email: admin@admin.com
--Password: admin

INSERT INTO msUser VALUES('Christian Soetanto', 'unapproved@unapproved.com', '741E4269D93930CA0BE78FBF46789CA1A5E631B0EAC3DE0C5069C161DAF3617B03AC8A83010F82A2DBF4D2DB5F67D85E34258108350728A1EB59ECF10CD43557', 'unapproved', null)
--Email: unapproved@unapproved.com
--Password: unapproved

INSERT INTO msUser VALUES('Reynaldi Chernando', 'approved@approved.com', 'CC84EA3977B65849E9F1173F4B68A2541016EE80A374A2E37B08BD082988BE7EF906BA964B31462106B683FC2A1330EDE13FEAEECF4EDCDBBDFA182B7C578115', 'approved', null)
--Email: approved@approved.com
--Password: approved

INSERT INTO msUser VALUES('Luis Indracahya', 'luis@indahnyacahaya.com', '85F774FF240251109C6D0D0C04CF800F68072F1489CF8CE5F81BCBC9E776510101C8415655309FF3E67B542B6146EC9063F8160B226BFFC4DF71B937E2771524', 'approved',null)
--Email: luis@indahnyacahaya.com
--Password: approved

GO
--Announcement
INSERT INTO trThread VALUES
(1, 'C# Assignment', 'Dear applicants, the case for C# assignment can now be downloaded from the assignment page in this website, please submit your answer before January 10, 2020 at 06:00 PM'),
(1, 'ASP.NET MVC Assignment', 'Dear applicants, the case for ASP.NET MVC assignment can now be downloaded from the assignment page in this website, please submit your answer before January 19, 2020 at 23:59 PM'),
(1, 'Android Studio Assignment', 'Dear applicants, the case for Android Studio assignment can now be downloaded from the assignment page in this website, please submit your answer before January 23, 2020 at 23:59 PM'),
(1, 'PHP BM5 Assignment', 'Dear applicants, the case for PHP BM5 assignment can now be downloaded from the assignment page in this website, please submit your answer before January 27, 2020 at 23:59 PM')

GO
--Forum
INSERT INTO trThread VALUES
(3, 'Submission File Format', 'Dear Sir/Madam, regarding the submission for our C# assignment that is due this evening, is there any specific file format for the file that we must submit? Thank you.'),
(4, 'Android Studio Download', 'Excuse me, does anybody know where can i download android studio? and is it free to download?')

GO
--Reply Announcement
INSERT INTO trPost VALUES
(1, 4, 'Okay, noted.'),
(2, 4, 'Okay, noted.'),
(3, 4, 'Okay, noted.'),
(4, 4, 'Okay, noted.')

GO
--Reply Forum
INSERT INTO trPost VALUES
(5, 1, 'Yes, there is. As we said in the training room previously, the submission file format is Name-AssignmentTopic-AppliedPosition.'),
(5, 3, 'Thank you very much, Sir/Madam.'),
(6, 3, 'You can download it from its official website: developer.android.com/studio, it is free to download'),
(6, 4, 'Thank youu'),
(6, 3, 'You are very welcome')

GO
INSERT INTO msSchedule VALUES
('2020-01-08 08:00:00.000', '2020-01-08 09:40:00.000', 'R. 624 Bina Nusantara Anggrek', 'C#', 'C# Programming Language Fundamendal and Object-Oriented Programming using C#'),
('2020-01-18 12:00:00.000', '2020-01-18 13:40:00.000', 'R. M3CD Bina Nusantara Syahdan', 'ASP.NET MVC', 'ASP.NET MVC(Model View Controller) and WebAPI(Application Programming Interface) using C#'),
('2020-01-21 10:00:00.000', '2020-01-21 11:40:00.000', 'R. 400 Bina Nusantara Anggrek', 'Android Studio', 'Mobile Application Development for Android using Java'),
('2020-01-25 16:00:00.000', '2020-01-25 17:40:00.000', 'R. M2CD Bina Nusantara Syahdan', 'PHP BM5', 'Binusmaya BM5 Framework using PHP')
