using BlackBelt.Entidades.Atividade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces.Atividade
{
    public interface IAulaDados
    {
        Task<int> InserirAsync(Aula entidade);
        Task AtualizarAsync(Aula entidade);
        Task ExcluirAsync(int codigo);
        Task<Aula> ObterAsync(int codigo);
        Task<IEnumerable<Aula>> ListarAsync();
        Task<IEnumerable<Aula>> ListarPorFilialModalidadeAsync(int codigoFilialModalidade);
    }
}