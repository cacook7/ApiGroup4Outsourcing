using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
	public interface IBusinessLoginDataHandler
	{
		public List<Business> GetAll();
		
		public Business GetOne(int id);

		public void Delete(Business business);

		public void Update(Business business);

		public void Insert(Business business);
		
		public void UpdateByUsername(Business business);
		
		public List<RentingBusiness> GetCurrentBusinesses();
	}
}