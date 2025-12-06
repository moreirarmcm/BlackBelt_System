using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;


namespace Dados.Database
{
    public sealed class BlackBeltConexao : IBlackBeltConexao
    {
        private readonly string _connectionString;

        public BlackBeltConexao(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("A connection string não pode ser nula ou vazia.", nameof(connectionString));

            _connectionString = connectionString;
        }

        public IDbConnection CriarConexao()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
