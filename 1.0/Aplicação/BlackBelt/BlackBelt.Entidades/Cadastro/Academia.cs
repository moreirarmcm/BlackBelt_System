using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Cadastro
{
    public class Academia
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string? Sigla { get; set; }
    }
}
