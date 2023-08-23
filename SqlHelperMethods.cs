using MachineAssignment.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MachineAssignment.HelperMethods
{
    public class SqlHelperMethods
    {
        private string connectionString;

        public SqlHelperMethods()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnStr"].ConnectionString;
        }

        public DataSet ExecuteDataset(string procedureName, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    adapter.SelectCommand = command;

                    if (parameters != null && parameters.Any())
                    {
                        foreach (var param in parameters)
                        {
                            adapter.SelectCommand.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    DataSet dataSet = new DataSet();

                    adapter.Fill(dataSet);
                    connection.Close();
                    return dataSet;
                }
            }
        }

        public DataTable ExecuteDataTable(string procedureName, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // string sql = "sp_getEmployees";

                List<Employee> employees = new List<Employee>();
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    adapter.SelectCommand = command;

                    if (parameters != null && parameters.Any())
                    {
                        foreach (var param in parameters)
                        {
                            adapter.SelectCommand.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    connection.Close();
                    return dt;
                }
            }
        }

        public int ExecuteSqlNonQuery(string procedureName, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            int returnValue;
            using (SqlConnection connection = new SqlConnection(connectionString))

            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                if (parameters != null && parameters.Any())
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }


                returnValue = command.ExecuteNonQuery();
                connection.Close();
                return returnValue;
            }
        }
    }

}