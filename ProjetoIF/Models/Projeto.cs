using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIF.Models
{
    public class Projeto
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome Projeto")]
        [Column(TypeName = "varchar(50)")]
        public string NomeTarefa { get; set; }

        public ICollection<Tarefa> Tarefa { get; set; }
        public ICollection<AtribuicaoUserProject>? AtribuicaoUserProject { get; set; }
    }
}
