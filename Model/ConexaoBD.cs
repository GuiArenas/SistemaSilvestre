using System.Data.SqlClient;

namespace SistemaSilvestre.Model
{
    public class ConexaoBD
    {
        private static string connectionString = @"Data Source=GuilhermeArenas\SQLEXPRESS; 
                                                 Initial Catalog=DBSilvestre; 
                                                 Integrated Security=True";
        private SqlConnection conexao;

        public ConexaoBD()
        {
            conexao = new SqlConnection(connectionString);
        }

        public SqlConnection AbrirConexao()
        {
            if (conexao.State == System.Data.ConnectionState.Closed)
            {
                conexao.Open();
            }
            return conexao;
        }
        public SqlConnection FecharConexao()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
            return conexao;
        }
    }
}