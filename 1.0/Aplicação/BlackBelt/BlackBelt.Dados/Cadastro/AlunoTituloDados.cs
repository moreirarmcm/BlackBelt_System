using BlackBelt.Entidades.Cadastro;
using Dados.Database;
using Dados.Interfaces.Cadastro;
using Dapper;

namespace Dados.Cadastro
{
    public class AlunoTituloDados : IAlunoTituloDados
    {
        private readonly IBlackBeltConexao _conexao;

        public AlunoTituloDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task InserirAsync(AlunoTitulo entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoAluno,
                entidade.CodigoTitulo,
                entidade.Inicio,
                entidade.Termino,
                entidade.Criacao
            };

            await conn.ExecuteAsync(
                "cadastro.InserirAlunoTitulo",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task AtualizarAsync(AlunoTitulo entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoAluno,
                entidade.CodigoTitulo,
                entidade.Inicio,
                entidade.Termino
            };

            await conn.ExecuteAsync(
                "cadastro.AtualizarAlunoTitulo",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task ExcluirAsync(int codigoAluno, int codigoTitulo)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                CodigoAluno = codigoAluno,
                CodigoTitulo = codigoTitulo
            };

            await conn.ExecuteAsync(
                "cadastro.ExcluirAlunoTitulo",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<AlunoTitulo> ObterAsync(int codigoAluno, int codigoTitulo)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                CodigoAluno = codigoAluno,
                CodigoTitulo = codigoTitulo
            };

            return await conn.QueryFirstOrDefaultAsync<AlunoTitulo>(
                "cadastro.BuscarAlunoTitulo",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<AlunoTitulo>> ListarPorAlunoAsync(int codigoAluno)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { CodigoAluno = codigoAluno };

            return await conn.QueryAsync<AlunoTitulo>(
                "cadastro.ListarAlunoTituloPorAluno",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
