using Dados.Database;
using Dapper;
using System.Data;
using BlackBelt.Entidades.Cadastro;
using BlackBelt.Dados.Interfaces.Cadastro;
namespace BlackBelt.Dal.Cadastro
{
    public class AlunoResponsavelDal : IAlunoResponsavelDados
    {
        private readonly IBlackBeltConexao _conexao;

        public AlunoResponsavelDal(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task InserirAsync(
            int codigoAluno,
            int codigoResponsavel,
            int? grauParentesco,
            string telefone,
            int? ordem)
        {
            using var conn = _conexao.CriarConexao();
            await conn.ExecuteAsync(
                "cadastro.InserirAlunoResponsavel",
                new
                {
                    CodigoAluno = codigoAluno,
                    CodigoResponsavel = codigoResponsavel,
                    GrauParentesco = grauParentesco,
                    Telefone = telefone,
                    Ordem = ordem
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task AtualizarAsync(
            int codigoAluno,
            int codigoResponsavel,
            int? grauParentesco,
            string telefone,
            int? ordem)
        {
            using var conn = _conexao.CriarConexao();
            await conn.ExecuteAsync(
                "cadastro.AtualizarAlunoResponsavel",
                new
                {
                    CodigoAluno = codigoAluno,
                    CodigoResponsavel = codigoResponsavel,
                    GrauParentesco = grauParentesco,
                    Telefone = telefone,
                    Ordem = ordem
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task ExcluirAsync(int codigoAluno, int codigoResponsavel)
        {
            using var conn = _conexao.CriarConexao();
            await conn.ExecuteAsync(
                "cadastro.ExcluirAlunoResponsavel",
                new
                {
                    CodigoAluno = codigoAluno,
                    CodigoResponsavel = codigoResponsavel
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AlunoResponsavel>> BuscarAsync(int? codigoAluno, int? codigoResponsavel)
        {
            using var conn = _conexao.CriarConexao();

            var resultado = await conn.QueryAsync<AlunoResponsavel>(
                "cadastro.BuscarAlunoResponsavel",
                new
                {
                    CodigoAluno = codigoAluno,
                    CodigoResponsavel = codigoResponsavel
                },
                commandType: CommandType.StoredProcedure);

            return resultado;
        }

        Task<IEnumerable<AlunoResponsavel>> IAlunoResponsavelDados.BuscarAsync(int? codigoAluno, int? codigoResponsavel)
        {
            throw new NotImplementedException();
        }
    }
}
