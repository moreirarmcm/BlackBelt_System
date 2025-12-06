using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Cadastro
{
    public class AlunoTitulo
    {
        public int CodigoAluno { get; set; }
        public int CodigoTitulo { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public DateTime Criacao { get; set; }
    }
}
