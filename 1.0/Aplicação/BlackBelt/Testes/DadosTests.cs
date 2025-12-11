using BlackBelt.Dados.Cadastro;
using BlackBelt.Entidades.Cadastro;
using Dados.Database;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes;

namespace Testes
{
    public class DadosTests
    {
        public readonly string conexao_dev;
        

        public  DadosTests()
        {
            var config = TestesConfig.LoadConfig();
            conexao_dev = config.GetConnectionString("BlackBelt");
        }

        [Fact]
        public async Task InserindoAluno()
        {
            var conexao = new BlackBeltConexao(this.conexao_dev);
            var aluno_dados = new AlunoDados(conexao);

            var novoAluno = new Aluno
            {
                CodigoPessoa = 1,
                CodigoFilial = 1,
                Matricula = "2024001",
                Apelido = "Renan Teste",
                Situacao = 1
            };

            var codigo_aluno = await aluno_dados.InserirAsync(novoAluno);

            Assert.True(codigo_aluno > 0);
        }

    }
}