---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.InserirAlunoResponsavel
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.InserirAlunoResponsavel
    @CodigoAluno        INT,
    @CodigoResponsavel  INT,
    @GrauParentesco     INT = NULL,
    @Telefone           VARCHAR(20),
    @Ordem              INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO cadastro.AlunoResponsavel
        (CodigoAluno, CodigoResponsavel, GrauParentesco, Telefone, Ordem)
    VALUES
        (@CodigoAluno, @CodigoResponsavel, @GrauParentesco, @Telefone, @Ordem);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.AtualizarAlunoResponsavel
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.AtualizarAlunoResponsavel
    @CodigoAluno        INT,
    @CodigoResponsavel  INT,
    @GrauParentesco     INT = NULL,
    @Telefone           VARCHAR(20),
    @Ordem              INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE cadastro.AlunoResponsavel
    SET GrauParentesco = @GrauParentesco,
        Telefone = @Telefone,
        Ordem = @Ordem
    WHERE CodigoAluno = @CodigoAluno
      AND CodigoResponsavel = @CodigoResponsavel;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.ExcluirAlunoResponsavel
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.ExcluirAlunoResponsavel
    @CodigoAluno        INT,
    @CodigoResponsavel  INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM cadastro.AlunoResponsavel
    WHERE CodigoAluno = @CodigoAluno
      AND CodigoResponsavel = @CodigoResponsavel;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.BuscarAlunoResponsavel
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.BuscarAlunoResponsavel
    @CodigoAluno        INT = NULL,
    @CodigoResponsavel  INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM cadastro.AlunoResponsavel
    WHERE (@CodigoAluno IS NULL OR CodigoAluno = @CodigoAluno)
      AND (@CodigoResponsavel IS NULL OR CodigoResponsavel = @CodigoResponsavel);
END;
GO
