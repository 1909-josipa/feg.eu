using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kladionica.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("ID")]
        public string SportType { get; set; }
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Sport Type")]
        public string Participants { get; set; }
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Participants")]
        public Array ResultType { get; set; }
        [DisplayName("Result Type")]



    }
}
