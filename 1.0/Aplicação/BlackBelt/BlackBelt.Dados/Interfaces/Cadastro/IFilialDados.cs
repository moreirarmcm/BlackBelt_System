using BlackBelt.Entidades.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces.Cadastro
{
    public interface IFilialDados
    {
        Task<int> InserirAsync(Filial entidade);
        Task AtualizarAsync(Filial entidade);
        Task ExcluirAsync(int codigo);
        Task<Filial> ObterAsync(int codigo);
        Task<IEnumerable<Filial>> ListarAsync();
        Task<IEnumerable<Filial>> ListarPorAcademiaAsync(int codigoAcademia);
    }
}
