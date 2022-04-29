using api.Interfaces;
using api.Models;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api.Data
{
	public class RentalApplicationDataHandler : IRentalApplicationDataHandler
	{
		private Database db;
		
		public RentalApplicationDataHandler()
		{
			db = new Database();
		}
		
		public List<RentalApplication> GetAll()
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;
			List<RentalApplication> temp = new List<RentalApplication>();

			using var con = new MySqlConnection(cs);
			con.Open();
			string stm = "select rentalapplication.firmID, firmName, spaceID, appID, appStartDate, appEndDate, application, approved"; 
			stm += " from rentalapplication join firm on (rentalapplication.firmID = firm.firmID) order by application desc";
			using var cmd = new MySqlCommand(stm, con);

			using MySqlDataReader rdr = cmd.ExecuteReader();
			
			while(rdr.Read())
			{
				temp.Add(new RentalApplication(){FirmID = rdr.GetInt32(0), FirmName = rdr.GetString(1), SpaceID = rdr.GetInt32(2), AppID = rdr.GetInt32(3), AppStartDate = rdr.GetDateTime(4), AppEndDate = rdr.GetDateTime(5), AppSubmitDate = rdr.GetDateTime(6), Approved = rdr.GetString(7)});
			}

			con.Close();
			return temp;
		}
		public List<RentalApplication> GetByFirm(int id)
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;
			List<RentalApplication> temp = new List<RentalApplication>();

			using var con = new MySqlConnection(cs);
			con.Open();
			string stm = "select rentalapplication.firmID, firmName, spaceID, appID, appStartDate, appEndDate, application, approved"; 
			stm += " from rentalapplication join firm on (rentalapplication.firmID = firm.firmID) where rentalapplication.firmID = " + id + " order by application desc";
			using var cmd = new MySqlCommand(stm, con);

			using MySqlDataReader rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				temp.Add(new RentalApplication(){FirmID = rdr.GetInt32(0), FirmName = rdr.GetString(1), SpaceID = rdr.GetInt32(2), AppID = rdr.GetInt32(3), AppStartDate = rdr.GetDateTime(4), AppEndDate = rdr.GetDateTime(5), AppSubmitDate = rdr.GetDateTime(6), Approved = rdr.GetString(7)});
			}

			con.Close();
			return temp;
		}

		public RentalApplication GetByAppID(int id)
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;

			using var con = new MySqlConnection(cs);
			con.Open();
			string stm = "select rentalapplication.firmID, firmName, spaceID, appID, appStartDate, appEndDate, application, approved"; 
			stm += " from rentalapplication join firm on (rentalapplication.firmID = firm.firmID) where rentalapplication.appID = " + id;
			using var cmd = new MySqlCommand(stm, con);

			using MySqlDataReader rdr = cmd.ExecuteReader();

			rdr.Read();
			
			RentalApplication temp = new RentalApplication(){FirmID = rdr.GetInt32(0), FirmName = rdr.GetString(1), SpaceID = rdr.GetInt32(2), AppID = rdr.GetInt32(3), AppStartDate = rdr.GetDateTime(4), AppEndDate = rdr.GetDateTime(5), AppSubmitDate = rdr.GetDateTime(6), Approved = rdr.GetString(7)};

			con.Close();
			return temp;
		}
		
		public void Delete(RentalApplication rentalApplication)
		{
			string sql = "UPDATE rentalapplication SET approved='Y' WHERE appID=@appID";
			var values = GetValues(rentalApplication);
			db.Open();
			db.Update(sql, values);
			db.Close();
		}

		public void Insert(RentalApplication rentalApplication)
		{
			Database myConnection = new Database();
			string cs = myConnection.ConnString;
			using var con = new MySqlConnection(cs);
            con.Open();
			System.Console.WriteLine("made it to before stm");
            string stm = @"INSERT INTO rentalapplication(firmID, spaceID, appStartDate, appEndDate, application, approved) VALUES(@firmID, @spaceID, @appStartDate, @appEndDate, @application, @approved)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@firmID", rentalApplication.FirmID);
            cmd.Parameters.AddWithValue("@spaceID", rentalApplication.SpaceID);
			cmd.Parameters.AddWithValue("@appStartDate", rentalApplication.AppStartDate);
			cmd.Parameters.AddWithValue("@appEndDate", rentalApplication.AppEndDate);
			cmd.Parameters.AddWithValue("@application", rentalApplication.AppSubmitDate);
			cmd.Parameters.AddWithValue("@approved", rentalApplication.Approved);
			System.Console.WriteLine("made it to after stm");
            cmd.Prepare();
			System.Console.WriteLine("made it to after prepare");
            cmd.ExecuteNonQuery();
			System.Console.WriteLine("made it to after execute");
			con.Close();
		}
		
		public Dictionary<string, object> GetValues(RentalApplication rentalApplication)
		{
			var values = new Dictionary<string, object>()
			{
				{"@firmID", rentalApplication.FirmID},
				{"@spaceID", rentalApplication.SpaceID},
				{"@appID", rentalApplication.AppID},
				{"@appStartDate", rentalApplication.AppStartDate},
				{"@appEndDate", rentalApplication.AppEndDate},
				{"@application", rentalApplication.AppSubmitDate},
				{"@approved", rentalApplication.Approved}
			};
			return values;
		}
	}
}