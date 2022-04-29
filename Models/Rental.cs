using System.Collections.Generic;
using api.Data;
using api.Models;
using api.Interfaces;

namespace api.Models
{
	public class Rental
	{
		public int SpaceID{get; set;}
		public int Size{get; set;}
		public int MonthlyPrice{get; set;}
		
		public IRentalDataHandler dataHandler{get; set;}
		
		public Rental()
		{
			dataHandler = new RentalDataHandler();
		}
	}
}