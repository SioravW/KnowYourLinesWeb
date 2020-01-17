using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class PlayData : IPlayData
    {
        public List<Scene> GetScenes(int id)
        {
            List<Scene> scenes = new List<Scene>();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [name], [number] " +
                "from dbo.[scene] where playId = @id;";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            while (sdr.Read())
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

        public List<Role> GetRoles(int id)
        {

            List<Role> roles = new List<Role>();
            UserCollectionData userCollectionData = new UserCollectionData();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [name], [description], [userId] " +
                "from dbo.[role] where playId = @id;";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            while (sdr.Read())
            {
                Role role = new Role();
                role.Id = sdr.GetInt32(0);
                role.Name = sdr.GetString(1);
                role.Description = sdr.GetString(2);
                role.Player = userCollectionData.GetUserById(sdr.GetInt32(3));
                roles.Add(role);
            }
            sqlconn.Close();

            return roles;
        }

        public Role GetRoleById(int id)
        {
            Role role = new Role();
            UserCollectionData userCollectionData = new UserCollectionData();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [name], [description],[userId] " +
                "from dbo.[role] where id = @id;";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            if (sdr.Read())
            {
                role.Id = sdr.GetInt32(0);
                role.Name = sdr.GetString(1);
                role.Description = sdr.GetString(2);
                role.Player = userCollectionData.GetUserById(sdr.GetInt32(3));
            }
            sqlconn.Close();

            return role;
        }
        public Scene GetSceneById(int id)
        {
            Scene scene = new Scene();
            SceneData sceneData = new SceneData();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [name], [number] " +
                "from dbo.[scene] where id = @id;";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            if (sdr.Read())
            {
                scene.Id = sdr.GetInt32(0);
                scene.Name = sdr.GetString(1);
                scene.Number = sdr.GetInt32(2);
            }
            sqlconn.Close();

            scene.Lines = sceneData.GetLines(scene.Id);

            return scene;
        }
    }
}
