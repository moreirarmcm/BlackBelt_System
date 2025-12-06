---------------------------------------------------------------------------------------
-- PROCEDURE: seguranca.InserirUsuarioPerfil
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE seguranca.InserirUsuarioPerfil
    @CodigoUsuario   INT,
    @CodigoPerfil    INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO seguranca.UsuarioPerfil
        (CodigoUsuario, CodigoPerfil)
    VALUES
        (@CodigoUsuario, @CodigoPerfil);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: seguranca.AtualizarUsuarioPerfil
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE seguranca.AtualizarUsuarioPerfil
    @CodigoUsuario   INT,
    @CodigoPerfil    INT,
    @NovoCodigoPerfil INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE seguranca.UsuarioPerfil
    SET CodigoPerfil = @NovoCodigoPerfil
    WHERE CodigoUsuario = @CodigoUsuario
      AND CodigoPerfil = @CodigoPerfil;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: seguranca.ExcluirUsuarioPerfil
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE seguranca.ExcluirUsuarioPerfil
    @CodigoUsuario   INT,
    @CodigoPerfil    INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM seguranca.UsuarioPerfil
    WHERE CodigoUsuario = @CodigoUsuario
      AND CodigoPerfil = @CodigoPerfil;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: seguranca.BuscarUsuarioPerfil
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE seguranca.BuscarUsuarioPerfil
    @CodigoUsuario   INT = NULL,
    @CodigoPerfil    INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM seguranca.UsuarioPerfil
    WHERE (@CodigoUsuario IS NULL OR CodigoUsuario = @CodigoUsuario)
      AND (@CodigoPerfil IS NULL OR CodigoPerfil = @CodigoPerfil);
END;
GO
