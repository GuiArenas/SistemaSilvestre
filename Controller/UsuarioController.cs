using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;

namespace SistemaSilvestre.Controller
{
    public class UsuarioController
    {
        private UsuarioDAO usuarioDAO;

        public UsuarioController()
        {
            usuarioDAO = new UsuarioDAO();
        }

        public void Salvar(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Login))
            {
                MessageBox.Show("O Nome de Usuário é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                MessageBox.Show("A Senha é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (usuario.IdFuncionario <= 0)
            {
                MessageBox.Show("É obrigatório vincular o usuário a um funcionário.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usuario.IdUsuario == 0)
            {
                usuarioDAO.Inserir(usuario);
            }
            else
            {
                usuarioDAO.Atualizar(usuario);
            }
        }

        public void Excluir(int id)
        {
            usuarioDAO.Excluir(id);
        }

        public List<Usuario> ConsultarTodos()
        {
            return usuarioDAO.ConsultarTodos();
        }
    }
}