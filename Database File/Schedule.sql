CREATE PROC bn_RecDB_GetAllSchedule
AS
BEGIN
	SET NOCOUNT ON
	SELECT * FROM msSchedule
END

GO
create proc bn_RecDB_InsertSchedule
@StartTime datetime,
@EndTime datetime,
@Place varchar(30),
@Topic varchar(30),
@Description varchar(max)
as
begin
	insert into msSchedule (StartTime,EndTime,Place,Topic,[Description]) 
	values(@StartTime,@EndTime,@Place,@Topic,@Description)
end
GO
create proc bn_RecDB_UpdateSchedule
@ScheduleID int,
@StartTime datetime,
@EndTime datetime,
@Place varchar(50),
@Topic varchar(50),
@Description varchar(50)
as
begin
	update msSchedule set StartTime=@StartTime,
	EndTime=@EndTime,
	Place = @Place,
	Topic = @Topic,
	Description = @Description
	where ScheduleID = @ScheduleID
end

GO
create proc bn_RecDB_DeleteSchedule
@ScheduleID int
as
begin
	delete from msSchedule where ScheduleID = @ScheduleID
end

GO
create proc bn_RecDB_GetScheduleByID '1'
@ScheduleID int
as
begin
	select * from msSchedule where ScheduleID = @ScheduleID
end

use RecDB