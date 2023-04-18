using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIF.Models
{
    public class AtribuicaoUserProject
    {
        [Key]
        public int Id { get; set; }

        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [DisplayName("Nome Usuario")]
        [Column(TypeName = "varchar(100)")]
        public string? NomeUsuarioAtribuido { get; set; }

        public int? ProjetoId { get; set; } 
        public Projeto? Projeto { get; set; } 
    }
}
