using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Seguranca
{
    public class Perfil
    {
        public int Codigo { get; set; }
        public int CodigoFilial { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public DateTime Criacao { get; set; }
        public bool Ativo { get; set; }
    }
}
