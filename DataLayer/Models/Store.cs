using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Store
    {
        [Key]
        public int StoreID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Address { get; set; }
        
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }

        //Navigation Property
        public List<Good> Goods { get; set; }
        public Store()
        {

        }
    }
}
