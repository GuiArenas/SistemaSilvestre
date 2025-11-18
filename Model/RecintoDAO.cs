using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using SistemaSilvestre.Model;

namespace SistemaSilvestre.Model
{
    public class RecintoDAO
    {
        private ConexaoBD conexao;

        public RecintoDAO()
        {
            conexao = new ConexaoBD();
        }

        public void Inserir(Recinto recinto)
        {
            string query = "INSERT INTO Recinto (CodigoRecinto, TipoRecinto, TamanhoM2, CapacidadeMaxima) " +
                           "VALUES (@codigoRecinto, @tipoRecinto, @tamanhoM2, @capacidadeMaxima)";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@codigoRecinto", recinto.CodigoRecinto);
                cmd.Parameters.AddWithValue("@tipoRecinto", recinto.TipoRecinto);
                cmd.Parameters.AddWithValue("@tamanhoM2", (object)recinto.TamanhoM2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@capacidadeMaxima", (object)recinto.CapacidadeMaxima ?? DBNull.Value);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Recinto inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir recinto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public void Atualizar(Recinto recinto)
        {
            string query = "UPDATE Recinto SET CodigoRecinto = @codigoRecinto, " +
                           "TipoRecinto = @tipoRecinto, TamanhoM2 = @tamanhoM2, " +
                           "CapacidadeMaxima = @capacidadeMaxima WHERE IdRecinto = @idRecinto";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@codigoRecinto", recinto.CodigoRecinto);
                cmd.Parameters.AddWithValue("@tipoRecinto", recinto.TipoRecinto);
                cmd.Parameters.AddWithValue("@tamanhoM2", (object)recinto.TamanhoM2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@capacidadeMaxima", (object)recinto.CapacidadeMaxima ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idRecinto", recinto.IdRecinto);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Recinto atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar recinto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public void Excluir(int id)
        {
            string query = "DELETE FROM Recinto WHERE IdRecinto = @idRecinto";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@idRecinto", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Recinto excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (ex is SqlException sqlEx && sqlEx.Number == 547)
                {
                    MessageBox.Show("Não é possível excluir este recinto pois existem animais alocados nele.", "Erro de Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Erro ao excluir recinto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public List<Recinto> ConsultarTodos()
        {
            List<Recinto> recintos = new List<Recinto>();
            string query = "SELECT IdRecinto, CodigoRecinto, TipoRecinto, TamanhoM2, CapacidadeMaxima FROM Recinto";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = null;

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Recinto recinto = new Recinto();
                    recinto.IdRecinto = Convert.ToInt32(reader["IdRecinto"]);
                    recinto.CodigoRecinto = reader["CodigoRecinto"].ToString();
                    recinto.TipoRecinto = reader["TipoRecinto"].ToString();

                    recinto.TamanhoM2 = reader["TamanhoM2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["TamanhoM2"]);

                    recinto.CapacidadeMaxima = reader["CapacidadeMaxima"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CapacidadeMaxima"]);

                    recintos.Add(recinto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar recintos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null) reader.Close();
                cmd.Dispose();
                conexao.FecharConexao();
            }
            return recintos;
        }
    }
}