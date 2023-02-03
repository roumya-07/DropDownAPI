using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DropDown.Models
{
    public class DDEntity
    {
        public int CountryID { get; set; } = 0;
        public string CountryName { get; set; } = null;
        public int StateID { get; set; } = 0;
        public string StateName { get; set; } = null;
        public int DistrictID { get; set; } = 0;
        public string DistrictName { get; set; } = null;
    }
}
