using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Unit
    {
        [Key]
        public int UnitID { get; set; }

        [Required]
        [MaxLength(200)][Display(Name ="Unit Title")]
        public string Title { get; set; }

        public bool Countable { get; set; }

        [Required]
        [MaxLength(20)]
        public string Symbol { get; set; }
        [Required]
        [MaxLength(50)]
        public string UnitGroup { get; set; }
        
        public float Coefficient { get; set; }

        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }

        //Navigation Property
        public virtual List<Good> Goods { get; set; }
        public Unit()
        {

        }
    }
}
