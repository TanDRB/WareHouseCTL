using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Khóa ngoại tham chiếu đến hóa chất
        [ForeignKey("Chemical")]
        public string ChemicalId { get; set; }
        public Chemical Chemical { get; set; } // Quan hệ điều hướng

        public DateTime StorageDate { get; set; }
        public string Status { get; set; }

        // Quan hệ với bảng ChemicalDetail
        public ICollection<ChemicalDetail> ChemicalDetails { get; set; }
    }
}