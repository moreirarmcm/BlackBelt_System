using BlackBelt.Entidades.Atividade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces.Atividade
{
    public interface IAlunoFilialModalidadeDados
    {
        Task InserirAsync(AlunoFilialModalidade entidade);
        Task AtualizarAsync(AlunoFilialModalidade entidade);
        Task ExcluirAsync(int codigoAluno, int codigoFilialModalidade);
        Task<AlunoFilialModalidade> ObterAsync(int codigoAluno, int codigoFilialModalidade);
        Task<IEnumerable<AlunoFilialModalidade>> ListarPorAlunoAsync(int codigoAluno);
        Task<IEnumerable<AlunoFilialModalidade>> ListarPorFilialModalidadeAsync(int codigoFilialModalidade);
    }
}