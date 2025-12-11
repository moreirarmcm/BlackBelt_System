/*-----------------------------------------------------------------------------------
Nome procedure: cadastro.AtualizarAluno
-----------------------------------------------------------------------------------
Autor						Data						Descrição
-----------------------------------------------------------------------------------
Renan Moreira				11/11/2025					Criação da procedure

-----------------------------------------------------------------------------------*/

CREATE OR ALTER PROCEDURE cadastro.AtualizarAluno
(
    @Codigo         INT,
    @CodigoFilial   INT = NULL,
    @Apelido        VARCHAR(255) = NULL,
    @Situacao       INT
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE cadastro.Aluno SET	CodigoFilial = @CodigoFilial, 
								Apelido = @Apelido, 
								Situacao = @Situacao
		WHERE Codigo = @Codigo;

    SELECT @@ROWCOUNT AS LinhasAfetadas;
END;

