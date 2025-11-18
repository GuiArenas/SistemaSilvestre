using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;

namespace SistemaSilvestre.Controller
{
    public class LocalSolturaController
    {
        private LocalSolturaDAO localSolturaDAO;

        public LocalSolturaController()
        {
            localSolturaDAO = new LocalSolturaDAO();
        }

        public void Salvar(LocalSoltura localSoltura)
        {
            if (string.IsNullOrWhiteSpace(localSoltura.NomeLocal))
            {
                MessageBox.Show("O Nome do Local de Soltura é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (localSoltura.IdLocalSoltura == 0)
            {
                localSolturaDAO.Inserir(localSoltura);
            }
            else
            {
                localSolturaDAO.Atualizar(localSoltura);
            }
        }

        public void Excluir(int id)
        {
            localSolturaDAO.Excluir(id);
        }

        public List<LocalSoltura> ConsultarTodos()
        {
            return localSolturaDAO.ConsultarTodos();
        }
    }
}