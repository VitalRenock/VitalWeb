using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace VitalWeb.Models
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }

        [Required]
        [StringLength(55)]
        public string Name { get; set; }

        public virtual ICollection<MyTagContainer> AllTagsContainer { get; set; }
    }
}