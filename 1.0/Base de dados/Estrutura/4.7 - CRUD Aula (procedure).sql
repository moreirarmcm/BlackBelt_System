---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.InserirAula
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.InserirAula
    @CodigoFilialModalidade INT,
    @Data                   DATETIME,
    @Situacao               INT = 1
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO atividade.Aula
        (CodigoFilialModalidade, Data, Situacao)
    VALUES
        (@CodigoFilialModalidade, @Data, @Situacao);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.AtualizarAula
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.AtualizarAula
    @Codigo                 INT,
    @CodigoFilialModalidade INT,
    @Data                   DATETIME,
    @Situacao               INT = 1
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE atividade.Aula
    SET CodigoFilialModalidade = @CodigoFilialModalidade,
        Data = @Data,
        Situacao = @Situacao
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.ExcluirAula
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.ExcluirAula
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM atividade.Aula
    WHERE Codigo = @Codigo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.BuscarAula
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.BuscarAula
    @Codigo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM atividade.Aula
    WHERE (@Codigo IS NULL OR Codigo = @Codigo);
END;
GO
