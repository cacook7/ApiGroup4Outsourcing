using System.Collections.Generic;
using api.Data;
using api.Models;
using api.Interfaces;

namespace api.Models

{
	public class Business
	{
		public int FirmID {get; set;}
		public string Email {get;set;}
		public string Username {get; set;}
		public string Password {get; set;}
		public string FirmName {get; set;}
		public string RepFName {get; set;}
		public string RepLName {get; set;}
		public string FirmDescription {get; set;}
		public string PhoneNumber1 {get; set;}
		public string PhoneNumber2 {get; set;}
		public int Deleted {get; set;}
		
		public IBusinessLoginDataHandler dataHandler {get; set;}

		public Business()
		{
			dataHandler = new BusinessLoginDataHandler();
			dataHandler = new BusinessDataHandler();
		}		
	}
}