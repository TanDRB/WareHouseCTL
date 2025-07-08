using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseCTL.Models
{
    public class ChemicalDetail
    {
        public string DetailId { get; set; }
        public int ShelfContainerId { get; set; }
        public string ItemName { get; set; }
        public DateTime? StorageDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public ShelfContainer ShelfContainer { get; set; }
        public Chemical Chemical { get; set; }
    }
}
