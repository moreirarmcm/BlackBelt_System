---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.InserirAlunoAula
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.InserirAlunoAula
    @CodigoAluno     INT,
    @CodigoAula      INT,
    @Agendamento     DATETIME = NULL,
    @Presenca        BIT = NULL,
    @Situacao        INT = 1
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO atividade.AlunoAula
        (CodigoAluno, CodigoAula, Agendamento, Presenca, Situacao)
    VALUES
        (@CodigoAluno, @CodigoAula, @Agendamento, @Presenca, @Situacao);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.AtualizarAlunoAula
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.AtualizarAlunoAula
    @CodigoAluno     INT,
    @CodigoAula      INT,
    @Agendamento     DATETIME = NULL,
    @Presenca        BIT = NULL,
    @Situacao        INT = 1
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE atividade.AlunoAula
    SET Agendamento = @Agendamento,
        Presenca    = @Presenca,
        Situacao    = @Situacao
    WHERE CodigoAluno = @CodigoAluno
      AND CodigoAula = @CodigoAula;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.ExcluirAlunoAula
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.ExcluirAlunoAula
    @CodigoAluno     INT,
    @CodigoAula      INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM atividade.AlunoAula
    WHERE CodigoAluno = @CodigoAluno
      AND CodigoAula = @CodigoAula;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: atividade.BuscarAlunoAula
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE atividade.BuscarAlunoAula
    @CodigoAluno     INT = NULL,
    @CodigoAula      INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM atividade.AlunoAula
    WHERE (@CodigoAluno IS NULL OR CodigoAluno = @CodigoAluno)
      AND (@CodigoAula IS NULL OR CodigoAula = @CodigoAula);
END;
GO
