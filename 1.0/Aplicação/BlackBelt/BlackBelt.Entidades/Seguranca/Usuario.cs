using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBelt.Entidades.Seguranca
{
    public class Usuario
    {
        public int Codigo { get; set; }
        public int CodigoAluno { get; set; }
        public string Login { get; set; }
        public byte[] Senha { get; set; }
        public string Email { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public DateTime UltimaSenha { get; set; }
        public DateTime UltimaAlteracaoSenha { get; set; }
        public int Situacao { get; set; }
    }
}
