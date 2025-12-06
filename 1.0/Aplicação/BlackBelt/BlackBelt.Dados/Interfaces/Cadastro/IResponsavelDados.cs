using BlackBelt.Entidades.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Dados.Interfaces.Cadastro
{
    public interface IResponsavelDados
    {
        Task<int> InserirAsync(Responsavel entidade);
        Task<bool> AtualizarAsync(Responsavel entidade);
        Task<bool> ExcluirAsync(int codigo);
        Task<Responsavel> ObterPorCodigoAsync(int codigo);
        Task<IEnumerable<Responsavel>> ObterTodosAsync();
    }
}