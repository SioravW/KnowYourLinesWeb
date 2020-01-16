using BLL;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class SceneData : ISceneData
    {
        public List<Line> GetLines(int id)
        {
            List<Line> lines = new List<Line>();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [text], [index] " +
                "from dbo.[line] where sceneId = @id";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            while (sdr.Read())
            {
                Line line = new Line();
                line.Id = sdr.GetInt32(0);
                line.Text = sdr.GetString(1);
                line.Index = sdr.GetInt32(2);
                line.Roles = GetRolesOfLine(line.Id);
                lines.Add(line);
            }
            sqlconn.Close();

            return lines;
        }

        public List<Role> GetRolesOfLine(int id)
        {
            List<Role> roles = new List<Role>();

            return roles;
        }
    }
}
