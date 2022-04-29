using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class RentingBusiness : Business
    {
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}
    }
}