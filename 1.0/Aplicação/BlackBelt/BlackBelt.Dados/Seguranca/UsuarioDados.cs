using BlackBelt.Entidades.Seguranca;
using Dados.Database;
using Dados.Interfaces.Seguranca;
using Dapper;

namespace Dados.Seguranca
{
    public class UsuarioDados : IUsuarioDados
    {
        private readonly IBlackBeltConexao _conexao;

        public UsuarioDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task<int> InserirAsync(Usuario entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoAluno,
                entidade.Login,
                entidade.Senha,
                entidade.Email,
                entidade.Criacao,
                entidade.UltimoAcesso,
                entidade.UltimaSenha,
                entidade.UltimaAlteracaoSenha,
                entidade.Situacao
            };

            return await conn.ExecuteScalarAsync<int>(
                "seguranca.InserirUsuario",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task AtualizarAsync(Usuario entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Codigo,
                entidade.CodigoAluno,
                entidade.Login,
                entidade.Senha,
                entidade.Email,
                entidade.UltimoAcesso,
                entidade.UltimaSenha,
                entidade.UltimaAlteracaoSenha,
                entidade.Situacao
            };

            await conn.ExecuteAsync(
                "seguranca.AtualizarUsuario",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task ExcluirAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            await conn.ExecuteAsync(
                "seguranca.ExcluirUsuario",
                new { codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<Usuario> ObterAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryFirstOrDefaultAsync<Usuario>(
                "seguranca.ObterUsuario",
                new { codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<Usuario> ObterPorLoginAsync(string login)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryFirstOrDefaultAsync<Usuario>(
                "seguranca.ObterUsuarioPorLogin",
                new { login },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryFirstOrDefaultAsync<Usuario>(
                "seguranca.ObterUsuarioPorEmail",
                new { email },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Usuario>> ListarAsync()
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<Usuario>(
                "seguranca.ListarUsuario",
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task AtualizarUltimoAcessoAsync(int codigo, DateTime data)
        {
            using var conn = _conexao.CriarConexao();

            await conn.ExecuteAsync(
                "seguranca.AtualizarUsuarioUltimoAcesso",
                new { codigo, data },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task AtualizarSenhaAsync(int codigo, byte[] novaSenha, DateTime dataAlteracao)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                codigo,
                novaSenha,
                dataAlteracao
            };

            await conn.ExecuteAsync(
                "seguranca.AtualizarUsuarioSenha",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task AtualizarSituacaoAsync(int codigo, int situacao)
        {
            using var conn = _conexao.CriarConexao();

            await conn.ExecuteAsync(
                "seguranca.AtualizarUsuarioSituacao",
                new { codigo, situacao },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
