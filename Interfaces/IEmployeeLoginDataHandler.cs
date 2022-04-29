using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
	public interface IEmployeeLoginDataHandler
	{
		public List<Employee> GetAll();
		
		public Employee GetOne(int id);

		public void Delete(Employee employee);

		public void Update(Employee employee);

		public void Insert(Employee employee);
		
		public void UpdateByUsername(Employee employee);
	}
}