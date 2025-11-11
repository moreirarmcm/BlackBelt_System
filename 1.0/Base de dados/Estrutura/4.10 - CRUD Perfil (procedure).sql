---------------------------------------------------------------------------------------
-- PROCEDURE: seguranca.InserirPerfil
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE seguranca.InserirPerfil
    @CodigoFilial   INT = NULL,
    @Nome           VARCHAR(100),
    @Descricao      VARCHAR(255) = NULL,
    @Tipo           VARCHAR(50) = NULL,
    @Ativo          BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO seguranca.Perfil
        (CodigoFilial, Nome, Descricao, Tipo, Ativo)
    VALUES
        (@CodigoFilial, @Nome, @Descricao, @Tipo, @Ativo);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: seguranca.AtualizarPerfil
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE seguranca.AtualizarPerfil
    @Codigo         INT,
    @CodigoFilial   INT = NULL,
    @Nome           VARCHAR(100),
    @Descricao      VARCHAR(255) = NULL,
    @Tipo           VARCHAR(50) = NULL,
    @Ativo          BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE seguranca.Perfil
    SET CodigoFilial = @CodigoFilial,
        Nome = @Nome,
        Descricao = @Descricao,
        Tipo = @Tipo,
        Ativo = @Ativo
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: seguranca.ExcluirPerfil
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE seguranca.ExcluirPerfil
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM seguranca.Perfil
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: seguranca.BuscarPerfil
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE seguranca.BuscarPerfil
    @Codigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM seguranca.Perfil
    WHERE (@Codigo IS NULL OR Codigo = @Codigo);
END;
GO
