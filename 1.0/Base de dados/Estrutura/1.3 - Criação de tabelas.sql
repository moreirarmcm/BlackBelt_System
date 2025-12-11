USE BlackBelt_Dev
BEGIN TRY
BEGIN TRAN
DECLARE @ApenasTeste BIT = 0

--===================================================================
--===================================================================


--====================================================================
----=================| Schema Cadastro | =============================
--====================================================================

IF NOT EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'cadastro' and TABLE_NAME = 'Aluno')
BEGIN
	CREATE TABLE cadastro.Aluno (
	    Codigo			INT IDENTITY PRIMARY KEY,
		CodigoPessoa	INT NOT NULL,
		CodigoFilial	INT,
	    Matricula		VARCHAR(50) NOT NULL,
		Apelido			VARCHAR (255),
	    Situacao		INT DEFAULT 1,
		Criacao			DATETIME DEFAULT GETDATE()
	)
	PRINT 'Tabela "cadastro.Aluno" criada!'

END;

IF NOT EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'cadastro' and TABLE_NAME = 'Pessoa')
BEGIN
	CREATE TABLE cadastro.Pessoa (
	    Codigo			INT IDENTITY PRIMARY KEY,
		Nome			VARCHAR (255) NOT NULL,
		CPF				VARCHAR(20) UNIQUE,
		Nascimento		DATE NOT NULL,
		Sexo			CHAR (1),
		PCD				BIT DEFAULT 0
	)
	PRINT 'Tabela "cadastro.Pessoa" criada!'
END;


IF NOT EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'cadastro' and TABLE_NAME = 'Contato')
BEGIN
	CREATE TABLE cadastro.Contato (
	    Codigo			INT IDENTITY PRIMARY KEY,
		CodigoPessoa	INT NOT NULL,
		Logradouro		VARCHAR (255) NOT NULL,
		CEP				VARCHAR(20),
		Cidade			VARCHAR (255),
		UF				CHAR (2),
		Email			VARCHAR(255),
		Telefone		VARCHAR(20),
		Celular			VARCHAR (20)
	)
	PRINT 'Tabela "cadastro.Contato" criada!'
END;

IF NOT EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'cadastro' and TABLE_NAME = 'Responsavel')
BEGIN
	CREATE TABLE cadastro.Responsavel (
	    Codigo			INT IDENTITY PRIMARY KEY,
		Nome			VARCHAR (255) NOT NULL,
		CPF				VARCHAR(20) UNIQUE,
		Nascimento		DATE NOT NULL
	)
	PRINT 'Tabela "cadastro.Responsavel" criada!'
END;

IF NOT EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'cadastro' and TABLE_NAME = 'AlunoResponsavel')
BEGIN
	CREATE TABLE cadastro.AlunoResponsavel (
	    CodigoAluno			INT NOT NULL,
		CodigoResponsavel	INT NOT NULL,
		GrauParentesco		INT,
		Telefone			VARCHAR(20) NOT NULL,
		Ordem 				INT
	)
	PRINT 'Tabela "cadastro.AlunoResponsavel" criada!'
END;

IF NOT EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'cadastro' and TABLE_NAME = 'Academia')
BEGIN
	CREATE TABLE cadastro.Academia(
		Codigo	INT PRIMARY KEY IDENTITY,
		Nome	VARCHAR(255) NOT NULL,
		CNPJ	VARCHAR(255),
		Sigla	VARCHAR (255)
	)
	PRINT 'Tabela "cadastro.Academia" criada!'
END;

IF NOT EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'cadastro' and TABLE_NAME = 'Filial')
BEGIN
	CREATE TABLE cadastro.Filial(
		Codigo				INT PRIMARY KEY IDENTITY,
		CodigoAcademia		INT,
		Nome				VARCHAR(255) NOT NULL,
		Endereco			VARCHAR (255), 
		Cidade				VARCHAR (255),
		UF					CHAR (2),
		CEP					VARCHAR(20) NOT NULL,
		Email				VARCHAR (255),
		Telefone			VARCHAR (255),
		CNPJ				VARCHAR(255),
		Criacao				DATETIME DEFAULT GETDATE(),
		Situacao			BIT DEFAULT 1,
		CodigoOrigem		VARCHAR (255)
	)
	PRINT 'Tabela "cadastro.Filial" criada!'
END;

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'cadastro' AND TABLE_NAME = 'Titulo')
BEGIN
    CREATE TABLE cadastro.Titulo (
        Codigo			INT IDENTITY PRIMARY KEY,
        CodigoAcademia	INT,
        Nome			VARCHAR(255) NOT NULL,
        Descricao		VARCHAR(255),
        Padrao			BIT NOT NULL DEFAULT 0,
        Ordem			INT,
        Criacao			DATETIME NOT NULL DEFAULT GETDATE()
    );
    PRINT 'Tabela "cadastro.Titulo" criada!';
END;

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'cadastro' AND TABLE_NAME = 'AlunoTitulo')
BEGIN
    CREATE TABLE cadastro.AlunoTitulo (
        CodigoAluno		INT NOT NULL,
        CodigoTitulo	INT NOT NULL,
        Inicio			DATETIME NOT NULL DEFAULT GETDATE(),
        Termino			DATETIME,
        Criacao			DATETIME NOT NULL DEFAULT GETDATE(),
    );
    PRINT 'Tabela "cadastro.AlunoTitulo" criada!';
END;

--===================================================================
----=============| Schema Atividade | ===============================
--===================================================================

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'atividade' AND TABLE_NAME = 'Disciplina')
BEGIN
    CREATE TABLE atividade.Disciplina (
        Codigo		INT IDENTITY PRIMARY KEY,
        Nome		VARCHAR(255) NOT NULL,
        Descricao	VARCHAR(255),
        Observacao	VARCHAR(MAX)
    );
    PRINT 'Tabela "atividade.Disciplina" criada!';
END;

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'atividade' AND TABLE_NAME = 'Modalidade')
BEGIN
    CREATE TABLE atividade.Modalidade (
        Codigo				INT IDENTITY PRIMARY KEY,
        CodigoDisciplina	INT NOT NULL,
        Nome				VARCHAR(255) NOT NULL,
        Descricao			VARCHAR(MAX),
        Ordem				INT DEFAULT 1,
        Tipo				VARCHAR(50) 
    );
    PRINT 'Tabela "atividade.Modalidade" criada!';
END;

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'atividade' AND TABLE_NAME = 'FilialModalidade')
BEGIN
    CREATE TABLE atividade.FilialModalidade (
        Codigo				INT IDENTITY PRIMARY KEY,
        CodigoFilial		INT NOT NULL,
        CodigoModalidade	INT NOT NULL,
        Situacao			INT DEFAULT 1,
        Criacao				DATETIME NOT NULL DEFAULT GETDATE()
    );
    PRINT 'Tabela "atividade.FilialModalidade" criada!';
END;

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'atividade' AND TABLE_NAME = 'AlunoFilialModalidade')
BEGIN
    CREATE TABLE atividade.AlunoFilialModalidade (
        CodigoAluno				INT NOT NULL,
        CodigoFilialModalidade	INT NOT NULL,
        DataInicio				DATETIME NOT NULL DEFAULT GETDATE(),
        DataFim					DATETIME,
        Situacao				INT DEFAULT 1
	);
    PRINT 'Tabela "atividade.AlunoFilialModalidade" criada!';
END;

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'atividade' AND TABLE_NAME = 'Aula')
BEGIN
    CREATE TABLE atividade.Aula (
        Codigo					INT IDENTITY PRIMARY KEY,
        CodigoFilialModalidade	INT NOT NULL,
        Data					DATETIME NOT NULL,
        Situacao				INT NOT NULL DEFAULT 1,   
        Criacao					DATETIME NOT NULL DEFAULT GETDATE()
    );

    PRINT 'Tabela "atividade.Aula" criada!';
END;

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'atividade' AND TABLE_NAME = 'AlunoAula')
BEGIN
    CREATE TABLE atividade.AlunoAula (
        CodigoAluno		INT NOT NULL,
        CodigoAula		INT NOT NULL,
        Agendamento		DATETIME,         
        Presenca		BIT,                 
        Situacao		INT NOT NULL DEFAULT 1,   
        Criacao			DATETIME NOT NULL DEFAULT GETDATE(),
    );

    PRINT 'Tabela "atividade.AlunoAula" criada!';
END;


--===================================================================
----=============| Schema Segurança | ===============================
--===================================================================

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'seguranca' AND TABLE_NAME = 'Usuario')
BEGIN
    CREATE TABLE seguranca.Usuario (
        Codigo					INT IDENTITY PRIMARY KEY,
        CodigoAluno				INT NULL,
        Login					VARCHAR(100) NOT NULL,
        Senha					VARBINARY(512) NOT NULL,   
        Email					VARCHAR(255),
        Criacao					DATETIME NOT NULL DEFAULT GETDATE(),
        UltimoAcesso			DATETIME,
        UltimaSenha				DATETIME,
        UltimaAlteracaoSenha	DATETIME,
        Situacao				INT NOT NULL DEFAULT 1
    );
    PRINT 'Tabela "seguranca.Usuario" criada!';
END;

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'seguranca' AND TABLE_NAME = 'Perfil')
BEGIN
    CREATE TABLE seguranca.Perfil (
        Codigo			INT IDENTITY PRIMARY KEY,
        CodigoFilial	INT NULL,
        Nome			VARCHAR(100) NOT NULL,
        Descricao		VARCHAR(255),
        Tipo			VARCHAR(50),      
        Criacao			DATETIME NOT NULL DEFAULT GETDATE(),
        Ativo			BIT NOT NULL DEFAULT 1
    );
    PRINT 'Tabela "seguranca.Perfil" criada!';
END;

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'seguranca' AND TABLE_NAME = 'UsuarioPerfil')
BEGIN
    CREATE TABLE seguranca.UsuarioPerfil (
        CodigoUsuario	INT NOT NULL,
        CodigoPerfil	INT NOT NULL,
        Criacao			DATETIME NOT NULL DEFAULT GETDATE()
    );
    PRINT 'Tabela "seguranca.UsuarioPerfil" criada!';
END;

--===================================================================
--===================================================================

IF @ApenasTeste = 1 BEGIN ROLLBACK; print 'Rollback'; END ELSE BEGIN COMMIT; print 'Commit' END
END TRY
BEGIN CATCH
--SELECT * FROM geral.CapturarErro()
ROLLBACK
END CATCH