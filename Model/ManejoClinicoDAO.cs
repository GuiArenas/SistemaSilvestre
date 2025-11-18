using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using SistemaSilvestre.Model;

namespace SistemaSilvestre.Model
{
    public class ManejoClinicoDAO
    {
        private ConexaoBD conexao;

        public ManejoClinicoDAO()
        {
            conexao = new ConexaoBD();
        }

        public void Inserir(ManejoClinico manejo)
        {
            string query = "INSERT INTO ManejoClinico (DataHoraManejo, PesoAferido, DescricaoProcedimento, IdAnimal, IdFuncionario) " +
                           "VALUES (@dataHoraManejo, @pesoAferido, @descricaoProcedimento, @idAnimal, @idFuncionario)";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@dataHoraManejo", manejo.DataHoraManejo);
                cmd.Parameters.AddWithValue("@pesoAferido", (object)manejo.PesoAferido ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@descricaoProcedimento", manejo.DescricaoProcedimento);
                cmd.Parameters.AddWithValue("@idAnimal", manejo.IdAnimal);
                cmd.Parameters.AddWithValue("@idFuncionario", manejo.IdFuncionario);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Manejo clínico inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir manejo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public void Atualizar(ManejoClinico manejo)
        {
            string query = "UPDATE ManejoClinico SET DataHoraManejo = @dataHoraManejo, PesoAferido = @pesoAferido, " +
                           "DescricaoProcedimento = @descricaoProcedimento, IdAnimal = @idAnimal, IdFuncionario = @idFuncionario " +
                           "WHERE IdManejo = @idManejo";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@dataHoraManejo", manejo.DataHoraManejo);
                cmd.Parameters.AddWithValue("@pesoAferido", (object)manejo.PesoAferido ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@descricaoProcedimento", manejo.DescricaoProcedimento);
                cmd.Parameters.AddWithValue("@idAnimal", manejo.IdAnimal);
                cmd.Parameters.AddWithValue("@idFuncionario", manejo.IdFuncionario);
                cmd.Parameters.AddWithValue("@idManejo", manejo.IdManejo);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Manejo clínico atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar manejo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public void Excluir(int id)
        {
            string query = "DELETE FROM ManejoClinico WHERE IdManejo = @idManejo";
            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@idManejo", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Manejo clínico excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir manejo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public List<ManejoClinico> ConsultarTodos()
        {
            List<ManejoClinico> manejos = new List<ManejoClinico>();

            string query = @"SELECT 
                                M.IdManejo, M.DataHoraManejo, M.PesoAferido, M.DescricaoProcedimento,
                                M.IdAnimal, A.NomeIdentificacao AS NomeIdentificacaoAnimal,
                                M.IdFuncionario, F.NomeCompleto AS NomeFuncionario
                            FROM 
                                ManejoClinico M
                            INNER JOIN 
                                Animal A ON M.IdAnimal = A.IdAnimal
                            INNER JOIN 
                                Funcionario F ON M.IdFuncionario = F.IdFuncionario";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = null;

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ManejoClinico manejo = new ManejoClinico();
                    manejo.IdManejo = Convert.ToInt32(reader["IdManejo"]);
                    manejo.DataHoraManejo = Convert.ToDateTime(reader["DataHoraManejo"]);
                    manejo.PesoAferido = reader["PesoAferido"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["PesoAferido"]);
                    manejo.DescricaoProcedimento = reader["DescricaoProcedimento"].ToString();

                    manejo.IdAnimal = Convert.ToInt32(reader["IdAnimal"]);
                    manejo.IdFuncionario = Convert.ToInt32(reader["IdFuncionario"]);

                    manejo.NomeIdentificacaoAnimal = reader["NomeIdentificacaoAnimal"].ToString();
                    manejo.NomeFuncionario = reader["NomeFuncionario"].ToString();

                    manejos.Add(manejo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar manejos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null) reader.Close();
                cmd.Dispose();
                conexao.FecharConexao();
            }
            return manejos;
        }
    }
}