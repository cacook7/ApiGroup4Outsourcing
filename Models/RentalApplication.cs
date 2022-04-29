using System;
using System.Collections.Generic;
using api.Interfaces;
using api.Data;

namespace api.Models
{
	public class RentalApplication
	{
		public int AppID {get;set;}
		public int FirmID {get;set;}
		public int SpaceID {get;set;}
		public DateTime AppStartDate {get;set;}
		public DateTime AppEndDate {get;set;}
		public DateTime AppSubmitDate {get;set;}
		public string Approved {get;set;}
		public string FirmName {get;set;}
		
		public IRentalApplicationDataHandler dataHandler{get; set;}
		
		public RentalApplication()
		{
			dataHandler = new RentalApplicationDataHandler();
		}
	}
}