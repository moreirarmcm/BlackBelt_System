/*-----------------------------------------------------------------------------------
Nome procedure: cadastro.ExcluirAluno
-----------------------------------------------------------------------------------
Autor						Data						Descrição
-----------------------------------------------------------------------------------
Renan Moreira				11/11/2025					Criação da procedure

-----------------------------------------------------------------------------------*/

CREATE OR ALTER PROCEDURE cadastro.ExcluirAluno
(
    @CodigoAluno	INT,
	@NovaSituacao	INT
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE cadastro.Aluno SET Situacao = @NovaSituacao
		WHERE Codigo = @CodigoAluno;

    SELECT @@ROWCOUNT AS LinhasAfetadas;
END;


