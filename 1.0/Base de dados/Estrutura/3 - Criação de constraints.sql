USE BlackBelt_Dev
BEGIN TRY
BEGIN TRAN
DECLARE @ApenasTeste BIT = 1

--===================================================================
--===================================================================

-------------------------------------------------------
-- TABELA: cadastro.Aluno
-------------------------------------------------------

ALTER TABLE cadastro.Aluno
	ADD CONSTRAINT FK_Aluno_Pessoa
	FOREIGN KEY (CodigoPessoa) REFERENCES cadastro.Pessoa (Codigo)


-------------------------------------------------------
-- TABELA: cadastro.Contato
-------------------------------------------------------

ALTER TABLE cadastro.Contato
	ADD CONSTRAINT FK_Contato_Pessoa
	FOREIGN KEY (CodigoPessoa) REFERENCES cadastro.Pessoa (Codigo)

-------------------------------------------------------
-- TABELA: cadastro.AlunoResponsavel
-------------------------------------------------------

ALTER TABLE cadastro.AlunoResponsavel
	ADD CONSTRAINT FK_AlunoResponsavel_Aluno
	FOREIGN KEY (CodigoAluno) REFERENCES cadastro.Aluno (Codigo)
		ON DELETE CASCADE

ALTER TABLE cadastro.AlunoResponsavel
	ADD CONSTRAINT FK_AlunoResponsavel_Responsavel
		FOREIGN KEY (CodigoResponsavel) REFERENCES cadastro.Responsavel (Codigo)
			ON DELETE CASCADE

-------------------------------------------------------
-- TABELA: atividade.Modalidade
-------------------------------------------------------

ALTER TABLE atividade.Modalidade
	ADD CONSTRAINT FK_Modalidade_Disciplina
	FOREIGN KEY (CodigoDisciplina) REFERENCES atividade.Disciplina (Codigo)

-------------------------------------------------------
-- TABELA: atividade.FilialModalidade
-------------------------------------------------------

ALTER TABLE atividade.FilialModalidade
	ADD CONSTRAINT FK_FilialModalidade_Filial
	FOREIGN KEY (CodigoFilial) REFERENCES cadastro.Filial (Codigo)

ALTER TABLE atividade.FilialModalidade
	ADD CONSTRAINT FK_FilialModalidade_Modalidade
	FOREIGN KEY (CodigoModalidade) REFERENCES atividade.Modalidade (Codigo)

-------------------------------------------------------
-- TABELA: atividade.AlunoFilialModalidade
-------------------------------------------------------

ALTER TABLE atividade.AlunoFilialModalidade
	ADD CONSTRAINT FK_AlunoFilialModalidade_Aluno
	FOREIGN KEY (CodigoAluno) REFERENCES cadastro.Aluno (Codigo)
		ON DELETE CASCADE

ALTER TABLE atividade.AlunoFilialModalidade
	ADD CONSTRAINT FK_AlunoFilialModalidade_FilialModalidade
	FOREIGN KEY (CodigoFilialModalidade) REFERENCES atividade.FilialModalidade (Codigo)
		ON DELETE CASCADE

-------------------------------------------------------
-- TABELA: seguranca.Usuario
-------------------------------------------------------

ALTER TABLE seguranca.Usuario
	ADD CONSTRAINT FK_Usuario_Aluno
	FOREIGN KEY (CodigoAluno) REFERENCES cadastro.Aluno (Codigo)

-------------------------------------------------------
-- TABELA: seguranca.Perfil
-------------------------------------------------------

ALTER TABLE seguranca.Perfil
	ADD CONSTRAINT FK_Perfil_Filial
	FOREIGN KEY (CodigoFilial) REFERENCES cadastro.Filial (Codigo)

-------------------------------------------------------
-- TABELA: seguranca.UsuarioPerfil
-------------------------------------------------------

ALTER TABLE seguranca.UsuarioPerfil
	ADD CONSTRAINT FK_UsuarioPerfil_Usuario
	FOREIGN KEY (CodigoUsuario) REFERENCES seguranca.Usuario (Codigo)
		ON DELETE CASCADE

ALTER TABLE seguranca.UsuarioPerfil
	ADD CONSTRAINT FK_UsuarioPerfil_Perfil
	FOREIGN KEY (CodigoPerfil) REFERENCES seguranca.Perfil (Codigo)
		ON DELETE CASCADE

-------------------------------------------------------
-- TABELA: atividade.Aula
-------------------------------------------------------

-- Aula → FilialModalidade
ALTER TABLE atividade.Aula
	ADD CONSTRAINT FK_Aula_FilialModalidade
	FOREIGN KEY (CodigoFilialModalidade) REFERENCES atividade.FilialModalidade (Codigo)

-------------------------------------------------------
-- TABELA: atividade.AlunoAula
-------------------------------------------------------

ALTER TABLE atividade.AlunoAula
	ADD CONSTRAINT FK_AlunoAula_Aluno
		FOREIGN KEY (CodigoAluno) REFERENCES cadastro.Aluno (Codigo)

ALTER TABLE atividade.AlunoAula
	ADD CONSTRAINT FK_AlunoAula_Aula
	FOREIGN KEY (CodigoAula) REFERENCES atividade.Aula (Codigo)
		ON DELETE CASCADE

-------------------------------------------------------
-- TABELA: cadastro.Titulo
-------------------------------------------------------

ALTER TABLE cadastro.Titulo
	ADD CONSTRAINT FK_Titulo_Academia
	FOREIGN KEY (CodigoAcademia) REFERENCES cadastro.Academia (Codigo)

-------------------------------------------------------
-- TABELA: cadastro.Titulo
-------------------------------------------------------

ALTER TABLE cadastro.AlunoTitulo
	ADD CONSTRAINT FK_AlunoTitulo_Aluno
	FOREIGN KEY (CodigoAluno) REFERENCES cadastro.Aluno (Codigo)

ALTER TABLE cadastro.AlunoTitulo
	ADD CONSTRAINT FK_AlunoTitulo_Titulo
	FOREIGN KEY (CodigoTitulo) REFERENCES cadastro.Titulo (Codigo)
		ON DELETE CASCADE

--===================================================================
--===================================================================

IF @ApenasTeste = 1 BEGIN ROLLBACK; print 'Rollback'; END ELSE BEGIN COMMIT; print 'Commit' END
END TRY
BEGIN CATCH
ROLLBACK
END CATCH

