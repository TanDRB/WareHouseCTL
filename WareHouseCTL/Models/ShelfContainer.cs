using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseCTL.Models
{
    public class ShelfContainer
    {
        [Key]
        public int ShelfContainerId { get; set; }
        public string ShelfContainerName { get; set; }
        // Khóa ngoại tham chiếu đến kệ, liên kết với bảng Shelf
        [ForeignKey("Shelf")]
        public string ShelfID { get; set; }
        public Shelf Shelf { get; set; }
        public DateTime StorageDate { get; set; }
        public string Status { get; set; }  

        // Quan hệ với bảng ChemicalDetail, một ngăn chứa có thể chứa nhiều lô hóa chất
        public ICollection<ChemicalDetail> ChemicalDetails { get; set; }
    }
}
