using BlackBelt.Entidades.Cadastro;
using Dados.Database;
using Dados.Interfaces.Cadastro;
using Dapper;

namespace Dados.Cadastro
{
    public class TituloDados : ITituloDados
    {
        private readonly IBlackBeltConexao _conexao;

        public TituloDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task<int> InserirAsync(Titulo entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoAcademia,
                entidade.Nome,
                entidade.Descricao,
                entidade.Padrao,
                entidade.Ordem,
                entidade.Criacao
            };

            return await conn.ExecuteScalarAsync<int>(
                "cadastro.InserirTitulo",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task AtualizarAsync(Titulo entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Codigo,
                entidade.CodigoAcademia,
                entidade.Nome,
                entidade.Descricao,
                entidade.Padrao,
                entidade.Ordem
            };

            await conn.ExecuteAsync(
                "cadastro.AtualizarTitulo",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task ExcluirAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { Codigo = codigo };

            await conn.ExecuteAsync(
                "cadastro.ExcluirTitulo",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<Titulo> ObterAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { Codigo = codigo };

            return await conn.QueryFirstOrDefaultAsync<Titulo>(
                "cadastro.BuscarTitulo",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Titulo>> ListarAsync()
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<Titulo>(
                "cadastro.ListarTitulo",
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Titulo>> ListarPorAcademiaAsync(int codigoAcademia)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { CodigoAcademia = codigoAcademia };

            return await conn.QueryAsync<Titulo>(
                "cadastro.ListarTituloPorAcademia",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
