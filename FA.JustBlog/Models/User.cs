using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_user { get; set; }

        [StringLength(255)]
        [Required]
        public string userName { get; set; }


        [StringLength(255)]
        public string fullName { get; set; }

        [StringLength(255)]
        [Required]
        public string password { get; set; }
    }
}