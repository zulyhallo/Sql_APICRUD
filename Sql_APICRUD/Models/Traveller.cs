using Sql_APICRUD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sql_APICRUD.Models
{
    public class Traveller
    {
        public int TravellerId { get; set; }
        public string TravellerName { get; set; }
        public string Department { get; set; }
    }
}
