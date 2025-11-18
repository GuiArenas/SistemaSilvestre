using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;

namespace SistemaSilvestre.Controller
{
    public class EspecieController
    {
        private EspecieDAO especieDAO;

        public EspecieController()
        {
            especieDAO = new EspecieDAO();
        }

        public void Salvar(Especie especie)
        {
            if (string.IsNullOrWhiteSpace(especie.NomePopular))
            {
                MessageBox.Show("O Nome Popular é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(especie.NomeCientifico))
            {
                MessageBox.Show("O Nome Científico é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (especie.IdEspecie == 0)
            {
                especieDAO.Inserir(especie);
            }
            else
            {
                especieDAO.Atualizar(especie);
            }
        }

        public void Excluir(int id)
        {
            especieDAO.Excluir(id);
        }

        public List<Especie> ConsultarTodos()
        {
            return especieDAO.ConsultarTodos();
        }
    }
}