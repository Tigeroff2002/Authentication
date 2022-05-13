using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace MVC.DAO
{
    public class DAO
    {
        private string ConnectionString = "Data Source=DESKTOP-FT8M1MD;Initial Catalog=Library;Integrated Security=True";
        //подключение идет через Microsoft SQL Server, DESKTOP-FT8M1MD - это имя сервера (вашего компьютера), Library - имя созданной БД в MS SQL
        public SqlConnection Connection { get; set; }
        public void Connect()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }
        public void Disconnect()
        {
            Connection.Close();
        }
    }
}
