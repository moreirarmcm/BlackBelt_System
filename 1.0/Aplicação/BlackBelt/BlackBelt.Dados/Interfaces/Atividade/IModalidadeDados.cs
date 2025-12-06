using BlackBelt.Entidades.Atividade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces.Atividade
{
    public interface IModalidadeDados
    {
        Task<int> InserirAsync(Modalidade entidade);
        Task AtualizarAsync(Modalidade entidade);
        Task ExcluirAsync(int codigo);
        Task<Modalidade> ObterAsync(int codigo);
        Task<IEnumerable<Modalidade>> ListarAsync();
        Task<IEnumerable<Modalidade>> ListarPorDisciplinaAsync(int codigoDisciplina);
    }
}