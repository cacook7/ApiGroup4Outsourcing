using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Data;

namespace api.Models
{
    public class RentalTransaction
    {
        public int FirmID {get; set;}
        public int SpaceID {get; set;}
        public int AppID {get; set;}
        public int EmpID {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}
        public DateTime ApprovalDate {get; set;}
        public string FirmName {get; set;}
    }
}