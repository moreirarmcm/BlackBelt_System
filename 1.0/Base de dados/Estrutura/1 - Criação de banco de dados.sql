BEGIN TRY
BEGIN TRAN
DECLARE @ApenasTeste BIT = 0

--===================================================================
--===================================================================

IF NOT EXISTS (select* from sys.databases where name = 'BlackBelt_Dev')
BEGIN
	CREATE DATABASE BlackBelt_Dev
	PRINT 'Base "BlackBelt_Dev" Criada;'
END;

IF EXISTS (select* from sys.databases where name = 'BlackBelt_Dev')
BEGIN
	USE BlackBelt_Dev
END;


IF NOT EXISTS(SELECT 1 FROM sys.schemas WHERE name = 'cadastro')
BEGIN
    EXEC('CREATE SCHEMA cadastro AUTHORIZATION dbo;');
	PRINT 'Schema [cadastro] criado!'
END;

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'seguranca')
BEGIN
    EXEC('CREATE SCHEMA seguranca AUTHORIZATION dbo;');
    PRINT 'Schema [seguranca] criado!';
END

IF NOT EXISTS(SELECT 1 FROM sys.schemas WHERE name = 'atividade')
BEGIN
    EXEC('CREATE SCHEMA atividade AUTHORIZATION dbo;');
	    PRINT 'Schema [atividade] criado!';

END;

--===================================================================
--===================================================================

IF @ApenasTeste = 1 BEGIN ROLLBACK; print 'Rollback'; END ELSE BEGIN COMMIT; print 'Commit' END
END TRY
BEGIN CATCH
--SELECT * FROM geral.CapturarErro()
ROLLBACK
END CATCH