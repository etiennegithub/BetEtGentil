using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BetEtMechant.Models
{
    public class Team : BaseModel
    {
        /*[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        //public int ID { get; set; }

        [Display(Name = "Nom", Prompt = "nom")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name="score", Prompt = "score")]
        [Required]
        public int Score { get; set; }

        [Display(Name = "Logo", Prompt = "logo")]
        public byte[] Logo { get; set; }

        public int ChampionshipID { get; set; }

        [ForeignKey("ChampionshipID")]
        public Championship Championship { get; set; }
    }
}
