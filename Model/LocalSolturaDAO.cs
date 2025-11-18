using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using SistemaSilvestre.Model;

namespace SistemaSilvestre.Model
{
    public class LocalSolturaDAO
    {
        private ConexaoBD conexao;

        public LocalSolturaDAO()
        {
            conexao = new ConexaoBD();
        }

        public void Inserir(LocalSoltura localSoltura)
        {
            string query = "INSERT INTO LocalSoltura (NomeLocal, Bioma, CoordenadasGPS, ResponsavelContato) " +
                           "VALUES (@nomeLocal, @bioma, @coordenadasGPS, @responsavelContato)";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@nomeLocal", localSoltura.NomeLocal);
                cmd.Parameters.AddWithValue("@bioma", (object)localSoltura.Bioma ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@coordenadasGPS", (object)localSoltura.CoordenadasGPS ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@responsavelContato", (object)localSoltura.ResponsavelContato ?? DBNull.Value);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Local de Soltura inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir Local de Soltura: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public void Atualizar(LocalSoltura localSoltura)
        {
            string query = "UPDATE LocalSoltura SET NomeLocal = @nomeLocal, Bioma = @bioma, " +
                           "CoordenadasGPS = @coordenadasGPS, ResponsavelContato = @responsavelContato " +
                           "WHERE IdLocalSoltura = @idLocalSoltura";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@nomeLocal", localSoltura.NomeLocal);
                cmd.Parameters.AddWithValue("@bioma", (object)localSoltura.Bioma ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@coordenadasGPS", (object)localSoltura.CoordenadasGPS ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@responsavelContato", (object)localSoltura.ResponsavelContato ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idLocalSoltura", localSoltura.IdLocalSoltura);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Local de Soltura atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar Local de Soltura: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public void Excluir(int id)
        {
            string query = "DELETE FROM LocalSoltura WHERE IdLocalSoltura = @idLocalSoltura";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@idLocalSoltura", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Local de Soltura excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir Local de Soltura: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public List<LocalSoltura> ConsultarTodos()
        {
            List<LocalSoltura> locaisSoltura = new List<LocalSoltura>();
            string query = "SELECT IdLocalSoltura, NomeLocal, Bioma, CoordenadasGPS, ResponsavelContato FROM LocalSoltura";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = null;

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LocalSoltura localSoltura = new LocalSoltura();
                    localSoltura.IdLocalSoltura = Convert.ToInt32(reader["IdLocalSoltura"]);
                    localSoltura.NomeLocal = reader["NomeLocal"].ToString();
                    localSoltura.Bioma = reader["Bioma"] == DBNull.Value ? null : reader["Bioma"].ToString();
                    localSoltura.CoordenadasGPS = reader["CoordenadasGPS"] == DBNull.Value ? null : reader["CoordenadasGPS"].ToString();
                    localSoltura.ResponsavelContato = reader["ResponsavelContato"] == DBNull.Value ? null : reader["ResponsavelContato"].ToString();

                    locaisSoltura.Add(localSoltura);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar Locais de Soltura: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null) reader.Close();
                cmd.Dispose();
                conexao.FecharConexao();
            }
            return locaisSoltura;
        }
    }
}