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
	public class RentalController : ControllerBase
	{
		// GET: api/Rental
		[EnableCors("OpenPolicy")]
		[HttpGet]
		public List<Rental> GetRentals()
		{
			RentalDataHandler readingRentals = new RentalDataHandler();
			List<Rental> myRentals = readingRentals.GetAll();
			return myRentals;
		}

		// GET: api/Rental/5
		[EnableCors("OpenPolicy")]
		[HttpGet("{id}", Name = "Get")]
		public Rental Get(int id)
		{
			Rental myRental = new Rental();
			RentalDataHandler readingRentals = new RentalDataHandler();
			try
			{
				myRental = readingRentals.GetOne(id);
			}catch
			{
				System.Console.WriteLine("Error, doesn't exist");
			}
			return myRental;
		}

		[EnableCors("OpenPolicy")]
		[HttpGet("GetTransactions")]
		public List<RentalTransaction> Get()
		{
			RentalDataHandler getting = new RentalDataHandler();
			List<RentalTransaction> temp = getting.GetAllTransactions();
			return temp;
		}

		// GET: api/RentalApplication/5
		[EnableCors("OpenPolicy")]
		[HttpGet("GetTransactionsByFirm/{id}")]
		public List<RentalTransaction> GetByFirm(int id)
		{
			RentalDataHandler getting = new RentalDataHandler();
			List<RentalTransaction> temp = getting.GetTransactionByFirm(id);
			return temp;
		}

		// DELETE: api/Rental/5
		[EnableCors("OpenPolicy")]
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			Rental value = new Rental(){SpaceID=id};
			value.dataHandler.Delete(value);
		}

		// PUT: api/Rental/5
		[EnableCors("OpenPolicy")]
		[HttpPost]
		// [HttpPut("{id}")]
		public void Post([FromBody] Rental value)
		{
			RentalDataHandler dataHandler = new RentalDataHandler();
			dataHandler.Insert(value);
		}
	}
}