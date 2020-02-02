alter proc bn_RecDB_InsertSchedule 
'12/31/2020 12:59:00 PM' , '12/31/2020 12:59:00 PM', 'place','toicc','desc'
@StartTime datetime,
@EndTime datetime,
@Place varchar(30),
@Topic varchar(30),
@Description varchar(max)
as
begin
	insert into Schedule (StartTime,EndTime,Place,Topic,[Description]) values(@StartTime,@EndTime,@Place,@Topic,@Description)
end


create proc bn_RecDB_UpdateSchedule
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

create proc bn_RecDB_DeleteSchedule
@ScheduleID int
as
begin
	delete from Schedule where ScheduleID = @ScheduleID
end