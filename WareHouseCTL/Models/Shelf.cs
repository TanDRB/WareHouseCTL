using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WareHouseCTL.Models
{
    public class Shelf
    {
        [Key]
        public string ShelfID { get; set; }
        public string ShelfName { get; set; }
        [ForeignKey("Chemical")]
        public string ChemicalId { get; set; }
        public Chemical Chemical { get; set; }
        public string ChemicalName { get; set; } // Có thể xóa nếu sửa schema
        public ICollection<ShelfContainer> ShelfContainers { get; set; }
        public DateTime DateAdded { get; set; } // Thêm trường thời gian
    }
}