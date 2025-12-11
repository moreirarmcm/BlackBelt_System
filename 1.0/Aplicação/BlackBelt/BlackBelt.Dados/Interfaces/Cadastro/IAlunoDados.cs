using BlackBelt.Entidades.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Dados.Interfaces.Cadastro
{
    public interface IAlunoDados
    {
        Task<int> InserirAsync(Aluno entidade);
        Task<bool> AtualizarAsync(Aluno entidade);
        Task<bool> ExcluirAsync(int codigo); // exclusão lógica, conforme o sistema
        Task<Aluno> ObterPorCodigoAsync(int codigo);
        Task<IEnumerable<Aluno>> ObterTodosAsync();
    }
}