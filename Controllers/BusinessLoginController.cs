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
	public class BusinessLoginController : ControllerBase
	{
		// GET: api/EmployeeLogin
		[EnableCors("OpenPolicy")]
		[HttpGet("GetFirms")]
		public List<Business> GetFirms()
		{
			BusinessLoginDataHandler readingFirms = new BusinessLoginDataHandler();
			List<Business> myFirms = readingFirms.GetAll();
			return myFirms;
		}

		[EnableCors("OpenPolicy")]
		[HttpGet("GetCurrentRenters")]
		public List<RentingBusiness> GetCurrentRenters()
		{
			BusinessLoginDataHandler readingFirms = new BusinessLoginDataHandler();
			List<RentingBusiness> myFirms = readingFirms.GetCurrentBusinesses();
			return myFirms;
		}

		// GET: api/EmployeeLogin/5
		[EnableCors("OpenPolicy")]
		[HttpGet("GetFirm/{id}")]
		public Business Get(int id)
		{
			Business myFirm = new Business();
			BusinessLoginDataHandler readingFirm = new BusinessLoginDataHandler();
			try{
				myFirm = readingFirm.GetOne(id);
			}catch{
				System.Console.WriteLine("Error doesnt exist");
			}
			return myFirm;
		}

		// GET: api/EmployeeLogin/5
		[EnableCors("OpenPolicy")]
		[HttpGet("GetFirmByUsername/{uname}")]
		public Business GetByUsername(string uname)
		{
			Business myFirm = new Business();
			BusinessLoginDataHandler readingFirm = new BusinessLoginDataHandler();
			try{
				myFirm = readingFirm.GetOneUsername(uname);
			}catch{
				System.Console.WriteLine("Error doesnt exist");
			}
			return myFirm;
		}

		// POST: api/BusinessLogin
		[EnableCors("OpenPolicy")]
		[HttpPost]
		public void Post([FromBody] Business value)
		{
			IBusinessLoginDataHandler dataHandler = new BusinessLoginDataHandler();
			dataHandler.Insert(value);
			
		}

		// PUT: api/BusinessLogin/5
		[EnableCors("OpenPolicy")]
		[HttpPut("UpdateByUsername")]
		public void Put([FromBody] Business value)
		{
			BusinessLoginDataHandler updating = new BusinessLoginDataHandler();
			updating.UpdateByUsername(value);
		}
	}
}
