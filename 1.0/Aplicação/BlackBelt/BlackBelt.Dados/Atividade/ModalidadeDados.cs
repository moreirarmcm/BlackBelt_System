using BlackBelt.Entidades.Atividade;
using Dados.Database;
using Dados.Interfaces.Atividade;
using Dapper;

namespace Dados.Atividade
{
    public class ModalidadeDados : IModalidadeDados
    {
        private readonly IBlackBeltConexao _conexao;

        public ModalidadeDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task<int> InserirAsync(Modalidade entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoDisciplina,
                entidade.Nome,
                entidade.Descricao,
                entidade.Ordem,
                entidade.Tipo
            };

            return await conn.ExecuteScalarAsync<int>(
                "atividade.InserirModalidade",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task AtualizarAsync(Modalidade entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Codigo,
                entidade.CodigoDisciplina,
                entidade.Nome,
                entidade.Descricao,
                entidade.Ordem,
                entidade.Tipo
            };

            await conn.ExecuteAsync(
                "atividade.AtualizarModalidade",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task ExcluirAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            await conn.ExecuteAsync(
                "atividade.ExcluirModalidade",
                new { codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<Modalidade> ObterAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryFirstOrDefaultAsync<Modalidade>(
                "atividade.ObterModalidade",
                new { codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Modalidade>> ListarAsync()
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<Modalidade>(
                "atividade.ListarModalidades",
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Modalidade>> ListarPorDisciplinaAsync(int codigoDisciplina)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<Modalidade>(
                "atividade.ListarModalidadesPorDisciplina",
                new { codigoDisciplina },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
