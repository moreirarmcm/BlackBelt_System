using BlackBelt.Dados.Interfaces.Cadastro;
using BlackBelt.Entidades.Cadastro;
using Dados.Database;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Dados.Cadastro
{
    public class AcademiaDados : IAcademiaDados
    {
        private readonly IBlackBeltConexao _conexao;

        public AcademiaDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        // ---------------------------------------------------------------------
        // INSERIR
        // ---------------------------------------------------------------------
        public async Task<int> InserirAsync(Academia entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Nome,
                entidade.CNPJ,
                entidade.Sigla
            };

            var codigo = await conn.ExecuteScalarAsync<int>(
                "cadastro.InserirAcademia",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            return codigo;
        }

        // ---------------------------------------------------------------------
        // ATUALIZAR
        // ---------------------------------------------------------------------
        public async Task<bool> AtualizarAsync(Academia entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Codigo,
                entidade.Nome,
                entidade.CNPJ,
                entidade.Sigla
            };

            var linhas = await conn.ExecuteScalarAsync<int>(
                "cadastro.AtualizarAcademia",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            return linhas > 0;
        }

        // ---------------------------------------------------------------------
        // EXCLUIR
        // ---------------------------------------------------------------------
        public async Task<bool> ExcluirAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var linhas = await conn.ExecuteScalarAsync<int>(
                "cadastro.ExcluirAcademia",
                new { Codigo = codigo },
                commandType: CommandType.StoredProcedure
            );

            return linhas > 0;
        }

        // ---------------------------------------------------------------------
        // OBTER POR CÓDIGO
        // ---------------------------------------------------------------------
        public async Task<Academia> ObterPorCodigoAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var lista = await conn.QueryAsync<Academia>(
                "cadastro.BuscarAcademia",
                new { Codigo = codigo },
                commandType: CommandType.StoredProcedure
            );

            return lista.FirstOrDefault();
        }

        // ---------------------------------------------------------------------
        // OBTER TODOS
        // ---------------------------------------------------------------------
        public async Task<IEnumerable<Academia>> ObterTodosAsync()
        {
            using var conn = _conexao.CriarConexao();

            var lista = await conn.QueryAsync<Academia>(
                "cadastro.BuscarAcademia",
                new { Codigo = (int?)null },
                commandType: CommandType.StoredProcedure
            );

            return lista;
        }
    }
}
