if not exists (select * from sys.procedures where name = 'DeleteCoordinateProc')
begin
    exec('
        create procedure DeleteCoordinateProc
            @pointName nvarchar(255),
            @latitude float,
            @longitude float
        as
        begin
            delete from FirstTask.dbo.Coordinates
            where PointName = @pointName and Latitude = @latitude and Longitude = @longitude;
        end
    ')
end
