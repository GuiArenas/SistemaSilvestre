using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using SistemaSilvestre.Model;

namespace SistemaSilvestre.Model
{
    public class AnimalDAO
    {
        private ConexaoBD conexao;

        public AnimalDAO()
        {
            conexao = new ConexaoBD();
        }

        public void Inserir(Animal animal)
        {
            string query = "INSERT INTO Animal (NomeIdentificacao, StatusAnimal, DataEntrada, DataSaida, MotivoEntrada, Origem, Observacoes, IdEspecie, IdRecinto) " + 
                           "VALUES (@nomeIdentificacao, @statusAnimal, @dataEntrada, @dataSaida, @motivoEntrada, @origem, @observacoes, @idEspecie, @idRecinto)"; 

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@nomeIdentificacao", animal.NomeIdentificacao); 
                cmd.Parameters.AddWithValue("@statusAnimal", animal.StatusAnimal); 
                cmd.Parameters.AddWithValue("@dataEntrada", animal.DataEntrada);
                cmd.Parameters.AddWithValue("@dataSaida", (object)animal.DataSaida ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@motivoEntrada", (object)animal.MotivoEntrada ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@origem", (object)animal.Origem ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@observacoes", (object)animal.Observacoes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idEspecie", animal.IdEspecie);
                cmd.Parameters.AddWithValue("@idRecinto", animal.IdRecinto);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Animal inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir animal: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public void Atualizar(Animal animal)
        {
            string query = "UPDATE Animal SET NomeIdentificacao = @nomeIdentificacao, StatusAnimal = @statusAnimal, " + 
                           "DataEntrada = @dataEntrada, DataSaida = @dataSaida, MotivoEntrada = @motivoEntrada, " +
                           "Origem = @origem, Observacoes = @observacoes, IdEspecie = @idEspecie, IdRecinto = @idRecinto " +
                           "WHERE IdAnimal = @idAnimal";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@nomeIdentificacao", animal.NomeIdentificacao); 
                cmd.Parameters.AddWithValue("@statusAnimal", animal.StatusAnimal); 
                cmd.Parameters.AddWithValue("@dataEntrada", animal.DataEntrada);
                cmd.Parameters.AddWithValue("@dataSaida", (object)animal.DataSaida ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@motivoEntrada", (object)animal.MotivoEntrada ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@origem", (object)animal.Origem ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@observacoes", (object)animal.Observacoes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idEspecie", animal.IdEspecie);
                cmd.Parameters.AddWithValue("@idRecinto", animal.IdRecinto);
                cmd.Parameters.AddWithValue("@idAnimal", animal.IdAnimal);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Animal atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar animal: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public void Excluir(int id)
        {
            string query = "DELETE FROM Animal WHERE IdAnimal = @idAnimal";
            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@idAnimal", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Animal excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (ex is SqlException sqlEx && sqlEx.Number == 547)
                {
                    MessageBox.Show("Não é possível excluir este animal pois existem manejos clínicos vinculados a ele.", "Erro de Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Erro ao excluir animal: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public List<Animal> ConsultarTodos()
        {
            List<Animal> animais = new List<Animal>();

            string query = @"SELECT 
                                A.IdAnimal, A.NomeIdentificacao, A.StatusAnimal, A.DataEntrada, A.DataSaida, 
                                A.MotivoEntrada, A.Origem, A.Observacoes,
                                A.IdEspecie, E.NomePopular AS NomeEspecie,
                                A.IdRecinto, R.CodigoRecinto AS CodigoRecinto
                            FROM 
                                Animal A
                            INNER JOIN 
                                Especie E ON A.IdEspecie = E.IdEspecie
                            INNER JOIN 
                                Recinto R ON A.IdRecinto = R.IdRecinto"; 

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = null;

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Animal animal = new Animal();
                    animal.IdAnimal = Convert.ToInt32(reader["IdAnimal"]);
                    animal.NomeIdentificacao = reader["NomeIdentificacao"].ToString(); 
                    animal.StatusAnimal = reader["StatusAnimal"].ToString(); 
                    animal.DataEntrada = Convert.ToDateTime(reader["DataEntrada"]);
                    animal.DataSaida = reader["DataSaida"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DataSaida"]);
                    animal.MotivoEntrada = reader["MotivoEntrada"] == DBNull.Value ? null : reader["MotivoEntrada"].ToString();
                    animal.Origem = reader["Origem"] == DBNull.Value ? null : reader["Origem"].ToString();
                    animal.Observacoes = reader["Observacoes"] == DBNull.Value ? null : reader["Observacoes"].ToString();

                    animal.IdEspecie = Convert.ToInt32(reader["IdEspecie"]);
                    animal.IdRecinto = Convert.ToInt32(reader["IdRecinto"]);

                    animal.NomeEspecie = reader["NomeEspecie"].ToString();
                    animal.CodigoRecinto = reader["CodigoRecinto"].ToString();

                    animais.Add(animal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar animais: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null) reader.Close();
                cmd.Dispose();
                conexao.FecharConexao();
            }
            return animais;
        }
    }
}