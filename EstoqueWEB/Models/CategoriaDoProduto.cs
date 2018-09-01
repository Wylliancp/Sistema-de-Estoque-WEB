using System.ComponentModel.DataAnnotations;

namespace EstoqueWEB.Models
{
    public class CategoriaDoProduto
    {

        public int Id { get; set; }
        [Required, StringLength(25)]
        public string Nome { get; set; }
        public string Descricao { get; set; }

    }
}