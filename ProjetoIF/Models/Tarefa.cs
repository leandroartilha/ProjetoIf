using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIF.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome Tarefa")]
        [Column(TypeName = "varchar(50)")]
        public string NomeTarefa { get; set; }

        [DisplayName("Descrição Tarefa")]
        [Column(TypeName = "varchar(200)")]
        public string? DescricaoTarefa { get; set; }


        [DisplayName("Atribuir ao Usuário")]
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [DisplayName("Atribuir ao Projeto")]
        public int? ProjetoId { get; set; }
        public Projeto? Projeto { get; set; }

        public ICollection<AtribuicaoUserTask>? AtribuicaoUserTask { get; set; }
    }
}
