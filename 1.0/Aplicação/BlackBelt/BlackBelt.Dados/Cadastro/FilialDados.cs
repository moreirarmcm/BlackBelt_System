using BlackBelt.Entidades.Cadastro;
using Dados.Database;
using Dados.Interfaces.Cadastro;
using Dapper;

namespace Dados.Cadastro
{
    public class FilialDados : IFilialDados
    {
        private readonly IBlackBeltConexao _conexao;

        public FilialDados(IBlackBeltConexao conexao)
        {
            _conexao = conexao;
        }

        public async Task<int> InserirAsync(Filial entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.CodigoAcademia,
                entidade.Nome,
                entidade.Endereco,
                entidade.Cidade,
                entidade.UF,
                entidade.CEP,
                entidade.Email,
                entidade.Telefone,
                entidade.CNPJ,
                entidade.Criacao,
                entidade.Situacao,
                entidade.CodigoOrigem
            };

            return await conn.ExecuteScalarAsync<int>(
                "cadastro.InserirFilial",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task AtualizarAsync(Filial entidade)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new
            {
                entidade.Codigo,
                entidade.CodigoAcademia,
                entidade.Nome,
                entidade.Endereco,
                entidade.Cidade,
                entidade.UF,
                entidade.CEP,
                entidade.Email,
                entidade.Telefone,
                entidade.CNPJ,
                entidade.Situacao,
                entidade.CodigoOrigem
            };

            await conn.ExecuteAsync(
                "cadastro.AtualizarFilial",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task ExcluirAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { Codigo = codigo };

            await conn.ExecuteAsync(
                "cadastro.InativarFilial",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<Filial> ObterAsync(int codigo)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { Codigo = codigo };

            return await conn.QueryFirstOrDefaultAsync<Filial>(
                "cadastro.BuscarFilial",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Filial>> ListarAsync()
        {
            using var conn = _conexao.CriarConexao();

            return await conn.QueryAsync<Filial>(
                "cadastro.ListarFilial",
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Filial>> ListarPorAcademiaAsync(int codigoAcademia)
        {
            using var conn = _conexao.CriarConexao();

            var parametros = new { CodigoAcademia = codigoAcademia };

            return await conn.QueryAsync<Filial>(
                "cadastro.ListarFilialPorAcademia",
                parametros,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
