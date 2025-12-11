/*-----------------------------------------------------------------------------------
Nome procedure: cadastro.InserirAluno
-----------------------------------------------------------------------------------
Autor						Data						Descrição
-----------------------------------------------------------------------------------
Renan Moreira				11/11/2025					Criação da procedure

-----------------------------------------------------------------------------------*/

CREATE OR ALTER PROCEDURE cadastro.InserirAluno
(
    @CodigoPessoa   INT,
    @CodigoFilial   INT = NULL,
    @Matricula      VARCHAR(50),
    @Apelido        VARCHAR(255) = NULL,
    @Situacao       INT = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

	IF (@Situacao IS NULL)
	BEGIN
		INSERT INTO cadastro.Aluno
			(CodigoPessoa,	CodigoFilial,	Matricula,	Apelido,	Criacao)
		VALUES
			(@CodigoPessoa, @CodigoFilial,	@Matricula, @Apelido,	GETDATE())
	END;
	ELSE
	BEGIN
		INSERT INTO cadastro.Aluno
		    (CodigoPessoa,	CodigoFilial,	Matricula,	Apelido,	Situacao,	Criacao)
		VALUES
		    (@CodigoPessoa, @CodigoFilial,	@Matricula, @Apelido,	@Situacao,	GETDATE())
	END;

    SELECT SCOPE_IDENTITY() AS Codigo
END;