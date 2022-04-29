using api.Interfaces;
using api.Models;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api.Data
{
	public class EmployeeDataHandler : IEmployeeLoginDataHandler
	{
		// private Database db;
		public List<Employee> GetAll()
		{
			List<Employee> myEmps = new List<Employee>();
			Database myConnection = new Database();
			string cs = myConnection.ConnString;

			using var con = new MySqlConnection(cs);
			con.Open();
			string stm = "select * from employee";
			using var cmd = new MySqlCommand(stm, con);

			using MySqlDataReader rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				myEmps.Add(new Employee(){EmpID = rdr.GetInt32(0), FName = rdr.GetString(1), LName = rdr.GetString(2), Birthday = rdr.GetDateTime(3), IsAdmin = rdr.GetInt32(4), Email = rdr.GetString(5), Username = rdr.GetString(6), Password = rdr.GetString(7), Deleted = rdr.GetInt32(8)});
			}
			con.Close();
			
			return myEmps;
		}

		public Employee GetOne(int id)
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;

			using var con = new MySqlConnection(cs);
			con.Open();
			string stm = "select * from employee where empID = " + id;
			using var cmd = new MySqlCommand(stm, con);

			using MySqlDataReader rdr = cmd.ExecuteReader();

			rdr.Read();
			
			Employee temp = new Employee(){EmpID = rdr.GetInt32(0), FName = rdr.GetString(1), LName = rdr.GetString(2), Birthday = rdr.GetDateTime(3), IsAdmin = rdr.GetInt32(4), Email = rdr.GetString(5), Username = rdr.GetString(6), Password = rdr.GetString(7), Deleted = rdr.GetInt32(8)};

			con.Close();

			return temp;
		}
		
		public void Delete(Employee employee)
		{
			throw new System.NotImplementedException();
		}
		public void Update(Employee employee)
		{
			throw new System.NotImplementedException();
		}
		
		public void Insert(Employee employee)
		{
			throw new System.NotImplementedException();
		}
		
		public void UpdateByUsername(Employee employee)
		{
			throw new System.NotImplementedException();
		}
	}
}