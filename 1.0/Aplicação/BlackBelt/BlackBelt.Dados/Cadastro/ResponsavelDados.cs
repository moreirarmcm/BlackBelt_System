using BlackBelt.Dados.Interfaces.Cadastro;
using BlackBelt.Entidades.Cadastro;
using Dados.Database;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dados.Cadastro
{
    public class ResponsavelDados : IResponsavelDados
    {
        private readonly IBlackBeltConexao _conexao;

        public ResponsavelDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        // ---------------------------------------------------------------------
        // INSERIR
        // ---------------------------------------------------------------------
        public async Task<int> InserirAsync(Responsavel entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Nome,
                entidade.CPF,
                entidade.Nascimento
            };

            return await conn.ExecuteScalarAsync<int>(
                "cadastro.InserirResponsavel",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        // ---------------------------------------------------------------------
        // ATUALIZAR
        // ---------------------------------------------------------------------
        public async Task<bool> AtualizarAsync(Responsavel entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Codigo,
                entidade.Nome,
                entidade.CPF,
                entidade.Nascimento
            };

            var linhas = await conn.ExecuteScalarAsync<int>(
                "cadastro.AtualizarResponsavel",
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
                "cadastro.ExcluirResponsavel",
                new { Codigo = codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );

            return linhas > 0;
        }

        // ---------------------------------------------------------------------
        // OBTER POR CÓDIGO
        // ---------------------------------------------------------------------
        public async Task<Responsavel> ObterPorCodigoAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var lista = await conn.QueryAsync<Responsavel>(
                "cadastro.BuscarResponsavel",
                new { Codigo = codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );

            return lista.FirstOrDefault();
        }

        // ---------------------------------------------------------------------
        // OBTER TODOS
        // ---------------------------------------------------------------------
        public async Task<IEnumerable<Responsavel>> ObterTodosAsync()
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<Responsavel>(
                "cadastro.BuscarResponsavel",
                new { Codigo = (int?)null },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
