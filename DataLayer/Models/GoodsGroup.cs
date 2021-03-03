using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class GoodsGroup
    {
        [Key]
        public int GroupID { get; set; }
        public int ParentID { get; set; }
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }

        //Navigation Property

        public virtual List<Good> Goods { get; set; }
        public GoodsGroup()
        {

        }
    }
}
