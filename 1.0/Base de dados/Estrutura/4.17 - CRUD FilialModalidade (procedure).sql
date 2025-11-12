---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.InserirFilialModalidade
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.InserirFilialModalidade
    @CodigoFilial        INT,
    @CodigoModalidade    INT,
    @Situacao            INT = 1
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO atividade.FilialModalidade
        (CodigoFilial, CodigoModalidade, Situacao)
    VALUES
        (@CodigoFilial, @CodigoModalidade, @Situacao);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.AtualizarFilialModalidade
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.AtualizarFilialModalidade
    @Codigo              INT,
    @CodigoFilial        INT,
    @CodigoModalidade    INT,
    @Situacao            INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE atividade.FilialModalidade
    SET CodigoFilial     = @CodigoFilial,
        CodigoModalidade = @CodigoModalidade,
        Situacao         = @Situacao
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.ExcluirFilialModalidade
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.ExcluirFilialModalidade
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM atividade.FilialModalidade
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.BuscarFilialModalidade
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.BuscarFilialModalidade
    @Codigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM atividade.FilialModalidade
    WHERE (@Codigo IS NULL OR Codigo = @Codigo);
END;
GO
