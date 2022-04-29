using api.Interfaces;
using api.Models;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api.Data
{
	public class RentalDataHandler : IRentalDataHandler
	{
		private Database db;
		public RentalDataHandler()
		{
			db = new Database();
		}
		public List<Rental>GetAll()
		{
			List<Rental> myRentals = new List<Rental>();
			Database myConnection = new Database();
			string cs = myConnection.ConnString;
			
			using var con = new MySqlConnection(cs);
			con.Open();
			string stm = "select * from space WHERE available = '0'";
			using var cmd = new MySqlCommand(stm, con);
			
			using MySqlDataReader rdr = cmd.ExecuteReader();
			
			while(rdr.Read())
			{
				myRentals.Add(new Rental(){SpaceID = rdr.GetInt32(0), Size = rdr.GetInt32(1), MonthlyPrice = rdr.GetInt32(2)});
			}
			con.Close();
			return myRentals;
		}
		
		public Rental GetOne(int id)
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;

			using var con = new MySqlConnection(cs);
			con.Open();
			string stm = "select * from space where spaceID = " + id;
			using var cmd = new MySqlCommand(stm, con);
			
			using MySqlDataReader rdr = cmd.ExecuteReader();

			rdr.Read();
			
			Rental temp = new Rental(){SpaceID = rdr.GetInt32(0), Size = rdr.GetInt32(1), MonthlyPrice = rdr.GetInt32(2)};
			
			con.Close();
			
			return temp;
		}

		public List<RentalTransaction> GetAllTransactions()
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;
			List<RentalTransaction> temp = new List<RentalTransaction>();

			using var con = new MySqlConnection(cs);
			con.Open();
			string stm = "select rt.*, firmName";
			stm += " from rentaltransaction rt join firm f on (rt.firmID = f.firmID)";
			using var cmd = new MySqlCommand(stm, con);

			using MySqlDataReader rdr = cmd.ExecuteReader();
			
			while(rdr.Read())
			{
				temp.Add(new RentalTransaction(){FirmID = rdr.GetInt32(0), SpaceID = rdr.GetInt32(1), AppID = rdr.GetInt32(2), EmpID = rdr.GetInt32(3), StartDate = rdr.GetDateTime(4), EndDate = rdr.GetDateTime(5), ApprovalDate = rdr.GetDateTime(6), FirmName = rdr.GetString(7)});
			}

			con.Close();
			return temp;
		}
		public List<RentalTransaction> GetTransactionByFirm(int id)
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;
			List<RentalTransaction> temp = new List<RentalTransaction>();

			using var con = new MySqlConnection(cs);
			con.Open();
			string stm =  "select * from rentaltransaction where firmID = " + id;
			using var cmd = new MySqlCommand(stm, con);

			using MySqlDataReader rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				temp.Add(new RentalTransaction(){FirmID = rdr.GetInt32(0), SpaceID = rdr.GetInt32(1), AppID = rdr.GetInt32(2), EmpID = rdr.GetInt32(3), StartDate = rdr.GetDateTime(4), EndDate = rdr.GetDateTime(5), ApprovalDate = rdr.GetDateTime(6)});
			}

			con.Close();
			return temp;
		}
		
		public void Delete(Rental rental)
		{
			string sql = "UPDATE space SET available='1' WHERE spaceID=@spaceID";
			var values = GetValues(rental);
			db.Open();
			db.Update(sql, values);
			db.Close();
		}

		public void InsertTransaction(RentalTransaction temp)
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;
			using var con = new MySqlConnection(cs);
            con.Open();
			System.Console.WriteLine("made it to before stm");
            string stm = @"INSERT INTO rentaltransaction(firmID, spaceID, appID, empID, startDate, endDate, approvalDate) VALUES(@firmID, @spaceID, @appID, @empID, @startDate, @endDate, @approvalDate)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@firmID", temp.FirmID);
            cmd.Parameters.AddWithValue("@spaceID", temp.SpaceID);
			cmd.Parameters.AddWithValue("@appID", temp.AppID);
			cmd.Parameters.AddWithValue("@empID", temp.EmpID);
			cmd.Parameters.AddWithValue("@startDate", temp.StartDate);
			cmd.Parameters.AddWithValue("@endDate", temp.EndDate);
			cmd.Parameters.AddWithValue("@approvalDate", temp.ApprovalDate);
			System.Console.WriteLine("made it to after stm");
            cmd.Prepare();
			System.Console.WriteLine("made it to after prepare");
            cmd.ExecuteNonQuery();
			System.Console.WriteLine("made it to after execute");
			con.Close();
		}
		
		public Dictionary<string, object> GetValues(Rental rental)
		{
			var values = new Dictionary<string, object>()
			{
				{"@spaceID", rental.SpaceID},
				{"@size", rental.Size},
				{"@pricePM", rental.MonthlyPrice}
			};
			return values;
		}
		
		public void Update(Rental rental)
		{
			throw new System.NotImplementedException();
		}
		
		public void Insert(Rental rental)
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;
			using var con = new MySqlConnection(cs);
            con.Open();
			System.Console.WriteLine("made it to before stm");
            string stm = @"INSERT INTO space(size, pricePM, available) VALUES(@size, @pricePM, @available)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@size", rental.Size);
            cmd.Parameters.AddWithValue("@pricePM", rental.MonthlyPrice);
			cmd.Parameters.AddWithValue("@available", 0);
			System.Console.WriteLine("made it to after stm");
            cmd.Prepare();
			System.Console.WriteLine("made it to after prepare");
            cmd.ExecuteNonQuery();
			System.Console.WriteLine("made it to after execute");
			con.Close();
		}
	}
}