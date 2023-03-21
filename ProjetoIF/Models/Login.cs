using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIF.Models
{
    public class Login
    {

        
        public int Id { get; set; }

        [DisplayName("EmailLogin")]
        [Column(TypeName = "varchar(40)")]
        //[Required(ErrorMessage = "Digite sua Senha")]
        public string EmailLogin{get;set;}


        [DisplayName("EmailLogin")]
        [Column(TypeName = "varchar(40)")]
        public string SenhaLogin { get; set; }
    }
}
