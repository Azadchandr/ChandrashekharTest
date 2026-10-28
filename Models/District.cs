using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChandrashekharTest.Models
{
    public class District
    {
        public int DistrictId { get; set; }

        public int StateId { get; set; }

        public string DistrictName { get; set; }

        public bool IsActive { get; set; }
    }
}