/*-----------------------------------------------------------------------------------
Nome procedure: cadastro.BuscarAluno
-----------------------------------------------------------------------------------
Autor						Data						Descrição
-----------------------------------------------------------------------------------
Renan Moreira				11/11/2025					Criação da procedure

-----------------------------------------------------------------------------------*/

CREATE OR ALTER PROCEDURE cadastro.BuscarAluno
(
    @CodigoAluno		INT = NULL,
	@CodigoFilial		INT,
	@CodigoAcademia		INT = NULL
)
AS
BEGIN
    SET NOCOUNT ON;
	
    IF (@CodigoAluno IS NULL)
    BEGIN
		IF (@CodigoAcademia IS NULL)
		BEGIN
			SELECT *
				FROM cadastro.Aluno alu
					WHERE CodigoFilial = @CodigoFilial
					ORDER BY Matricula;
		END; 
		ELSE
		BEGIN
			SELECT *
				FROM cadastro.Aluno alu
					JOIN cadastro.Filial fil ON fil.Codigo = alu.CodigoFilial
				WHERE fil.CodigoAcademia = @CodigoAcademia
					ORDER BY Matricula;
		END;
	END;
    ELSE
    BEGIN
        SELECT *
			FROM cadastro.Aluno
			WHERE Codigo = @CodigoAluno;
    END;
END;


