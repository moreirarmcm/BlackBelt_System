using BlackBelt.Entidades.Atividade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces.Atividade
{
    public interface IAlunoAulaDados
    {
        Task<int> InserirAsync(AlunoAula entidade);
        Task AtualizarAsync(AlunoAula entidade);
        Task ExcluirAsync(int codigoAluno, int codigoAula);
        Task<AlunoAula> ObterAsync(int codigoAluno, int codigoAula);
        Task<IEnumerable<AlunoAula>> ListarPorAulaAsync(int codigoAula);
        Task<IEnumerable<AlunoAula>> ListarPorAlunoAsync(int codigoAluno);
    }
}