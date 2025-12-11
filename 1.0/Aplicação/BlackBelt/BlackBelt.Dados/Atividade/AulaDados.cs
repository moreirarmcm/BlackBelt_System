using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using BlackBelt.Entidades.Atividade;
using Dados.Database;
using Dados.Interfaces.Atividade;

namespace Dados.Atividade
{
    public class AulaDados : IAulaDados
    {
        private readonly IBlackBeltConexao _conexao;

        public AulaDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task<int> InserirAsync(Aula entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoFilialModalidade,
                entidade.Data,
                entidade.Situacao,
                entidade.Criacao
            };

            return await conn.ExecuteScalarAsync<int>(
                "atividade.InserirAula",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task AtualizarAsync(Aula entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Codigo,
                entidade.CodigoFilialModalidade,
                entidade.Data,
                entidade.Situacao
            };

            await conn.ExecuteAsync(
                "atividade.AtualizarAula",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task ExcluirAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { Codigo = codigo };

            await conn.ExecuteAsync(
                "atividade.ExcluirAula",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Aula> ObterAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { Codigo = codigo };

            return await conn.QueryFirstOrDefaultAsync<Aula>(
                "atividade.BuscarAula",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Aula>> ListarAsync()
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<Aula>(
                "atividade.ListarAula",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Aula>> ListarPorFilialModalidadeAsync(int codigoFilialModalidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { CodigoFilialModalidade = codigoFilialModalidade };

            return await conn.QueryAsync<Aula>(
                "atividade.ListarAulaPorFilialModalidade",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}


