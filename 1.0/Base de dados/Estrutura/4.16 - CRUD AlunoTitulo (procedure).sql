---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.InserirAlunoTitulo
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.InserirAlunoTitulo
    @CodigoAluno     INT,
    @CodigoTitulo    INT,
    @Inicio          DATETIME = NULL,
    @Termino         DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO cadastro.AlunoTitulo
        (CodigoAluno, CodigoTitulo, Inicio, Termino)
    VALUES
        (@CodigoAluno, @CodigoTitulo, ISNULL(@Inicio, GETDATE()), @Termino);
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.AtualizarAlunoTitulo
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.AtualizarAlunoTitulo
    @CodigoAluno     INT,
    @CodigoTitulo    INT,
    @Inicio          DATETIME,
    @Termino         DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE cadastro.AlunoTitulo
    SET Inicio = @Inicio,
        Termino = @Termino
    WHERE CodigoAluno = @CodigoAluno
      AND CodigoTitulo = @CodigoTitulo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.ExcluirAlunoTitulo
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.ExcluirAlunoTitulo
    @CodigoAluno     INT,
    @CodigoTitulo    INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM cadastro.AlunoTitulo
    WHERE CodigoAluno = @CodigoAluno
      AND CodigoTitulo = @CodigoTitulo;
END;
GO


---------------------------------------------------------------------------------------
-- PROCEDURE: cadastro.BuscarAlunoTitulo
---------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE cadastro.BuscarAlunoTitulo
    @CodigoAluno     INT = NULL,
    @CodigoTitulo    INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM cadastro.AlunoTitulo
    WHERE (@CodigoAluno IS NULL OR CodigoAluno = @CodigoAluno)
      AND (@CodigoTitulo IS NULL OR CodigoTitulo = @CodigoTitulo);
END;
GO
