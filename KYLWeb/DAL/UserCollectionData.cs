using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class UserCollectionData : IUserCollectionData
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
            user.Associations = GetAssociations(id);

            return user;
        }

        private List<Play> GetPlays(int id)
        {
            List<Play> plays = new List<Play>();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [title], [description], [association], [writer] " +
                "from dbo.[play] where writer = @id or association in (select [associationId] from [user_association] where userId = @id)";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            while (sdr.Read())
            {
                Play play = new Play();
                play.Id = sdr.GetInt32(0);
                play.Title = sdr.GetString(1);
                play.Description = sdr.GetString(2);
                play.AssociationId = sdr.GetInt32(3);
                play.WriterId = sdr.GetInt32(4);
                plays.Add(play);
            }

            sqlconn.Close();

            return plays;
        }

        private List<int> GetAssociations(int id)
        {
            List<int> associations = new List<int>();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [associationId] " +
                "from dbo.[user_association] where userId = @id";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            if (sdr.Read())
            {
                associations.Add(sdr.GetInt32(0));
            }
            sqlconn.Close();

            return associations;
        }
    }
}