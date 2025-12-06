---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.InserirTitulo
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.InserirTitulo
    @CodigoAcademia INT = NULL,
    @Nome           VARCHAR(100),
    @Descricao      VARCHAR(255) = NULL,
    @Padrao         BIT = 0,
    @Ordem          INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO cadastro.Titulo
        (CodigoAcademia, Nome, Descricao, Padrao, Ordem)
    VALUES
        (@CodigoAcademia, @Nome, @Descricao, @Padrao, @Ordem);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.AtualizarTitulo
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.AtualizarTitulo
    @Codigo         INT,
    @CodigoAcademia INT = NULL,
    @Nome           VARCHAR(100),
    @Descricao      VARCHAR(255) = NULL,
    @Padrao         BIT = 0,
    @Ordem          INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE cadastro.Titulo
    SET CodigoAcademia = @CodigoAcademia,
        Nome = @Nome,
        Descricao = @Descricao,
        Padrao = @Padrao,
        Ordem = @Ordem
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.ExcluirTitulo
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.ExcluirTitulo
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM cadastro.Titulo
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.BuscarTitulo
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.BuscarTitulo
    @Codigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM cadastro.Titulo
    WHERE (@Codigo IS NULL OR Codigo = @Codigo);
END;
GO
