using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;

namespace SistemaSilvestre.Controller
{
    public class ManejoClinicoController
    {
        private ManejoClinicoDAO manejoDAO;

        public ManejoClinicoController()
        {
            manejoDAO = new ManejoClinicoDAO();
        }

        public void Salvar(ManejoClinico manejo)
        {
            if (string.IsNullOrWhiteSpace(manejo.DescricaoProcedimento))
            {
                MessageBox.Show("A Descrição do Procedimento é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (manejo.IdAnimal <= 0)
            {
                MessageBox.Show("É obrigatório selecionar um Animal.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (manejo.IdFuncionario <= 0)
            {
                MessageBox.Show("É obrigatório selecionar o Funcionário responsável.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (manejo.IdManejo == 0)
            {
                manejoDAO.Inserir(manejo);
            }
            else
            {
                manejoDAO.Atualizar(manejo);
            }
        }

        public void Excluir(int id)
        {
            manejoDAO.Excluir(id);
        }

        public List<ManejoClinico> ConsultarTodos()
        {
            return manejoDAO.ConsultarTodos();
        }
    }
}