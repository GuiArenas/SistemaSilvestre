namespace SistemaSilvestre.Model
{
    public class Recinto
    {
        public int IdRecinto { get; set; }
        public string CodigoRecinto { get; set; }
        public string TipoRecinto { get; set; }

        public decimal? TamanhoM2 { get; set; }

        public int? CapacidadeMaxima { get; set; }
    }
}