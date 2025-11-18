using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;

namespace SistemaSilvestre.Controller
{
    public class FuncionarioController
    {
        private FuncionarioDAO funcionarioDAO;

        public FuncionarioController()
        {
            funcionarioDAO = new FuncionarioDAO();
        }

        public void Salvar(Funcionario funcionario)
        {
            if (string.IsNullOrWhiteSpace(funcionario.NomeCompleto))
            {
                MessageBox.Show("O Nome do Funcionário é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(funcionario.Cargo))
            {
                MessageBox.Show("O Cargo do Funcionário é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (funcionario.IdFuncionario == 0)
            {
                funcionarioDAO.Inserir(funcionario);
            }
            else
            {
                funcionarioDAO.Atualizar(funcionario);
            }
        }

        public void Excluir(int id)
        {
            funcionarioDAO.Excluir(id);
        }

        public List<Funcionario> ConsultarTodos()
        {
            return funcionarioDAO.ConsultarTodos();
        }
    }
}