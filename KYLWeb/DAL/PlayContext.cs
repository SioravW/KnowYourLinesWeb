using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class PlayContext : IPlay
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
            }
            sqlconn.Close();

            List<Scene> scenes = GetScenes(play.Id);

            return play;
        }

        private List<Scene> GetScenes(int id)
        {
            List<Scene> scenes = new List<Scene>();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [name], [number] " +
                "from dbo.[scene] where playId = @id";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            if (sdr.Read())
            {
                Scene scene = new Scene();
                scene.Id = sdr.GetInt32(0);
                scene.Name = sdr.GetString(1);
                scene.Number = sdr.GetInt32(2);
                scenes.Add(scene);
            }
            sqlconn.Close();

            return scenes;
        }

        public List<Play> GetAllPlaysOfUser(User user)
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
    }
}
