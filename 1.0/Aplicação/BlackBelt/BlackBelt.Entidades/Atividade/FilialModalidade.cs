using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Atividade
{
    public class FilialModalidade
    {
        public int Codigo { get; set; }
        public int CodigoFilial { get; set; }
        public int CodigoModalidade { get; set; }
        public int Situacao { get; set; }
        public DateTime Criacao { get; set; }
    }
}