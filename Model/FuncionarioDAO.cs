using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using SistemaSilvestre.Model;

namespace SistemaSilvestre.Model
{
    public class FuncionarioDAO
    {
        private ConexaoBD conexao;

        public FuncionarioDAO()
        {
            conexao = new ConexaoBD();
        }

        public void Inserir(Funcionario funcionario)
        {
            string query = "INSERT INTO Funcionario (NomeCompleto, Cargo, CRMV_CRBio, Telefone) " + 
                           "VALUES (@nomeCompleto, @cargo, @crvm_crbio, @telefone)";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@nomeCompleto", funcionario.NomeCompleto); 
                cmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                cmd.Parameters.AddWithValue("@crvm_crbio", (object)funcionario.CRMV_CRBio ?? DBNull.Value); 
                cmd.Parameters.AddWithValue("@telefone", (object)funcionario.Telefone ?? DBNull.Value);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Funcionário inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public void Atualizar(Funcionario funcionario)
        {
            string query = "UPDATE Funcionario SET NomeCompleto = @nomeCompleto, " + 
                           "Cargo = @cargo, CRMV_CRBio = @crvm_crbio, Telefone = @telefone " + 
                           "WHERE IdFuncionario = @idFuncionario";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@nomeCompleto", funcionario.NomeCompleto); 
                cmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                cmd.Parameters.AddWithValue("@crvm_crbio", (object)funcionario.CRMV_CRBio ?? DBNull.Value); 
                cmd.Parameters.AddWithValue("@telefone", (object)funcionario.Telefone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idFuncionario", funcionario.IdFuncionario);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Funcionário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public void Excluir(int id)
        {
            string query = "DELETE FROM Funcionario WHERE IdFuncionario = @idFuncionario";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@idFuncionario", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Funcionário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (ex is SqlException sqlEx && sqlEx.Number == 547)
                {
                    MessageBox.Show("Não é possível excluir este funcionário pois existem registros vinculados a ele (ex: manejos, usuários).", "Erro de Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Erro ao excluir funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public List<Funcionario> ConsultarTodos()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            string query = "SELECT IdFuncionario, NomeCompleto, Cargo, CRMV_CRBio, Telefone FROM Funcionario";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = null;

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.IdFuncionario = Convert.ToInt32(reader["IdFuncionario"]);
                    funcionario.NomeCompleto = reader["NomeCompleto"].ToString();
                    funcionario.Cargo = reader["Cargo"].ToString();
                    funcionario.CRMV_CRBio = reader["CRMV_CRBio"] == DBNull.Value ? null : reader["CRMV_CRBio"].ToString(); 
                    funcionario.Telefone = reader["Telefone"] == DBNull.Value ? null : reader["Telefone"].ToString();

                    funcionarios.Add(funcionario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar funcionários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null) reader.Close();
                cmd.Dispose();
                conexao.FecharConexao();
            }
            return funcionarios;
        }
    }
}