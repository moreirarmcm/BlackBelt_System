using BlackBelt.Entidades.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces.Seguranca
{
    public interface IUsuarioDados
    {
        Task<int> InserirAsync(Usuario entidade);
        Task AtualizarAsync(Usuario entidade);
        Task ExcluirAsync(int codigo);

        Task<Usuario> ObterAsync(int codigo);
        Task<Usuario> ObterPorLoginAsync(string login);
        Task<Usuario> ObterPorEmailAsync(string email);
        Task<IEnumerable<Usuario>> ListarAsync();

        Task AtualizarUltimoAcessoAsync(int codigo, DateTime data);
        Task AtualizarSenhaAsync(int codigo, byte[] novaSenha, DateTime dataAlteracao);
        Task AtualizarSituacaoAsync(int codigo, int situacao);
    }
}