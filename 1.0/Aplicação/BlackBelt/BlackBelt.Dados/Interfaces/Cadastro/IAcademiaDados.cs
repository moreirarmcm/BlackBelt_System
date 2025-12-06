using BlackBelt.Entidades.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Dados.Interfaces.Cadastro
{
    public interface IAcademiaDados
    {
        Task<int> InserirAsync(Academia entidade);
        Task<bool> AtualizarAsync(Academia entidade);
        Task<bool> ExcluirAsync(int codigo);
        Task<Academia> ObterPorCodigoAsync(int codigo);
        Task<IEnumerable<Academia>> ObterTodosAsync();
    }
}