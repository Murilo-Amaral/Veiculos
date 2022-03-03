using System.ComponentModel.DataAnnotations;

namespace Veiculos.Models
{
    public class Veiculo
    {
        [Key]
        public Guid Id { get; set; }

        [Required, Display(Name ="Modelo")]
        public string Name { get; set; }

        [Required, Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required, Display(Name ="Cor")]
        public string Cor { get; set; }

        [Display(Name = "Ano de Fábricação")]
        public int Ano { get; set; }

        [Display(Name = "Placa")]
        public string Placa { get; set; }

        [Required, Display(Name = "Kilometragem")]
        public string Kms { get; set; }

        [Display(Name = "Tipo de Combustível")]
        public string Combustivel { get; set; }

        [Required, Display(Name = "Valor de Venda")]
        public string ValorVenda { get; set; }

        [Display(Name = "Foto")]
        public byte[]? Foto { get; set; }

    }
}
