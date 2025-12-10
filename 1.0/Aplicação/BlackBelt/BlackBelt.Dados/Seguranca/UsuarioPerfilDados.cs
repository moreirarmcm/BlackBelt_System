using BlackBelt.Entidades.Seguranca;
using Dados.Database;
using Dados.Interfaces.Seguranca;
using Dapper;

namespace Dados.Seguranca
{
    public class UsuarioPerfilDados : IUsuarioPerfilDados
    {
        private readonly IBlackBeltConexao _conexao;

        public UsuarioPerfilDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task InserirAsync(UsuarioPerfil entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoUsuario,
                entidade.CodigoPerfil,
                entidade.Criacao
            };

            await conn.ExecuteAsync(
                "seguranca.InserirUsuarioPerfil",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task ExcluirAsync(int codigoUsuario, int codigoPerfil)
        {
            using var conn = _conexao.CriarConexao();

            await conn.ExecuteAsync(
                "seguranca.ExcluirUsuarioPerfil",
                new { codigoUsuario, codigoPerfil },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<UsuarioPerfil> ObterAsync(int codigoUsuario, int codigoPerfil)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryFirstOrDefaultAsync<UsuarioPerfil>(
                "seguranca.ObterUsuarioPerfil",
                new { codigoUsuario, codigoPerfil },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<UsuarioPerfil>> ListarPorUsuarioAsync(int codigoUsuario)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<UsuarioPerfil>(
                "seguranca.ListarUsuarioPerfilPorUsuario",
                new { codigoUsuario },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<UsuarioPerfil>> ListarPorPerfilAsync(int codigoPerfil)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<UsuarioPerfil>(
                "seguranca.ListarUsuarioPerfilPorPerfil",
                new { codigoPerfil },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
