using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axle_Load_Control.Models
{
    public class AxlePermitViewModel
    {
        public int refno { get; set; }
        public string vehicleregistration { get; set; }
        public string tareweight { get; set; }
        public string vehiclemake { get; set; }
        public string region { get; set; }
        public string vehicletype { get; set; }
        public string status { get; set; }
        public string trailerragistration { get; set; }
        public string totalnoofaxle { get; set; }
        public string descriptionofload { get; set; }
        public string weightbridegcheckpoint { get; set; }
        public string noofwheelsperaxle { get; set; }
        public string grossvehicleweight { get; set; }
        public string vehicletareweight { get; set; }
        public string weightofcargo { get; set; }
        public string trailertareweight { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string totalamount { get; set; }
        public string totalbalance { get; set; }
        public string route { get; set; }
        public string applicantname { get; set; }
    }
}