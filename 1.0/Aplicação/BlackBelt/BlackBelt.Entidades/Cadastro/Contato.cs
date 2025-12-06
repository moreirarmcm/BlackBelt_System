using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Cadastro
{
    public class Contato
    {
        public int Codigo { get; set; }
        public int CodigoPessoa { get; set; }
        public string Logradouro { get; set; } 
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string Celular { get; set; }
    }
}
