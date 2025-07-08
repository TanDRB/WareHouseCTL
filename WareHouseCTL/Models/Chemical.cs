using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseCTL.Models
{
    public class Chemical
    {
        [Key]
        public string ChemicalId { get; set; } // Đổi thành ChemicalId cho nhất quán
        public string ChemicalName { get; set; }
        public string ChemicalDescribe { get; set; }

        // Quan hệ với Shelf (1-1, nếu cần)
        public Shelf Shelf { get; set; }

        // Quan hệ với ShelfContainer (nếu sử dụng trực tiếp)
        public ICollection<ShelfContainer> ShelfContainers { get; set; }

        // Quan hệ với ChemicalDetail
        public ICollection<ChemicalDetail> ChemicalDetails { get; set; }
    }
}