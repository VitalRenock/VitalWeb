using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitalWeb.Models
{
    public class MyTagContainer
    {
        [Key]
        public int MyTagContainerID { get; set; }

        [Required]
        [StringLength(55)]
        public string Name { get; set; }

        public virtual ICollection<Tag> AllTags { get; set; }
    }
}