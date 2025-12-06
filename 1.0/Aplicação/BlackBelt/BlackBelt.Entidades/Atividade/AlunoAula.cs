using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Atividade
{
    public class AlunoAula
    {
        public int CodigoAluno { get; set; }
        public int CodigoAula { get; set; }
        public DateTime Agendamento { get; set; }
        public bool Presenca { get; set; }
        public int Situacao { get; set; }
        public DateTime Criacao { get; set; }
    }
}
