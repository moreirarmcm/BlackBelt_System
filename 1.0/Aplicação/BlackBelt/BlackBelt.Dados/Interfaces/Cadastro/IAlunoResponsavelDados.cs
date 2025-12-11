using BlackBelt.Entidades.Cadastro;

namespace BlackBelt.Dal.Cadastro
{
    public interface IAlunoResponsavelDados
    {
        Task InserirAsync(int codigoAluno, int codigoResponsavel, int? grauParentesco, string telefone, int? ordem);
        Task AtualizarAsync(int codigoAluno, int codigoResponsavel, int? grauParentesco, string telefone, int? ordem);
        Task ExcluirAsync(int codigoAluno, int codigoResponsavel);
        Task<IEnumerable<AlunoResponsavel>> BuscarAsync(int? codigoAluno, int? codigoResponsavel);
    }
}
