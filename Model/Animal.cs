using System;

namespace SistemaSilvestre.Model
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public string NomeIdentificacao { get; set; } 
        public string StatusAnimal { get; set; } 
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public string MotivoEntrada { get; set; }
        public string Origem { get; set; }
        public string Observacoes { get; set; }
        public int IdEspecie { get; set; }
        public int IdRecinto { get; set; }
        public string NomeEspecie { get; set; }
        public string CodigoRecinto { get; set; }
    }
}