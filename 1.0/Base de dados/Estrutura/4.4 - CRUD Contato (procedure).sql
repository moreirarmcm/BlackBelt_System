---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.InserirContato
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.InserirContato
    @CodigoPessoa   INT,
    @Logradouro     VARCHAR(255),
    @CEP            VARCHAR(7) = NULL,
    @Cidade         VARCHAR(255) = NULL,
    @UF             CHAR(2) = NULL,
    @Email          VARCHAR(255) = NULL,
    @Telefone       VARCHAR(20) = NULL,
    @Celular        VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO cadastro.Contato
        (CodigoPessoa, Logradouro, CEP, Cidade, UF, Email, Telefone, Celular)
    VALUES
        (@CodigoPessoa, @Logradouro, @CEP, @Cidade, @UF, @Email, @Telefone, @Celular);
END;
GO

---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.AtualizarContato
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.AtualizarContato
    @Codigo         INT,
    @CodigoPessoa   INT,
    @Logradouro     VARCHAR(255),
    @CEP            VARCHAR(7) = NULL,
    @Cidade         VARCHAR(255) = NULL,
    @UF             CHAR(2) = NULL,
    @Email          VARCHAR(255) = NULL,
    @Telefone       VARCHAR(20) = NULL,
    @Celular        VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE cadastro.Contato
    SET CodigoPessoa = @CodigoPessoa,
        Logradouro = @Logradouro,
        CEP = @CEP,
        Cidade = @Cidade,
        UF = @UF,
        Email = @Email,
        Telefone = @Telefone,
        Celular = @Celular
    WHERE Codigo = @Codigo;
END;
GO

---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.ExcluirContato
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.ExcluirContato
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM cadastro.Contato
    WHERE Codigo = @Codigo;
END;
GO

---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.BuscarContato
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.BuscarContato
    @Codigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM cadastro.Contato
    WHERE (@Codigo IS NULL OR Codigo = @Codigo);
END;
GO
