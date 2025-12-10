using BlackBelt.Entidades.Atividade;
using Dados.Database;
using Dados.Interfaces.Atividade;
using Dapper;

namespace Dados.Atividade
{
    public class FilialModalidadeDados : IFilialModalidadeDados
    {
        private readonly IBlackBeltConexao _conexao;

        public FilialModalidadeDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task<int> InserirAsync(FilialModalidade entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoFilial,
                entidade.CodigoModalidade,
                entidade.Situacao,
                entidade.Criacao
            };

            return await conn.ExecuteScalarAsync<int>(
                "atividade.InserirFilialModalidade",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task AtualizarAsync(FilialModalidade entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Codigo,
                entidade.CodigoFilial,
                entidade.CodigoModalidade,
                entidade.Situacao
            };

            await conn.ExecuteAsync(
                "atividade.AtualizarFilialModalidade",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task ExcluirAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            await conn.ExecuteAsync(
                "atividade.ExcluirFilialModalidade",
                new { codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<FilialModalidade> ObterAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryFirstOrDefaultAsync<FilialModalidade>(
                "atividade.ObterFilialModalidade",
                new { codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<FilialModalidade>> ListarAsync()
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<FilialModalidade>(
                "atividade.ListarFilialModalidade",
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<FilialModalidade>> ListarPorFilialAsync(int codigoFilial)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<FilialModalidade>(
                "atividade.ListarFilialModalidadePorFilial",
                new { codigoFilial },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<FilialModalidade>> ListarPorModalidadeAsync(int codigoModalidade)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<FilialModalidade>(
                "atividade.ListarFilialModalidadePorModalidade",
                new { codigoModalidade },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
