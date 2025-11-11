---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.InserirFilial
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.InserirFilial
    @CodigoAcademia  INT = NULL,
    @Nome            VARCHAR(255),
    @Endereco        VARCHAR(255) = NULL,
    @Cidade          VARCHAR(255) = NULL,
    @UF              CHAR(2) = NULL,
    @CEP             VARCHAR(7),
    @Email           VARCHAR(255) = NULL,
    @Telefone        VARCHAR(255) = NULL,
    @CNPJ            VARCHAR(255) = NULL,
    @CodigoOrigem    VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO cadastro.Filial
        (CodigoAcademia, Nome, Endereco, Cidade, UF, CEP, Email, Telefone, CNPJ, CodigoOrigem)
    VALUES
        (@CodigoAcademia, @Nome, @Endereco, @Cidade, @UF, @CEP, @Email, @Telefone, @CNPJ, @CodigoOrigem);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.AtualizarFilial
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.AtualizarFilial
    @Codigo          INT,
    @CodigoAcademia  INT = NULL,
    @Nome            VARCHAR(255),
    @Endereco        VARCHAR(255) = NULL,
    @Cidade          VARCHAR(255) = NULL,
    @UF              CHAR(2) = NULL,
    @CEP             VARCHAR(7),
    @Email           VARCHAR(255) = NULL,
    @Telefone        VARCHAR(255) = NULL,
    @CNPJ            VARCHAR(255) = NULL,
    @Situacao        BIT = 1,
    @CodigoOrigem    VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE cadastro.Filial
    SET CodigoAcademia = @CodigoAcademia,
        Nome = @Nome,
        Endereco = @Endereco,
        Cidade = @Cidade,
        UF = @UF,
        CEP = @CEP,
        Email = @Email,
        Telefone = @Telefone,
        CNPJ = @CNPJ,
        Situacao = @Situacao,
        CodigoOrigem = @CodigoOrigem
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.ExcluirFilial
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.ExcluirFilial
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM cadastro.Filial
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.BuscarFilial
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.BuscarFilial
    @Codigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM cadastro.Filial
    WHERE (@Codigo IS NULL OR Codigo = @Codigo);
END;
GO
