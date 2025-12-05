using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Atividade
{
    public class Modalidade
    {
        public int Codigo { get; set; }
        public int CodigoDisciplina { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public string Tipo { get; set; }
    }
}
