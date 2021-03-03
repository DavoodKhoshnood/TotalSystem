using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Good
    {
        [Key]
        public int GoodID { get; set; }

        [Required]
        public int GroupID { get; set; }

        [Required]
        public int StoreID { get; set; }

        [Required][MaxLength(300)]
        public string Title { get; set; }

        [Required]
        public int UnitID { get; set; }

        public bool ShowInSlider { get; set; }

        public string ImageName { get; set; }

        [MaxLength(500)][DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }

        //Navigation Property
        public virtual GoodsGroup GoodsGroup { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual Store Store { get; set; }

        public Good()
        {

        }
    }
}
