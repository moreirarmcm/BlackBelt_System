USE BlackBelt_Dev
BEGIN TRY
BEGIN TRAN
DECLARE @ApenasTeste BIT = 1

--SELECT * FROM INFORMATION_SCHEMA.TABLES

--===================================================================
--===================================================================





--====================================================================
--====================================================================

IF @ApenasTeste = 1 BEGIN ROLLBACK; print 'Rollback'; END ELSE BEGIN COMMIT; print 'Commit' END
END TRY
BEGIN CATCH
--SELECT * FROM geral.CapturarErro()
ROLLBACK
END CATCH

