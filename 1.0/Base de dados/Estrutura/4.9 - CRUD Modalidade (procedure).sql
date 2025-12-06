---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.InserirModalidade
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.InserirModalidade
    @CodigoDisciplina INT,
    @Nome             VARCHAR(255),
    @Descricao        VARCHAR(MAX) = NULL,
    @Ordem            INT = 1,
    @Tipo             VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO atividade.Modalidade
        (CodigoDisciplina, Nome, Descricao, Ordem, Tipo)
    VALUES
        (@CodigoDisciplina, @Nome, @Descricao, @Ordem, @Tipo);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.AtualizarModalidade
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.AtualizarModalidade
    @Codigo           INT,
    @CodigoDisciplina INT,
    @Nome             VARCHAR(255),
    @Descricao        VARCHAR(MAX) = NULL,
    @Ordem            INT = 1,
    @Tipo             VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE atividade.Modalidade
    SET CodigoDisciplina = @CodigoDisciplina,
        Nome = @Nome,
        Descricao = @Descricao,
        Ordem = @Ordem,
        Tipo = @Tipo
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.ExcluirModalidade
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.ExcluirModalidade
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM atividade.Modalidade
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.BuscarModalidade
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.BuscarModalidade
    @Codigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM atividade.Modalidade
    WHERE (@Codigo IS NULL OR Codigo = @Codigo);
END;
GO

