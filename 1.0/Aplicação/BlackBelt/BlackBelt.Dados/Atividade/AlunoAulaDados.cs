using BlackBelt.Entidades.Atividade;
using Dados.Database;
using Dados.Interfaces.Atividade;
using Dapper;

namespace Dados.Atividade
{
    public class AlunoAulaDados : IAlunoAulaDados
    {
        private readonly IBlackBeltConexao _conexao;

        public AlunoAulaDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task<int> InserirAsync(AlunoAula entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoAluno,
                entidade.CodigoAula,
                entidade.Presenca,
                entidade.Observacao,
                entidade.Criacao
            };

            return await conn.ExecuteScalarAsync<int>(
                "atividade.InserirAlunoAula",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task AtualizarAsync(AlunoAula entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoAluno,
                entidade.CodigoAula,
                entidade.Presenca,
                entidade.Observacao
            };

            await conn.ExecuteAsync(
                "atividade.AtualizarAlunoAula",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task ExcluirAsync(int codigoAluno, int codigoAula)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                CodigoAluno = codigoAluno,
                CodigoAula = codigoAula
            };

            await conn.ExecuteAsync(
                "atividade.ExcluirAlunoAula",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<AlunoAula> ObterAsync(int codigoAluno, int codigoAula)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                CodigoAluno = codigoAluno,
                CodigoAula = codigoAula
            };

            return await conn.QueryFirstOrDefaultAsync<AlunoAula>(
                "atividade.BuscarAlunoAula",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<AlunoAula>> ListarPorAulaAsync(int codigoAula)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { CodigoAula = codigoAula };

            return await conn.QueryAsync<AlunoAula>(
                "atividade.ListarAlunoAulaPorAula",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<AlunoAula>> ListarPorAlunoAsync(int codigoAluno)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { CodigoAluno = codigoAluno };

            return await conn.QueryAsync<AlunoAula>(
                "atividade.ListarAlunoAulaPorAluno",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
