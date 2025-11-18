using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using SistemaSilvestre.Model;

namespace SistemaSilvestre.Model
{
    public class UsuarioDAO
    {
        private ConexaoBD conexao;

        public UsuarioDAO()
        {
            conexao = new ConexaoBD();
        }

        public void Inserir(Usuario usuario)
        {
            string query = "INSERT INTO Usuario (Login, Senha, NivelAcesso, IdFuncionario) " + 
                           "VALUES (@login, @senha, @nivelAcesso, @idFuncionario)"; 

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@login", usuario.Login); 
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@nivelAcesso", usuario.NivelAcesso);
                cmd.Parameters.AddWithValue("@idFuncionario", usuario.IdFuncionario);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuário inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public void Atualizar(Usuario usuario)
        {
            string query = "UPDATE Usuario SET Login = @login, Senha = @senha, " + 
                           "NivelAcesso = @nivelAcesso, IdFuncionario = @idFuncionario " +
                           "WHERE IdUsuario = @idUsuario";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@login", usuario.Login); 
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@nivelAcesso", usuario.NivelAcesso);
                cmd.Parameters.AddWithValue("@idFuncionario", usuario.IdFuncionario);
                cmd.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public void Excluir(int id)
        {
            string query = "DELETE FROM Usuario WHERE IdUsuario = @idUsuario";
            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@idUsuario", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
        }

        public List<Usuario> ConsultarTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string query = "SELECT IdUsuario, Login, Senha, NivelAcesso, IdFuncionario FROM Usuario"; 

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = null;

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    usuario.Login = reader["Login"].ToString();
                    usuario.Senha = reader["Senha"].ToString();
                    usuario.NivelAcesso = reader["NivelAcesso"].ToString();
                    usuario.IdFuncionario = Convert.ToInt32(reader["IdFuncionario"]);

                    usuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar usuários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null) reader.Close();
                cmd.Dispose();
                conexao.FecharConexao();
            }
            return usuarios;
        }
        public Usuario BuscarPorLogin(string login)
        {
            Usuario usuario = null;
            string query = "SELECT * FROM Usuario WHERE Login = @login";

            SqlConnection con = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.Parameters.AddWithValue("@login", login);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario();
                    usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    usuario.Login = reader["Login"].ToString();
                    usuario.Senha = reader["Senha"].ToString();
                    usuario.NivelAcesso = reader["NivelAcesso"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar usuário: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conexao.FecharConexao();
            }
            return usuario;
        }
    }
}