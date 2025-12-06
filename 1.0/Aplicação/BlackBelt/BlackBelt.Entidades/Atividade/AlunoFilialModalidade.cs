using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Atividade
{
    public class AlunoFilialModalidade
    {
        public int CodigoAluno { get; set; }
        public int CodigoFilialModalidade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Situacao { get; set; }
    }
}