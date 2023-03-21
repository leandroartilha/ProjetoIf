using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIF.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }


        [DisplayName("Nome")]
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage ="Digite seu nome")]
        public string NomeUsuario { get; set; }


        [DisplayName("Email")]
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Digite seu Email")]
        public string EmailUsuario { get; set; }

        [DisplayName("Senha")]
        [Column(TypeName = "varchar(40)")]
        [Required(ErrorMessage = "Digite sua Senha")]
        public string SenhaUsuario { get; set; }

        public bool SenhaValida(string senha)
        {
            return SenhaUsuario == senha;
        }

        public ICollection<Tarefa>? Tarefa { get; set; }

    }
}
