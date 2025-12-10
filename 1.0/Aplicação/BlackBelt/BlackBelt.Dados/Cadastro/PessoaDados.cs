using BlackBelt.Dados.Interfaces.Cadastro;
using BlackBelt.Entidades.Cadastro;
using Dados.Database;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackBelt.Dados.Cadastro
{
    public class PessoaDados : IPessoaDados
    {
        private readonly IBlackBeltConexao _conexao;

        public PessoaDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        // ---------------------------------------------------------------------
        // INSERIR
        // ---------------------------------------------------------------------
        public async Task<int> InserirAsync(Pessoa entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Nome,
                entidade.CPF,
                entidade.Nascimento,
                entidade.Sexo,
                entidade.PCD
            };

            return await conn.ExecuteScalarAsync<int>(
                "cadastro.InserirPessoa",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        // ---------------------------------------------------------------------
        // ATUALIZAR
        // ---------------------------------------------------------------------
        public async Task<bool> AtualizarAsync(Pessoa entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Codigo,
                entidade.Nome,
                entidade.CPF,
                entidade.Nascimento,
                entidade.Sexo,
                entidade.PCD
            };

            var afetados = await conn.ExecuteAsync(
                "cadastro.AtualizarPessoa",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return afetados > 0;
        }

        // ---------------------------------------------------------------------
        // EXCLUIR (INATIVAÇÃO LÓGICA)
        // ---------------------------------------------------------------------
        public async Task<bool> ExcluirAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var linhas = await conn.ExecuteScalarAsync<int>(
                "cadastro.ExcluirPessoa",
                new { Codigo = codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );

            return linhas > 0;
        }

        // ---------------------------------------------------------------------
        // OBTER POR CÓDIGO
        // ---------------------------------------------------------------------
        public async Task<Pessoa> ObterPorCodigoAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var lista = await conn.QueryAsync<Pessoa>(
                "cadastro.BuscarPessoa",
                new { Codigo = codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );

            return lista.FirstOrDefault();
        }

        // ---------------------------------------------------------------------
        // OBTER TODOS
        // ---------------------------------------------------------------------
        public async Task<IEnumerable<Pessoa>> ObterTodosAsync()
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<Pessoa>(
                "cadastro.BuscarPessoa",
                new { Codigo = (int?)null },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
