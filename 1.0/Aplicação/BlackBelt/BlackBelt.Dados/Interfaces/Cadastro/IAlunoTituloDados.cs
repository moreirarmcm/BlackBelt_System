using BlackBelt.Entidades.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces.Cadastro
{
    public interface IAlunoTituloDados
    {
        Task InserirAsync(AlunoTitulo entidade);
        Task AtualizarAsync(AlunoTitulo entidade);
        Task ExcluirAsync(int codigoAluno, int codigoTitulo); // relacionamento composto
        Task<AlunoTitulo> ObterAsync(int codigoAluno, int codigoTitulo);
        Task<IEnumerable<AlunoTitulo>> ListarPorAlunoAsync(int codigoAluno);
    }
}