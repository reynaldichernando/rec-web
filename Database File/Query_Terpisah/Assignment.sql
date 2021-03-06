USE RecDB

GO
CREATE PROC bn_RecDB_GetAllAssignment
AS
BEGIN
	SET NOCOUNT ON
	SELECT * FROM msAssignment
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
	INSERT INTO msAssignment(Title, [Description], AssignmentFilepath, DateDue) VALUES
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
	UPDATE msAssignment
	SET Title = @Title,
	[Description] = @Description,
	[AssignmentFilepath] = @AssignmentFilePath,
	[DateDue] = @DateDue
	WHERE AssignmentID = @AssignmentID
END

GO
CREATE PROC bn_RecDB_DeleteAssignment
@AssignmentID INT
AS
BEGIN
	SET NOCOUNT ON
	DELETE FROM msAssignment
	WHERE AssignmentID = @AssignmentID
END

GO
CREATE PROC bn_RecDB_GetAssignment
@AssignmentID INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT * FROM msAssignment
	WHERE AssignmentID = @AssignmentID
END
