---------------------------------------------------------------------------------------
-- PROCEDURE: seguranca.InserirUsuario
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE seguranca.InserirUsuario
    @CodigoAluno             INT = NULL,
    @Login                   VARCHAR(100),
    @Senha                   VARBINARY(512),
    @Email                   VARCHAR(255) = NULL,
    @UltimoAcesso            DATETIME = NULL,
    @UltimaSenha             DATETIME = NULL,
    @UltimaAlteracaoSenha    DATETIME = NULL,
    @Situacao                INT = 1
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO seguranca.Usuario
        (CodigoAluno, Login, Senha, Email, UltimoAcesso, UltimaSenha, UltimaAlteracaoSenha, Situacao)
    VALUES
        (@CodigoAluno, @Login, @Senha, @Email, @UltimoAcesso, @UltimaSenha, @UltimaAlteracaoSenha, @Situacao);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: seguranca.AtualizarUsuario
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE seguranca.AtualizarUsuario
    @Codigo                  INT,
    @CodigoAluno             INT = NULL,
    @Login                   VARCHAR(100),
    @Senha                   VARBINARY(512),
    @Email                   VARCHAR(255) = NULL,
    @UltimoAcesso            DATETIME = NULL,
    @UltimaSenha             DATETIME = NULL,
    @UltimaAlteracaoSenha    DATETIME = NULL,
    @Situacao                INT = 1
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE seguranca.Usuario
    SET CodigoAluno = @CodigoAluno,
        Login = @Login,
        Senha = @Senha,
        Email = @Email,
        UltimoAcesso = @UltimoAcesso,
        UltimaSenha = @UltimaSenha,
        UltimaAlteracaoSenha = @UltimaAlteracaoSenha,
        Situacao = @Situacao
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: seguranca.ExcluirUsuario
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE seguranca.ExcluirUsuario
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM seguranca.Usuario
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: seguranca.BuscarUsuario
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE seguranca.BuscarUsuario
    @Codigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM seguranca.Usuario
    WHERE (@Codigo IS NULL OR Codigo = @Codigo);
END;
GO
