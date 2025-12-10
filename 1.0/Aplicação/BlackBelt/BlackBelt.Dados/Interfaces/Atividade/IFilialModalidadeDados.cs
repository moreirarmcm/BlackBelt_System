using BlackBelt.Entidades.Atividade;

namespace Dados.Interfaces.Atividade
{
    public interface IFilialModalidadeDados
    {
        Task<int> InserirAsync(FilialModalidade entidade);
        Task AtualizarAsync(FilialModalidade entidade);
        Task ExcluirAsync(int codigo);
        Task<FilialModalidade> ObterAsync(int codigo);
        Task<IEnumerable<FilialModalidade>> ListarAsync();
        Task<IEnumerable<FilialModalidade>> ListarPorFilialAsync(int codigoFilial);
        Task<IEnumerable<FilialModalidade>> ListarPorModalidadeAsync(int codigoModalidade);
    }
}
