using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;

namespace SistemaSilvestre.Controller
{
    public class AnimalController
    {
        private AnimalDAO animalDAO;

        public AnimalController()
        {
            animalDAO = new AnimalDAO();
        }

        public void Salvar(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.NomeIdentificacao))
            {
                MessageBox.Show("O Nome/Identificação do animal é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(animal.StatusAnimal))
            {
                MessageBox.Show("O Status de Saúde é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (animal.IdEspecie <= 0)
            {
                MessageBox.Show("É obrigatório selecionar uma Espécie.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (animal.IdRecinto <= 0)
            {
                MessageBox.Show("É obrigatório selecionar um Recinto.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (animal.IdAnimal == 0)
            {
                animalDAO.Inserir(animal);
            }
            else
            {
                animalDAO.Atualizar(animal);
            }
        }

        public void Excluir(int id)
        {
            animalDAO.Excluir(id);
        }

        public List<Animal> ConsultarTodos()
        {
            return animalDAO.ConsultarTodos();
        }
    }
}