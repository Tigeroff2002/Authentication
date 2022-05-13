using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MVC.Models;

namespace MVC.DAO
{
    public class RecordsDAO : DAO
    {
        public List<Records> GetAllRecords()
        {
            Connect();
            List<Records> recordList = new List<Records>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM books", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Records record = new Records();
                    record.ID = Convert.ToInt32(reader["ID"]);
                    record.Author =
                   Convert.ToString(reader["Author"]);
                    record.Name =
                   Convert.ToString(reader["Name"]);
                    record.Rating = Convert.ToInt32(reader["Rating"]);
                    record.Date =
                   Convert.ToDateTime(reader["Date"]);
                    recordList.Add(record);
                }
                reader.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                Disconnect();
            }
            return recordList;
        }

        public bool AddRecord(Records records)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO books (Name, Author, Rating, Date) " + "VALUES (@Name, @Author, @Rating, @Date)", Connection);
                cmd.Parameters.Add(new SqlParameter("@Title", records.Name));
                cmd.Parameters.Add(new SqlParameter("@Author", records.Author));
                cmd.Parameters.Add(new SqlParameter("@Date", records.Rating));
                cmd.Parameters.Add(new SqlParameter("@Author", records.Date));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
    }

}
