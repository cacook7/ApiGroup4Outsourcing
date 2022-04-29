using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
	public interface IRentalApplicationDataHandler
	{
		public List<RentalApplication> GetAll();
		
		public List<RentalApplication> GetByFirm(int id);
		
		public RentalApplication GetByAppID(int id);
		
		public void Delete(RentalApplication rentalApplication);
		
		public void Insert(RentalApplication rentalApplication);
	}
}