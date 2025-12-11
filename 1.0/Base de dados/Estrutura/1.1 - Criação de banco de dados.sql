
IF NOT EXISTS (select* from sys.databases where name = 'BlackBelt_Dev')
BEGIN
	CREATE DATABASE BlackBelt_Dev
	PRINT 'Base "BlackBelt_Dev" Criada;'
END;
