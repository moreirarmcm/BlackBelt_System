---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.InserirAlunoFilialModalidade
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.InserirAlunoFilialModalidade
    @CodigoAluno             INT,
    @CodigoFilialModalidade  INT,
    @DataInicio              DATETIME = NULL,
    @DataFim                 DATETIME = NULL,
    @Situacao                INT = 1
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO atividade.AlunoFilialModalidade
        (CodigoAluno, CodigoFilialModalidade, DataInicio, DataFim, Situacao)
    VALUES
        (@CodigoAluno, @CodigoFilialModalidade, ISNULL(@DataInicio, GETDATE()), @DataFim, @Situacao);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.AtualizarAlunoFilialModalidade
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.AtualizarAlunoFilialModalidade
    @CodigoAluno             INT,
    @CodigoFilialModalidade  INT,
    @DataInicio              DATETIME,
    @DataFim                 DATETIME = NULL,
    @Situacao                INT = 1
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE atividade.AlunoFilialModalidade
    SET DataInicio = @DataInicio,
        DataFim    = @DataFim,
        Situacao   = @Situacao
    WHERE CodigoAluno = @CodigoAluno
      AND CodigoFilialModalidade = @CodigoFilialModalidade;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.ExcluirAlunoFilialModalidade
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.ExcluirAlunoFilialModalidade
    @CodigoAluno             INT,
    @CodigoFilialModalidade  INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM atividade.AlunoFilialModalidade
    WHERE CodigoAluno = @CodigoAluno
      AND CodigoFilialModalidade = @CodigoFilialModalidade;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.BuscarAlunoFilialModalidade
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.BuscarAlunoFilialModalidade
    @CodigoAluno             INT = NULL,
    @CodigoFilialModalidade  INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM atividade.AlunoFilialModalidade
    WHERE (@CodigoAluno IS NULL OR CodigoAluno = @CodigoAluno)
      AND (@CodigoFilialModalidade IS NULL OR CodigoFilialModalidade = @CodigoFilialModalidade);
END;
GO
