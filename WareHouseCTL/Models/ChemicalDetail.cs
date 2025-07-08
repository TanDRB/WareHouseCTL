using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseCTL.Models
{
    public class ChemicalDetail
    {
        [Key]
        public string DetailId { get; set; }

        [ForeignKey("ShelfContainer")] // Đặt trên thuộc tính khóa ngoại
        public int ShelfContainerId { get; set; }
        public ShelfContainer ShelfContainer { get; set; }

        [ForeignKey("Chemical")]
        public string ChemicalId { get; set; }
        public Chemical Chemical { get; set; }

        public DateTime? StorageDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int Quantity { get; set; }
    }
}
