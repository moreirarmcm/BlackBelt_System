using BlackBelt.Entidades.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces.Cadastro
{
    public interface IContatoDados
    {
        Task<int> InserirAsync(Contato entidade);
        Task AtualizarAsync(Contato entidade);
        Task ExcluirAsync(int codigo);
        Task<Contato> ObterAsync(int codigo);
        Task<IEnumerable<Contato>> ListarPorPessoaAsync(int codigoPessoa);
    }
}
