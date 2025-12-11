using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlackBelt.Entidades.Cadastro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackBelt.Dados.Interfaces.Cadastro
{
    public interface IPessoaDados
    {
        Task<int> InserirAsync(Pessoa entidade);
        Task<bool> AtualizarAsync(Pessoa entidade);
        Task<bool> ExcluirAsync(int codigo);
        Task<Pessoa> ObterPorCodigoAsync(int codigo);
        Task<IEnumerable<Pessoa>> ObterTodosAsync();
    }
}