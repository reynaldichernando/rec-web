USE RecDB

GO
ALTER PROC bn_RecDB_InsertAnswer
@UserID INT,
@AssignmentID INT,
@AnswerFilePath VARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS(SELECT * FROM trAnswer WHERE UserID = @UserID AND AssignmentID = @AssignmentID)
	BEGIN
		UPDATE trAnswer
		SET AnswerFilepath = @AnswerFilePath
		WHERE UserID = @UserID AND AssignmentID = @AssignmentID
	END
	ELSE
	BEGIN
		INSERT INTO trAnswer(UserID, AssignmentID, AnswerFilepath) VALUES
		(@UserID, @AssignmentID, @AnswerFilePath)
	END
END

GO
ALTER PROC bn_RecDB_GetAllAnswer
@AssignmentID INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT B.AnswerID, A.[Name], B.AssignmentID, B.AnswerFilepath, A.UserID, B.DateUploaded
	FROM msUser A LEFT JOIN trAnswer B
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
	SELECT * FROM trAnswer
	WHERE AssignmentID = @AssignmentID AND UserID = @UserID
END

SELECT * FROM trAnswer

EXEC bn_RecDB_GetAnswer 20, 3
