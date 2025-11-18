namespace SistemaSilvestre.Model
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string NivelAcesso { get; set; }
        public int IdFuncionario { get; set; }
    }
}