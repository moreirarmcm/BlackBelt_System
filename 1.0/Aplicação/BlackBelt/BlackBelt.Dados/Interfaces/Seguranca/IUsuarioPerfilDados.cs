using BlackBelt.Entidades.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces.Seguranca
{
    public interface IUsuarioPerfilDados
    {
        Task InserirAsync(UsuarioPerfil entidade);
        Task ExcluirAsync(int codigoUsuario, int codigoPerfil);

        Task<UsuarioPerfil> ObterAsync(int codigoUsuario, int codigoPerfil);
        Task<IEnumerable<UsuarioPerfil>> ListarPorUsuarioAsync(int codigoUsuario);
        Task<IEnumerable<UsuarioPerfil>> ListarPorPerfilAsync(int codigoPerfil);
    }
}