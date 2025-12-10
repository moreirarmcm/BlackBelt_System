using BlackBelt.Entidades.Atividade;
using Dados.Database;
using Dados.Interfaces.Atividade;
using Dapper;

namespace Dados.Atividade
{
    public class DisciplinaDados : IDisciplinaDados
    {
        private readonly IBlackBeltConexao _conexao;

        public DisciplinaDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task<int> InserirAsync(Disciplina entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Nome,
                entidade.Descricao,
                entidade.Observacao
            };

            return await conn.ExecuteScalarAsync<int>(
                "atividade.InserirDisciplina",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task AtualizarAsync(Disciplina entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Codigo,
                entidade.Nome,
                entidade.Descricao,
                entidade.Observacao
            };

            await conn.ExecuteAsync(
                "atividade.AtualizarDisciplina",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task ExcluirAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            await conn.ExecuteAsync(
                "atividade.ExcluirDisciplina",
                new { codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<Disciplina> ObterAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryFirstOrDefaultAsync<Disciplina>(
                "atividade.ObterDisciplina",
                new { codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Disciplina>> ListarAsync()
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<Disciplina>(
                "atividade.ListarDisciplinas",
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
