using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitalWeb.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        [Required]
        [StringLength(70)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PostDate { get; set; }

        // Clé étrangère
        [ForeignKey("TagID")]
        public int TagID { get; set; }
        // Propriété de navigation
        public virtual Tag PostTag { get; set; }
    }
}