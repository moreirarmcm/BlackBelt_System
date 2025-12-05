using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Cadastro
{
   
    public class Aluno
    {
        public int Codigo { get; set; }
        public int CodigoPessoa { get; set; }
        public int CodigoFilial { get; set; }
        public string Matricula { get; set; }
        public string Apelido { get; set; }
        public int Situacao { get; set; }
        public DateTime Criacao { get; set; }
    }

}
