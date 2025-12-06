using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Cadastro
{
    public class Responsavel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; };
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
    }
}