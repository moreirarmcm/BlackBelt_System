using BlackBelt.Entidades.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces.Cadastro
{
    public interface ITituloDados
    {
        Task<int> InserirAsync(Titulo entidade);
        Task AtualizarAsync(Titulo entidade);
        Task ExcluirAsync(int codigo);
        Task<Titulo> ObterAsync(int codigo);
        Task<IEnumerable<Titulo>> ListarAsync();
        Task<IEnumerable<Titulo>> ListarPorAcademiaAsync(int codigoAcademia);
    }
}