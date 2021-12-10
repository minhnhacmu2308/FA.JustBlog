using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_post { get; set; }

        [StringLength(255)]
        [Required]
        public string title { get; set; }

        public string desShort { get; set; }

        public string content { get; set; }

        public DateTime createdAt { get; set; }

        public int id_user { get; set; }

        public virtual User User { get; set; }
    }
}