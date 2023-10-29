if not exists(select * from sys.procedures where name = 'CreateNewCoordinateProc')
begin
    exec('
        create procedure CreateNewCoordinateProc
            @pointName nvarchar(255),
            @latitude float,
            @longitude float
        as
        begin
            insert FirstTask.dbo.Coordinates (PointName, Latitude, Longitude)
            values (@pointName, @latitude, @longitude);
        end
    ')
end