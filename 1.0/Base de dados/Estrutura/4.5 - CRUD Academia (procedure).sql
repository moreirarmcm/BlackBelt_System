---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.InserirAcademia
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.InserirAcademia
    @Nome   VARCHAR(255),
    @CNPJ   VARCHAR(255) = NULL,
    @Sigla  VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO cadastro.Academia
        (Nome, CNPJ, Sigla)
    VALUES
        (@Nome, @CNPJ, @Sigla);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.AtualizarAcademia
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.AtualizarAcademia
    @Codigo INT,
    @Nome   VARCHAR(255),
    @CNPJ   VARCHAR(255) = NULL,
    @Sigla  VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE cadastro.Academia
    SET Nome = @Nome,
        CNPJ = @CNPJ,
        Sigla = @Sigla
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.ExcluirAcademia
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.ExcluirAcademia
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM cadastro.Academia
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.BuscarAcademia
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.BuscarAcademia
    @Codigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM cadastro.Academia
    WHERE (@Codigo IS NULL OR Codigo = @Codigo);
END;
GO
