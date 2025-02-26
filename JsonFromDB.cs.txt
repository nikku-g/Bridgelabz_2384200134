using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        string connectionString = "Connection String"; // Replace with actual connection string
        string query = "SELECT Id, Name, Age, City FROM Users"; // Replace with table/query

        DataTable dataTable = FetchDataFromDatabase(connectionString, query);
        string jsonReport = ConvertDataTableToJson(dataTable);

        // Save to a file
        File.WriteAllText("Report.json", jsonReport);

        // Display JSON
        Console.WriteLine(jsonReport);
    }

    static DataTable FetchDataFromDatabase(string connectionString, string query)
    {
        DataTable dataTable = new DataTable();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
        }

        return dataTable;
    }

    static string ConvertDataTableToJson(DataTable dataTable)
    {
        return JsonConvert.SerializeObject(dataTable, Formatting.Indented);
    }
}
