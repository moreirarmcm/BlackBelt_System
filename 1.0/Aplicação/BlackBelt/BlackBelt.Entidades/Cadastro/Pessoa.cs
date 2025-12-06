using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Cadastro
{
    public class Pessoa
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }
        public bool PCD { get; set; }
    }
}