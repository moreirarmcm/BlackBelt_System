using BlackBelt.Entidades.Cadastro;
using Dados.Database;
using Dados.Interfaces.Cadastro;
using Dapper;

namespace Dados.Cadastro
{
    public class ContatoDados : IContatoDados
    {
        private readonly IBlackBeltConexao _conexao;

        public ContatoDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task<int> InserirAsync(Contato entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoPessoa,
                entidade.Logradouro,
                entidade.CEP,
                entidade.Cidade,
                entidade.UF,
                entidade.Email,
                entidade.Telefone,
                entidade.Celular
            };

            return await conn.ExecuteScalarAsync<int>(
                "cadastro.InserirContato",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<bool> AtualizarAsync(Contato entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Codigo,
                entidade.CodigoPessoa,
                entidade.Logradouro,
                entidade.CEP,
                entidade.Cidade,
                entidade.UF,
                entidade.Email,
                entidade.Telefone,
                entidade.Celular
            };

            int linhas = await conn.ExecuteAsync(
                "cadastro.AtualizarContato",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return linhas > 0;
        }

        public async Task<bool> ExcluirAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { Codigo = codigo };

            int linhas = await conn.ExecuteAsync(
                "cadastro.ExcluirContato",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return linhas > 0;
        }

        public async Task<Contato?> ObterAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { Codigo = codigo };

            return await conn.QueryFirstOrDefaultAsync<Contato>(
                "cadastro.BuscarContato",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Contato>> ListarPorPessoaAsync(int codigoPessoa)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { CodigoPessoa = codigoPessoa };

            return await conn.QueryAsync<Contato>(
                "cadastro.BuscarContato",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        Task IContatoDados.AtualizarAsync(Contato entidade) => AtualizarAsync(entidade);
        Task IContatoDados.ExcluirAsync(int codigo) => ExcluirAsync(codigo);
    }
}
