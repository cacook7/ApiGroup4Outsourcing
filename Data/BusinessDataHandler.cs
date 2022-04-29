using api.Interfaces;
using api.Models;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api.Data
{
	public class BusinessDataHandler : IBusinessLoginDataHandler
	{
		// private Database db;
		public List<Business> GetAll()
		{
			List<Business> myFirms = new List<Business>();
			Database myConnection = new Database();
			string cs = myConnection.ConnString;

			using var con = new MySqlConnection(cs);
			con.Open();
			string stm = "select * from firm WHERE deleted='0'";
			using var cmd = new MySqlCommand(stm, con);

			using MySqlDataReader rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				myFirms.Add(new Business(){FirmID = rdr.GetInt32(0), Email = rdr.GetString(1), FirmName = rdr.GetString(2), RepFName = rdr.GetString(3), RepLName = rdr.GetString(4), FirmDescription = rdr.GetString(5), Username = rdr.GetString(6), Password = rdr.GetString(7), Deleted = rdr.GetInt32(8), PhoneNumber1 = rdr.GetString(9), PhoneNumber2 = rdr.GetString(10)});
			}
			con.Close();

			return myFirms;
		}

		public Business GetOne(int id)
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;

			using var con = new MySqlConnection(cs);
			con.Open();
			string stm = "select * from firm where firmID = " + id;
			using var cmd = new MySqlCommand(stm, con);

			using MySqlDataReader rdr = cmd.ExecuteReader();

			rdr.Read();
			
			Business temp = new Business(){FirmID = rdr.GetInt32(0), Email = rdr.GetString(1), FirmName = rdr.GetString(2), RepFName = rdr.GetString(3), RepLName = rdr.GetString(4), FirmDescription = rdr.GetString(5), Username = rdr.GetString(6), Password = rdr.GetString(7), Deleted = rdr.GetInt32(8), PhoneNumber1 = rdr.GetString(9), PhoneNumber2 = rdr.GetString(10)};
			

			con.Close();
			return temp;
		}
		public void Delete(Business business)
		{
			throw new System.NotImplementedException();

		}
		public void Update(Business business)
		{
			throw new System.NotImplementedException();
		}
		
		public void Insert(Business business)
		{
			throw new System.NotImplementedException();
		}
		
		public void GetOneUsername(string uname)
		{
			throw new System.NotImplementedException();
		}
		
		public void UpdateByUsername(Business business)
		{
			throw new System.NotImplementedException();
		}
		
		public List<RentingBusiness> GetCurrentBusinesses()
		{
			throw new System.NotImplementedException();
		}
	}
}