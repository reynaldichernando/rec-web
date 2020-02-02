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

create proc bn_BookDB_UpdateSchedule
@ScheduleID int,
@StartTime datetime,
@EndTime datetime,
@Place varchar(50),
@Topic varchar(50),
@Description varchar(50)
as
begin
	update Schedule set StartTime=@StartTime,
	EndTime=@EndTime,
	Place = @Place,
	Topic = @Topic,
	Description = @Description
	where ScheduleID = @ScheduleID
end