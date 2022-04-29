using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
	public interface IRentalDataHandler
	{
		 public List<Rental> GetAll();
		 
		 public Rental GetOne(int id);
		 
		 public List<RentalTransaction> GetAllTransactions();
		 
		 public List<RentalTransaction> GetTransactionByFirm(int id);
		 
		 public void Delete(Rental rental);
		 
		 public void InsertTransaction(RentalTransaction temp);
		 
		 public void Update(Rental rental);
		 
		 public void Insert(Rental rental);
	}
}