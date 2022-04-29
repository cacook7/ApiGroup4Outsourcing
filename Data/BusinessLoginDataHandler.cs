using api.Interfaces;
using api.Models;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api.Data
{
	public class BusinessLoginDataHandler : IBusinessLoginDataHandler
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

		public Business GetOneUsername(string uname)
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;

			using var con = new MySqlConnection(cs);
			con.Open();
			string stm = "select * from firm where username = '" + uname + "'";
			using var cmd = new MySqlCommand(stm, con);

			using MySqlDataReader rdr = cmd.ExecuteReader();

			rdr.Read();
			
			Business temp = new Business(){FirmID = rdr.GetInt32(0), Email = rdr.GetString(1), FirmName = rdr.GetString(2), RepFName = rdr.GetString(3), RepLName = rdr.GetString(4), FirmDescription = rdr.GetString(5), Username = rdr.GetString(6), Password = rdr.GetString(7), Deleted = rdr.GetInt32(8), PhoneNumber1 = rdr.GetString(9), PhoneNumber2 = rdr.GetString(10)};


			con.Close();
			return temp;
		}

		public void UpdateByUsername(Business business)
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;
			using var con = new MySqlConnection(cs);
            con.Open();
			System.Console.WriteLine("made it to before stm");
            string stm = @$"UPDATE firm SET email = @email, password = @password, repFN = @fName, repLN = @lName, phoneNum1 = @phoneNum1, phoneNum2 = @phoneNum2, firmName = @firmName, description = @description WHERE username = '{business.Username}'";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@email", business.Email);
            cmd.Parameters.AddWithValue("@password", business.Password);
			cmd.Parameters.AddWithValue("@fName", business.RepFName);
			cmd.Parameters.AddWithValue("@lName", business.RepLName);
			cmd.Parameters.AddWithValue("@phoneNum1", business.PhoneNumber1);
            cmd.Parameters.AddWithValue("@phoneNum2", business.PhoneNumber2);
			cmd.Parameters.AddWithValue("@firmName", business.FirmName);
            cmd.Parameters.AddWithValue("@description", business.FirmDescription);
			System.Console.WriteLine("made it to after stm");
            cmd.Prepare();
			System.Console.WriteLine("made it to after prepare");
            cmd.ExecuteNonQuery();
			System.Console.WriteLine("made it to after execute");
			con.Close();
		}

		public List<RentingBusiness> GetCurrentBusinesses()
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;
			List<RentingBusiness> temp = new List<RentingBusiness>();

			using var con = new MySqlConnection(cs);
			con.Open();
			string stm = "select distinct f.firmID, email, firmName, repFN, repLN, description, username, password, deleted, phoneNum1, phoneNum2, startDate, endDate";
			stm += " from firm f join rentaltransaction rt on (f.firmID = rt.firmID) where deleted = '0'";
			using var cmd = new MySqlCommand(stm, con);

			using MySqlDataReader rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				temp.Add(new RentingBusiness(){FirmID = rdr.GetInt32(0), Email = rdr.GetString(1), FirmName = rdr.GetString(2), RepFName = rdr.GetString(3), RepLName = rdr.GetString(4), FirmDescription = rdr.GetString(5), Username = rdr.GetString(6), Password = rdr.GetString(7), Deleted = rdr.GetInt32(8), PhoneNumber1 = rdr.GetString(9), PhoneNumber2 = rdr.GetString(10), StartDate = rdr.GetDateTime(11), EndDate = rdr.GetDateTime(12)});
			}

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
			Database myConnection = new Database();
			string cs = myConnection.ConnString;
			using var con = new MySqlConnection(cs);
            con.Open();
			System.Console.WriteLine("made it to before stm");
            string stm = @"INSERT INTO firm(email, firmName, repFN, repLN, username, password, deleted) VALUES(@email, @firmName, @repFN, @repLN, @username, @password, @deleted)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@email", business.Email);
            cmd.Parameters.AddWithValue("@firmName", business.FirmName);
			cmd.Parameters.AddWithValue("@repFN", business.RepFName);
			cmd.Parameters.AddWithValue("@repLN", business.RepLName);
			cmd.Parameters.AddWithValue("@username", business.Username);
			cmd.Parameters.AddWithValue("@password", business.Password);
            cmd.Parameters.AddWithValue("@deleted", 0);
			System.Console.WriteLine("made it to after stm");
            cmd.Prepare();
			System.Console.WriteLine("made it to after prepare");
            cmd.ExecuteNonQuery();
			System.Console.WriteLine("made it to after execute");
			con.Close();
		}
	}
}