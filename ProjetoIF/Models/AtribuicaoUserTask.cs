using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIF.Models
{
    public class AtribuicaoUserTask
    {
        [Key]
        public int Id { get; set; }

        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [DisplayName("Nome Usuario")]
        [Column(TypeName = "varchar(100)")]
        public string? NomeUsuarioAtribuido { get; set; }

        public int? TarefaId { get; set; }
        public Tarefa? Tarefa { get; set; }
    }
}
