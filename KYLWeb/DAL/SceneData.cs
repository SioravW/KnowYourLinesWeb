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
                "from dbo.[line] where sceneId = @id;";
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

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [name]" +
                "from dbo.[role] where id in (select [roleId] from [line_role] where lineId = @lineId);";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@lineId", id);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            while (sdr.Read())
            {
                Role role = new Role();
                role.Id = sdr.GetInt32(0);
                role.Name = sdr.GetString(1);
                roles.Add(role);
            }
            sqlconn.Close();

            return roles;
        }

        public Role AddRoleInDB(Role role)
        {
            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "INSERT INTO dbo.[role] ([name], [description])" +
                "VALUES (@name, @description);";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@name", role.Name);
            sqlComm.Parameters.AddWithValue("@description", role.Description);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            sqlconn.Close();

            Role role2 = GetRoleByNameAndDiscription(role.Name, role.Description);

            return role2;
        }

        public Role GetRoleByNameAndDiscription(String name, String description)
        {
            Role role = new Role();

            string mainconn = ConnectionString.connectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select [id], [name], [description] " +
                "from dbo.[role] where name = @name and description = @description;";
            sqlconn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
            sqlComm.Parameters.AddWithValue("@name", name);
            sqlComm.Parameters.AddWithValue("@description", description);
            SqlDataReader sdr = sqlComm.ExecuteReader();
            if (sdr.Read())
            {
                role.Id = sdr.GetInt32(0);
                role.Name = sdr.GetString(1);
                role.Description = sdr.GetString(2);
            }
            sqlconn.Close();

            return role;
        }
    }
}
