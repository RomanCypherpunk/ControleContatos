using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class ContatoModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Contato")]

        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Email do Contato")]
        [EmailAddress(ErrorMessage = "O Email informado nao é válido.") ]

        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular do Contato")]
        [Phone(ErrorMessage = "O Celular informado nao é válido.")]

        public string Celular { get; set; }


    }
}
