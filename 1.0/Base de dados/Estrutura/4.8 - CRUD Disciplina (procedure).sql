---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.InserirDisciplina
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.InserirDisciplina
    @Nome        VARCHAR(255),
    @Descricao   VARCHAR(255) = NULL,
    @Observacao  VARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO atividade.Disciplina
        (Nome, Descricao, Observacao)
    VALUES
        (@Nome, @Descricao, @Observacao);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.AtualizarDisciplina
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.AtualizarDisciplina
    @Codigo      INT,
    @Nome        VARCHAR(255),
    @Descricao   VARCHAR(255) = NULL,
    @Observacao  VARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE atividade.Disciplina
    SET Nome = @Nome,
        Descricao = @Descricao,
        Observacao = @Observacao
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.ExcluirDisciplina
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.ExcluirDisciplina
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM atividade.Disciplina
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.BuscarDisciplina
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.BuscarDisciplina
    @Codigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM atividade.Disciplina
    WHERE (@Codigo IS NULL OR Codigo = @Codigo);
END;
GO

