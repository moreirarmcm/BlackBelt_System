---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.InserirPessoa
---------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE cadastro.InserirPessoa
    @Nome        VARCHAR(255),
    @CPF         VARCHAR(11) = NULL,
    @Nascimento  DATE,
    @Sexo        CHAR(1) = NULL,
    @PCD         BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO cadastro.Pessoa (Nome, CPF, Nascimento, Sexo, PCD)
    VALUES (@Nome, @CPF, @Nascimento, @Sexo, @PCD);
END;
GO

---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.AtualizarPessoa
---------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE cadastro.AtualizarPessoa
    @Codigo      INT,
    @Nome        VARCHAR(255),
    @CPF         VARCHAR(11) = NULL,
    @Nascimento  DATE,
    @Sexo        CHAR(1) = NULL,
    @PCD         BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE cadastro.Pessoa
    SET Nome = @Nome,
        CPF = @CPF,
        Nascimento = @Nascimento,
        Sexo = @Sexo,
        PCD = @PCD
    WHERE Codigo = @Codigo;
END;
GO

---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.ExcluirPessoa
---------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE cadastro.ExcluirPessoa
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM cadastro.Pessoa
    WHERE Codigo = @Codigo;
END;
GO

---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.BuscarPessoa
---------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE cadastro.BuscarPessoa
    @Codigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Codigo IS NULL
        SELECT * FROM cadastro.Pessoa;
    ELSE
        SELECT * FROM cadastro.Pessoa WHERE Codigo = @Codigo;
END;
GO