using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Data;
using api.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeLoginController : ControllerBase
	{
		// GET: api/EmployeeLogin
		[EnableCors("OpenPolicy")]
		[HttpGet("GetEmps")]
		public List<Employee> GetEmps()
		{
			EmployeeLoginDataHandler readingEmps = new EmployeeLoginDataHandler();
			List<Employee> myEmps = readingEmps.GetAll();
			return myEmps;
		}

		// GET: api/EmployeeLogin/5
		[EnableCors("OpenPolicy")]
		[HttpGet("GetEmp/{id}")]
		public Employee Get(int id)
		{
			Employee myEmp = new Employee();
			EmployeeLoginDataHandler readingEmps = new EmployeeLoginDataHandler();
			try{
				myEmp = readingEmps.GetOne(id);
			}catch{
				System.Console.WriteLine("Error doesn't exist");
			}
			return myEmp;
		}

		// PUT: api/EmployeeLogin/5
		[EnableCors("OpenPolicy")]
		[HttpPut("UpdateEmployee")]
		public void Put([FromBody] Employee value)
		{
			EmployeeLoginDataHandler updating = new EmployeeLoginDataHandler();
			updating.UpdateByUsername(value);
		}
	}
}
