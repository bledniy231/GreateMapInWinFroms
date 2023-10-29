if not exists(select * from sys.databases where name = 'FirstTask')
begin
	create database FirstTask
end

