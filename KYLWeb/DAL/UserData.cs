using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class UserData : IUserData
    {
        public Play GetPlayById(int id)
        {
            Play play = new Play();

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
                play.Id = sdr.GetInt32(0);
                play.Title = sdr.GetString(1);
                play.Description = sdr.GetString(2);
                play.AssociationId = sdr.GetInt32(3);
                play.WriterId = sdr.GetInt32(4);
            }
            sqlconn.Close();
            PlayData playData = new PlayData();
            play.Scenes = playData.GetScenes(play.Id);
            play.Roles = playData.GetRoles(play.Id);

            return play;
        }

        public Play GetPlayByTitleAndWriter(String title, int writer)
        {
            Play play = new Play();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [title], [description], [association], [writer] " +
                "from dbo.[play] where title = @title and writer = @writer";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@title", title);
            sqlComm.Parameters.AddWithValue("@writer", writer);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            if (sdr.Read())
            {
                play.Id = sdr.GetInt32(0);
                play.Title = sdr.GetString(1);
                play.Description = sdr.GetString(2);
                play.AssociationId = sdr.GetInt32(3);
                play.WriterId = sdr.GetInt32(4);
            }
            sqlconn.Close();
            PlayData playData = new PlayData();
            play.Scenes = playData.GetScenes(play.Id);
            play.Roles = playData.GetRoles(play.Id);

            return play;
        }
           

        public List<Play> GetAllPlays(User user)
        {
            List<Play> plays = new List<Play>();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [name], [number] " +
                "from dbo.[scene] where writer = @usId or association in @assId";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@usId", user.Id);

            SqlDataReader sdr = sqlComm.ExecuteReader();
            if (sdr.Read())
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

        public Play AddPlayInDB(Play play)
        {
            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "INSERT INTO dbo.[play] ([title], [description], [association], [writer])" +
                "VALUES (@title, @description, @association, @writer)";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@title", play.Title);
            sqlComm.Parameters.AddWithValue("@description", play.Description);
            sqlComm.Parameters.AddWithValue("@association", play.AssociationId);
            sqlComm.Parameters.AddWithValue("@writer", play.WriterId);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            sqlconn.Close();

            Play play2 = GetPlayByTitleAndWriter(play.Title, play.WriterId);

            return play2;
        }

        public Association GetAssociationById(int id)
        {
            Association association = new Association();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [name] " +
                "from dbo.[association] where id = @id";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            if (sdr.Read())
            {
                association.Id = sdr.GetInt32(0);
                association.Name = sdr.GetString(1);
            }
            sqlconn.Close();

            return association;
        }

        
    }
}