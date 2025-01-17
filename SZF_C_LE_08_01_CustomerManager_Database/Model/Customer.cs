using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZF_C_LE_08_01_CustomerManager_Database.Model
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public string CustomerStreet { get; set; } = null!;
        public string CustomerHausNumber { get; set; } = null!;
        public string CustomerPostIndex { get; set; } = null!;
        public string CustomerCity { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;


    }
}
