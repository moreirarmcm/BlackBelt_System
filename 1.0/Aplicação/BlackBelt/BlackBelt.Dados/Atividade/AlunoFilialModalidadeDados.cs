using BlackBelt.Entidades.Atividade;
using Dados.Database;
using Dados.Interfaces.Atividade;
using Dapper;

namespace Dados.Atividade
{
    public class AlunoFilialModalidadeDados : IAlunoFilialModalidadeDados
    {
        private readonly IBlackBeltConexao _conexao;

        public AlunoFilialModalidadeDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task InserirAsync(AlunoFilialModalidade entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoAluno,
                entidade.CodigoFilialModalidade,
                entidade.DataInicio,
                entidade.DataFim,
                entidade.Situacao
            };

            await conn.ExecuteAsync(
                "atividade.InserirAlunoFilialModalidade",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task AtualizarAsync(AlunoFilialModalidade entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoAluno,
                entidade.CodigoFilialModalidade,
                entidade.DataInicio,
                entidade.DataFim,
                entidade.Situacao
            };

            await conn.ExecuteAsync(
                "atividade.AtualizarAlunoFilialModalidade",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task ExcluirAsync(int codigoAluno, int codigoFilialModalidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                codigoAluno,
                codigoFilialModalidade
            };

            await conn.ExecuteAsync(
                "atividade.ExcluirAlunoFilialModalidade",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<AlunoFilialModalidade> ObterAsync(int codigoAluno, int codigoFilialModalidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                codigoAluno,
                codigoFilialModalidade
            };

            return await conn.QueryFirstOrDefaultAsync<AlunoFilialModalidade>(
                "atividade.ObterAlunoFilialModalidade",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<AlunoFilialModalidade>> ListarPorAlunoAsync(int codigoAluno)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<AlunoFilialModalidade>(
                "atividade.ListarAlunoFilialModalidadePorAluno",
                new { codigoAluno },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<AlunoFilialModalidade>> ListarPorFilialModalidadeAsync(int codigoFilialModalidade)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<AlunoFilialModalidade>(
                "atividade.ListarAlunoFilialModalidadePorFilialModalidade",
                new { codigoFilialModalidade },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
