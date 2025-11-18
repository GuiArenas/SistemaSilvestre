using System;

namespace SistemaSilvestre.Model
{
    public class ManejoClinico
    {
        public int IdManejo { get; set; }
        public DateTime DataHoraManejo { get; set; }
        public decimal? PesoAferido { get; set; } 
        public string DescricaoProcedimento { get; set; } 
        public int IdAnimal { get; set; }
        public int IdFuncionario { get; set; }
        public string NomeIdentificacaoAnimal { get; set; }
        public string NomeFuncionario { get; set; }
    }
}