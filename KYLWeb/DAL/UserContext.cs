using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    class UserContext : IUser
    {
        public User GetUserById(int id)
        {
            User user = new User();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [username]" +
                "from dbo.[user] where id = @id";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            if (sdr.Read())
            {
                user.Id = sdr.GetInt32(0);
                user.Username = sdr.GetString(1);
            }
            sqlconn.Close();

            user.Plays = GetPlays(id);

            return user;
        }

        private List<Play> GetPlays(int id)
        {
            List<Play> plays = new List<Play>();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [title], [description], [association], [writer] " +
                "from dbo.[play] where id = @id";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            if (sdr.Read())
            {
                Play play = new Play();
                play.Id = sdr.GetInt32(0);
                play.Title = sdr.GetString(1);
                play.Description = sdr.GetString(2);
                int association = sdr.GetInt32(3);
                int writer = sdr.GetInt32(4);
                plays.Add(play);
            }
            sqlconn.Close();

            return plays;
        }
    }
}
