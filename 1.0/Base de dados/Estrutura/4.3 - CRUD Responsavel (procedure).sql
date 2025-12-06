---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.InserirResponsavel
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.InserirResponsavel
    @Nome        VARCHAR(255),
    @CPF         VARCHAR(11) = NULL,
    @Nascimento  DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO cadastro.Responsavel
        (Nome, CPF, Nascimento)
    VALUES
        (@Nome, @CPF, @Nascimento);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.AtualizarResponsavel
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.AtualizarResponsavel
    @Codigo      INT,
    @Nome        VARCHAR(255),
    @CPF         VARCHAR(11) = NULL,
    @Nascimento  DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE cadastro.Responsavel
    SET Nome = @Nome,
        CPF = @CPF,
        Nascimento = @Nascimento
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.ExcluirResponsavel
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.ExcluirResponsavel
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM cadastro.Responsavel
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.BuscarResponsavel
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.BuscarResponsavel
    @Codigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM cadastro.Responsavel
    WHERE (@Codigo IS NULL OR Codigo = @Codigo);
END;
GO
