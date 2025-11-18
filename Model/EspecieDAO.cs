using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using SistemaSilvestre.Model; 

namespace SistemaSilvestre.Model
{
    public class EspecieDAO
    {
        private ConexaoBD conexao; 

        public EspecieDAO()
        {
            conexao = new ConexaoBD();
        }

        public void Inserir(Especie especie)
        {
            string query = "INSERT INTO Especie (NomePopular, NomeCientifico, DietaPadrao, Observacoes) " +
                           "VALUES (@nomePopular, @nomeCientifico, @dietaPadrao, @observacoes)";

            SqlConnection con = conexao.AbrirConexao(); 
            SqlCommand cmd = new SqlCommand(query, con); 

            try
            {
                cmd.Parameters.AddWithValue("@nomePopular", especie.NomePopular);
                cmd.Parameters.AddWithValue("@nomeCientifico", especie.NomeCientifico);
                cmd.Parameters.AddWithValue("@dietaPadrao", (object)especie.DietaPadrao ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@observacoes", (object)especie.Observacoes ?? DBNull.Value); 

                cmd.ExecuteNonQuery();
                MessageBox.Show("Espécie inserida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir espécie: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose(); 
                conexao.FecharConexao();
            }
        }
        public void Atualizar(Especie especie)
        {
            string query = "UPDATE Especie SET NomePopular = @nomePopular, " +
                           "NomeCientifico = @nomeCientifico, DietaPadrao = @dietaPadrao, " +
                           "Observacoes = @observacoes WHERE IdEspecie = @idEspecie";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@nomePopular", especie.NomePopular);
                cmd.Parameters.AddWithValue("@nomeCientifico", especie.NomeCientifico);
                cmd.Parameters.AddWithValue("@dietaPadrao", (object)especie.DietaPadrao ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@observacoes", (object)especie.Observacoes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idEspecie", especie.IdEspecie);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Espécie atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar espécie: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }
        public void Excluir(int id)
        {
            string query = "DELETE FROM Especie WHERE IdEspecie = @idEspecie";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@idEspecie", id);

                int linhasAfetadas = cmd.ExecuteNonQuery();
                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Espécie excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nenhuma espécie encontrada com o ID informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException sqlEx && sqlEx.Number == 547) 
                {
                    MessageBox.Show("Não é possível excluir esta espécie pois existem animais cadastrados que dependem dela.", "Erro de Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Erro ao excluir espécie: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }
        public List<Especie> ConsultarTodos()
        {
            List<Especie> especies = new List<Especie>();
            string query = "SELECT IdEspecie, NomePopular, NomeCientifico, DietaPadrao, Observacoes FROM Especie";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = null; 

            try
            {
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Especie especie = new Especie();
                    especie.IdEspecie = Convert.ToInt32(reader["IdEspecie"]);
                    especie.NomePopular = reader["NomePopular"].ToString();
                    especie.NomeCientifico = reader["NomeCientifico"].ToString();
                    especie.DietaPadrao = reader["DietaPadrao"] == DBNull.Value ? null : reader["DietaPadrao"].ToString();
                    especie.Observacoes = reader["Observacoes"] == DBNull.Value ? null : reader["Observacoes"].ToString();

                    especies.Add(especie);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar espécies: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null) reader.Close(); 
                cmd.Dispose();
                conexao.FecharConexao();
            }
            return especies;
        }
        public Especie ConsultarPorId(int id)
        {
            Especie especie = null;
            string query = "SELECT IdEspecie, NomePopular, NomeCientifico, DietaPadrao, Observacoes FROM Especie WHERE IdEspecie = @idEspecie";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = null;

            try
            {
                cmd.Parameters.AddWithValue("@idEspecie", id);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    especie = new Especie();
                    especie.IdEspecie = Convert.ToInt32(reader["IdEspecie"]);
                    especie.NomePopular = reader["NomePopular"].ToString();
                    especie.NomeCientifico = reader["NomeCientifico"].ToString();
                    especie.DietaPadrao = reader["DietaPadrao"] == DBNull.Value ? null : reader["DietaPadrao"].ToString();
                    especie.Observacoes = reader["Observacoes"] == DBNull.Value ? null : reader["Observacoes"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar espécie por ID: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null) reader.Close();
                cmd.Dispose();
                conexao.FecharConexao();
            }
            return especie;
        }
    }
}