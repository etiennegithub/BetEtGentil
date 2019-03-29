using BetEtMechant.Class.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BetEtMechant.Models
{
    public class Championship : BaseModel
    {
        [Display(Name = "Nom", Prompt = "nom")]
        [StringLength(50)]
        [Required]
        [Unique]
        public string Name { get; set; }


    }
}
