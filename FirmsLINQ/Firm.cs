using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmsLINQ
{
    public class Firm
    {
        public Firm(int v1, string v2, string v3 , string v4, string v5, int v6, string v7)
        {
            firID = v1;
            firm_name = v2;
            founding_date = v3;
            business_profile = v4;
            name_directory = v5;
            staff_number = v6;
            city = v7;
        }

        public int firID { get; set; }
        public string firm_name { get; set; }      
        public string founding_date { get; set; }
        public string business_profile { get; set; }
        public string name_directory { get; set; }
        public int staff_number { get; set; }
        public string city { get; set; }

        public int FirID { get; }
        public string Firm_name { get; }
        public string Founding_date { get; }
        public string Business_profile { get; }
        public string Name_directory { get; }
        public int Staff_number { get; }
        public string City { get; }
       
    }
}
