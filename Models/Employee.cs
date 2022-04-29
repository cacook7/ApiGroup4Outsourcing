using System;
using System.Collections.Generic;
using api.Interfaces;
using api.Data;

namespace api.Models
{
	public class Employee
	{
		public int EmpID {get; set;}
		public string FName {get; set;}
		public string LName {get; set;}
		public DateTime Birthday {get; set;}
		public string PhoneNumber1 {get; set;}
		public string PhoneNumber2 {get; set;}
		public string Email {get; set;}
		public string Username {get; set;}
		public string Password {get; set;}
		public int IsAdmin {get; set;}
		public int Deleted {get; set;}
		
		public IEmployeeLoginDataHandler dataHandler {get; set;}

		public Employee()
		{
			dataHandler = new EmployeeLoginDataHandler();
		}	
	}
}