-- тэг U значит User table
if OBJECT_ID('FirstTask.dbo.Coordinates', 'U') is null
begin
	create table FirstTask.dbo.Coordinates(
	Id INT identity(1, 1) PRIMARY KEY,
	PointName nvarchar(255),
	Latitude float,
	Longitude float);

	insert FirstTask.dbo.Coordinates(PointName, Latitude, Longitude)
	values ('SUSU', 55.16050371482184, 61.370177583057185);

	insert FirstTask.dbo.Coordinates(PointName, Latitude, Longitude)
	values ('Opera and Ballet Theatre', 55.166862645697776, 61.40195476957598);
end