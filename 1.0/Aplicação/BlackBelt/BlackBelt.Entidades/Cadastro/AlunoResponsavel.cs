using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Cadastro
{

        public class AlunoResponsavel
        {
            public int CodigoAluno { get; set; }

            public int CodigoResponsavel { get; set; }

            public int? GrauParentesco { get; set; }

            public string Telefone { get; set; }

            public int? Ordem { get; set; }
        }
    }


