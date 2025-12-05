using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Atividade
{
    public class Aula
    {
        public int Codigo { get; set; }
        public int CodigoFilialModalidade { get; set; }
        public DateTime Data { get; set; }
        public int Situacao { get; set; }
        public DateTime Criacao { get; set; }
    }
}
