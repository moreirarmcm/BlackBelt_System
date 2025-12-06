using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Cadastro
{
    public class Titulo
    {
        public int Codigo { get; set; }
        public int CodigoAcademia { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Padrao { get; set; }
        public int Ordem { get; set; }
        public DateTime Criacao { get; set; }
    }
}