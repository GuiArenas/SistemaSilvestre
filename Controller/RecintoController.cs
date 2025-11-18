using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;

namespace SistemaSilvestre.Controller
{
    public class RecintoController
    {
        private RecintoDAO recintoDAO;

        public RecintoController()
        {
            recintoDAO = new RecintoDAO();
        }

        public void Salvar(Recinto recinto)
        {
            if (string.IsNullOrWhiteSpace(recinto.CodigoRecinto))
            {
                MessageBox.Show("O Código do Recinto é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(recinto.TipoRecinto))
            {
                MessageBox.Show("O Tipo do Recinto é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (recinto.IdRecinto == 0)
            {
                recintoDAO.Inserir(recinto);
            }
            else
            {
                recintoDAO.Atualizar(recinto);
            }
        }

        public void Excluir(int id)
        {
            recintoDAO.Excluir(id);
        }

        public List<Recinto> ConsultarTodos()
        {
            return recintoDAO.ConsultarTodos();
        }
    }
}