using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Dados.Database
{
    public interface IBlackBeltConexao
    {
        IDbConnection CriarConexao();
    }
}
