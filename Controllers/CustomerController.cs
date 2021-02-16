using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Models;

namespace aspMvcLesson4Handson.Controllers {
    // MVC is handling the routing for you.
    [Route("api/[Controller]")]
    public class CustomerController : Controller {

        // api/database
        [HttpGet]
        public List<Customer> GetTwentyCustomers() {
          // tracks will be populated with the result of the query.
          List<Customer> customers = new List<Customer>();

          // GetFullPath will return a string to complete the absolute path.
          string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");

          // using will make sure that the resource is cleaned from memory after it exists
          // conn initializes the connection to the .db file.
          using(SqliteConnection conn = new SqliteConnection(dataSource)) {

            conn.Open(); 
            // sql is the string that will be run as an sql command
            string sql = $"select * from customerss limit 20;";
            // command combines the connection and the command string and creates the query
            using(SqliteCommand command = new SqliteCommand(sql, conn)) {

              // reader allows you to read each value that comes back and do something to it.
              using(SqliteDataReader reader = command.ExecuteReader()) {

                  // Read returns true while there are more rows to advance to. then false when done.
                  while (reader.Read()) {

                      // map the data to the model.
                      Customer newC = new Customer() {
                        CustomerId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Company = reader.GetString(3),
                        Address = reader.GetString(4),
                        City = reader.GetString(5),
                        State = reader.GetString(6),
                        Country = reader.GetString(7),
                        PostalCode = reader.GetString(8),
                        Phone = reader.GetString(9),
                        Fax = reader.GetString(10),
                        Email = reader.GetString(11),
                        SupportRepId = reader.GetInt32(12)
                      };

                      // add each one to the list.
                      customers.Add(newC);
                  }
              }
            }

            conn.Close();
          }

          return customers;
        }
    }
}

// TRY TO IMPLEMENT FOR DRY procedures

// SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnString"].ConnectionString);
// SqlCommand comm = new SqlCommand("NameOfStoredProcedure", conn);
// comm.CommandType = CommandType.StoredProcedure;

// conn.Open();
// SqlCommandBuilder.DeriveParameters(comm);
// conn.Close();

// foreach (SqlParameter param in comm.Parameters)
// { /* do stuff */ }