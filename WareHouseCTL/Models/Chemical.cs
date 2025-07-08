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
        public string ChemicalID { get; set; }
        public string ChemicalName { get; set; }
        public string ChemicalDescribe { get; set; }

        public Shelf Shelf { get; set; }
    }
}