using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Controllers;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RentalApplicationController : ControllerBase
	{
		// GET: api/RentalApplication
		[EnableCors("OpenPolicy")]
		[HttpGet]
		public List<RentalApplication> Get()
		{
			RentalApplicationDataHandler getting = new RentalApplicationDataHandler();
			List<RentalApplication> temp = getting.GetAll();
			return temp;
		}

		// GET: api/RentalApplication/5
		[EnableCors("OpenPolicy")]
		[HttpGet("GetAppByFirm/{id}")]
		public List<RentalApplication> Get(int id)
		{
			RentalApplicationDataHandler getting = new RentalApplicationDataHandler();
			List<RentalApplication> temp = getting.GetByFirm(id);
			return temp;
		}

		// POST: api/RentalApplication
        [EnableCors("OpenPolicy")]
		[HttpPost("PostApplication")]
		public void Post([FromBody] RentalApplication value)
		{
            value.AppSubmitDate = DateTime.Now;
            value.Approved = "n";
            RentalApplicationDataHandler inserting = new RentalApplicationDataHandler();
            inserting.Insert(value);
		}

		// DELETE: api/RentalApplication/5
		[EnableCors("OpenPolicy")]
		[HttpDelete("{appID}/{empID}")]
		public void Delete(int appID, int empID)
		{
			RentalApplication value = new RentalApplication(){AppID=appID};
			value.dataHandler.Delete(value);
            RentalApplicationDataHandler getting = new RentalApplicationDataHandler();
            RentalApplication temp = getting.GetByAppID(appID);
            RentalTransaction newTransaction = new RentalTransaction(){FirmID = temp.FirmID, SpaceID = temp.SpaceID, AppID = temp.AppID, EmpID = empID, StartDate = temp.AppStartDate, EndDate = temp.AppEndDate, ApprovalDate = DateTime.Now};
            Post(newTransaction);
		}

        // POST: api/Rental
		[EnableCors("OpenPolicy")]
		[HttpPost("PostTransaction")]
		public void Post(RentalTransaction value)
		{
            RentalDataHandler posting = new RentalDataHandler();
            posting.InsertTransaction(value);
		}
	}
}
