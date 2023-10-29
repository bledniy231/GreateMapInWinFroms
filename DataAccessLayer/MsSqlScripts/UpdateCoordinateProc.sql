if not exists(select * from sys.procedures where name = 'UpdateCoordinateProc')
begin
	exec('
        create procedure UpdateCoordinateProc
            @pointName nvarchar(255),
            @latitude float,
            @longitude float
        as
        begin
            update FirstTask.dbo.Coordinates
            set Latitude = @latitude, Longitude = @longitude
            where PointName = @pointName;
        end
	')
end