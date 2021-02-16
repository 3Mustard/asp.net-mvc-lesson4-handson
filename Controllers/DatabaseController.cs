using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace aspMvcLesson4Handson.Controllers {
    [Route("api/[GetEmployeeData]")]
    public List<Employee> GetEmployeeData() {

    // Employees will be populated with the result of the query.
    List<Employee> Employees = new List<Employee>();

    // GetFullPath will complete the path for the file named passed in as a string.
    string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");

    // using will make sure that the resource is cleaned from memory after it exists
    // conn initializes the connection to the .db file.
    using(SqliteConnection conn = new SqliteConnection(dataSource)) {

        conn.Open();

        // sql is the string that will be run as an sql command
        string sql = $"select * from Employees where HireDate < '2004' limit 10;";

        // command combines the connection and the command string and creates the query
        using(SqliteCommand command = new SqliteCommand(sql, conn)) {

            // reader allows you to read each value that comes back and do something to it.
            using(SqliteDataReader reader = command.ExecuteReader()) {

                // Read returns true while there are more rows to advance to. then false when done.
                while (reader.Read()) {

                    // map the data to the model.
                    Employee newEmployee = new Employee() {
                        EmployeeId = reader.GetInt32(0),
                        LastName = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        Title = reader.GetString(3),
                        ReportsTo = reader.GetInt32(4),
                        BirthDate = reader.GetString(5),
                        HireDate = reader.GetString(6),
                        Address = reader.GetString(7),
                        City = reader.GetString(8),
                        State = reader.GetString(9),
                        Country = reader.GetString(10),
                        PostalCode = reader.GetString(11),
                        Phone = reader.GetString(12),
                        Fax = reader.GetString(13),
                        Email = reader.GetString(14)
                    };

                    // add each one to the list.
                    Employees.Add(newEmployee);
                }
            }
        }
        conn.Close();
    }
    return Employees;
  }

  [Route("api/[GetCustomerData]")]
    public List<Customer> GetCustomerData() {

    // Employees will be populated with the result of the query.
    List<Customer> Customers = new List<Customer>();

    // GetFullPath will complete the path for the file named passed in as a string.
    string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");

    // using will make sure that the resource is cleaned from memory after it exists
    // conn initializes the connection to the .db file.
    using(SqliteConnection conn = new SqliteConnection(dataSource)) {

        conn.Open();

        // sql is the string that will be run as an sql command
        string sql = $"select * from Customers limit 20;";

        // command combines the connection and the command string and creates the query
        using(SqliteCommand command = new SqliteCommand(sql, conn)) {

            // reader allows you to read each value that comes back and do something to it.
            using(SqliteDataReader reader = command.ExecuteReader()) {

                // Read returns true while there are more rows to advance to. then false when done.
                while (reader.Read()) {

                    // map the data to the model.
                    Customer newCustomer = new Customer() {
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
                        SupportRepId= reader.GetString(12)
                    };

                    // add each one to the list.
                    Customers.Add(newCustomer);
                }
            }
        }
        conn.Close();
    }
    return Customers;
  }
}