using BlackBelt.Dados.Interfaces.Cadastro;
using BlackBelt.Entidades.Cadastro;
using Dados.Database;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBelt.Dados.Cadastro
{
    public class AlunoDados : IAlunoDados
    {
        private readonly IBlackBeltConexao _conexao;

        public AlunoDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        // ---------------------------------------------------------------------
        // INSERIR
        // ---------------------------------------------------------------------
        public async Task<int> InserirAsync(Aluno entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoPessoa,
                entidade.CodigoFilial,
                entidade.Matricula,
                entidade.Apelido,
                entidade.Situacao
            };

            return await conn.ExecuteScalarAsync<int>(
                "cadastro.InserirAluno",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        // ---------------------------------------------------------------------
        // ATUALIZAR
        // ---------------------------------------------------------------------
        public async Task<bool> AtualizarAsync(Aluno entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Codigo,
                entidade.CodigoPessoa,
                entidade.CodigoFilial,
                entidade.Matricula,
                entidade.Apelido,
                entidade.Situacao
            };

            var linhas = await conn.ExecuteScalarAsync<int>(
                "cadastro.AtualizarAluno",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return linhas > 0;
        }

        // ---------------------------------------------------------------------
        // EXCLUIR (INATIVAÇÃO LÓGICA)
        // ---------------------------------------------------------------------
        public async Task<bool> ExcluirAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var linhas = await conn.ExecuteScalarAsync<int>(
                "cadastro.ExcluirAluno",
                new { Codigo = codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );

            return linhas > 0;
        }

        // ---------------------------------------------------------------------
        // OBTER POR CÓDIGO
        // ---------------------------------------------------------------------
        public async Task<Aluno> ObterPorCodigoAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var lista = await conn.QueryAsync<Aluno>(
                "cadastro.BuscarAluno",
                new { Codigo = codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );

            return lista.FirstOrDefault();
        }

        // ---------------------------------------------------------------------
        // OBTER TODOS
        // ---------------------------------------------------------------------
        public async Task<IEnumerable<Aluno>> ObterTodosAsync()
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<Aluno>(
                "cadastro.BuscarAluno",
                new { Codigo = (int?)null },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
