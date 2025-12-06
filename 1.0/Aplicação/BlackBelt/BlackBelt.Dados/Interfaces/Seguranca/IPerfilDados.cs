using BlackBelt.Entidades.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces.Seguranca
{
    public interface IPerfilDados
    {
        Task<int> InserirAsync(Perfil entidade);
        Task AtualizarAsync(Perfil entidade);
        Task ExcluirAsync(int codigo);
        Task<Perfil> ObterAsync(int codigo);
        Task<IEnumerable<Perfil>> ListarAsync();
        Task<IEnumerable<Perfil>> ListarPorFilialAsync(int codigoFilial);
        Task<IEnumerable<Perfil>> ListarAtivosAsync();
    }
}