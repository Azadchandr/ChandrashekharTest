using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChandrashekharTest.Models
{
    public class DashboardStats
    {
        public int TotalCandidates { get; set; }

        public int PendingCandidates { get; set; }

        public int SelectedCandidates { get; set; }

        public int RejectedCandidates { get; set; }

        public int Submitted { get; set; }

        public int Approved { get; set; }

        public int Rejected { get; set; }



        

    }
}