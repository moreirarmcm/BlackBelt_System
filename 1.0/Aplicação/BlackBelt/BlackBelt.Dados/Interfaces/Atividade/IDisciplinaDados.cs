using BlackBelt.Entidades.Atividade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces.Atividade
{
    public interface IDisciplinaDados
    {
        Task<int> InserirAsync(Disciplina entidade);
        Task AtualizarAsync(Disciplina entidade);
        Task ExcluirAsync(int codigo);
        Task<Disciplina> ObterAsync(int codigo);
        Task<IEnumerable<Disciplina>> ListarAsync();
    }
}