/*-----------------------------------------------------------------------------------
Nome procedure: cadastro.AtualizarPessoa
-----------------------------------------------------------------------------------
Autor						Data						Descrição
-----------------------------------------------------------------------------------
Renan Moreira				11/11/2025					Criação da procedure

-----------------------------------------------------------------------------------*/

CREATE OR ALTER PROCEDURE cadastro.AtualizarPessoa
(
	@Codigo      INT,
    @Nome        VARCHAR(255),
    --@CPF         VARCHAR(11) = NULL,
    @Nascimento  DATE,
    @Sexo        CHAR(1) = NULL,
    @PCD         BIT = 0
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE cadastro.Pessoa SET	Nome = @Nome,
								--CPF = @CPF,
								Nascimento = @Nascimento,
								Sexo = @Sexo,
								PCD = @PCD
		WHERE Codigo = @Codigo;
	END;





