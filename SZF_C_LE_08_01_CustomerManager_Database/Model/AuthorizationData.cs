using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZF_C_LE_08_01_CustomerManager_Database.Model
{
    public class AuthorizationData
    {
        [Key]
        public string UserLogin { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
    }
}
