using BlackBelt.Entidades.Seguranca;
using Dados.Database;
using Dados.Interfaces.Seguranca;
using Dapper;

namespace Dados.Seguranca
{
    public class PerfilDados : IPerfilDados
    {
        private readonly IBlackBeltConexao _conexao;

        public PerfilDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task<int> InserirAsync(Perfil entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoFilial,
                entidade.Nome,
                entidade.Descricao,
                entidade.Tipo,
                entidade.Criacao,
                entidade.Ativo
            };

            return await conn.ExecuteScalarAsync<int>(
                "seguranca.InserirPerfil",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task AtualizarAsync(Perfil entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Codigo,
                entidade.CodigoFilial,
                entidade.Nome,
                entidade.Descricao,
                entidade.Tipo,
                entidade.Ativo
            };

            await conn.ExecuteAsync(
                "seguranca.AtualizarPerfil",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task ExcluirAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            await conn.ExecuteAsync(
                "seguranca.ExcluirPerfil",
                new { codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<Perfil> ObterAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryFirstOrDefaultAsync<Perfil>(
                "seguranca.ObterPerfil",
                new { codigo },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Perfil>> ListarAsync()
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<Perfil>(
                "seguranca.ListarPerfil",
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Perfil>> ListarPorFilialAsync(int codigoFilial)
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<Perfil>(
                "seguranca.ListarPerfilPorFilial",
                new { codigoFilial },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Perfil>> ListarAtivosAsync()
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<Perfil>(
                "seguranca.ListarPerfilAtivos",
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}

