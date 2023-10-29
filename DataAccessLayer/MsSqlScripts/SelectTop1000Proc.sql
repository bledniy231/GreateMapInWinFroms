if not exists(select * from sys.procedures where name = 'SelectTop1000Proc')
begin
	exec('
		create procedure SelectTop1000Proc
		as
		begin
			SELECT TOP (1000) [Id]
				  ,[PointName]
				  ,[Latitude]
				  ,[Longitude]
			  FROM [FirstTask].[dbo].[Coordinates]
		end
	')
end

