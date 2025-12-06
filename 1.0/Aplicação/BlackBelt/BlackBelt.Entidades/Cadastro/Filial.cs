using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Cadastro
{
    public class Filial
    {
        public int Codigo { get; set; }
        public int CodigoAcademia { get; set; }
        public string Nome { get; set; } 
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }
        public DateTime Criacao { get; set; }
        public bool Situacao { get; set; }
        public string CodigoOrigem { get; set; }
    }
}
