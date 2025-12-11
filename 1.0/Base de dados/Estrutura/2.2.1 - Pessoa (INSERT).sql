/*-----------------------------------------------------------------------------------
Nome procedure: cadastro.InserirPessoa
-----------------------------------------------------------------------------------
Autor						Data						Descrição
-----------------------------------------------------------------------------------
Renan Moreira				11/11/2025					Criação da procedure

-----------------------------------------------------------------------------------*/

CREATE OR ALTER PROCEDURE cadastro.InserirPessoa
(
    @Nome        VARCHAR(255),
    @CPF         VARCHAR(11) = NULL,
    @Nascimento  DATE,
    @Sexo        CHAR(1) = NULL,
    @PCD         BIT = 0
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO cadastro.Pessoa 
				(Nome,	CPF,	Nascimento,		Sexo,	PCD)
		VALUES	(@Nome, @CPF,	@Nascimento,	@Sexo,	@PCD);

	SELECT SCOPE_IDENTITY() AS CodigoPessoa
END;




