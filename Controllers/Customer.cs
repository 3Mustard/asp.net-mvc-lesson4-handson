using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Models;

namespace SqliteFromScratch.Controllers {
    // MVC is handling the routing for you.
    [Route("api/[Controller]")]
    public class CustomerController : Controller {

        // api/database
        [HttpGet]
        public List<Track> GetData() {
          // tracks will be populated with the result of the query.
          List<Track> tracks = new List<Track>();

          // GetFullPath will return a string to complete the absolute path.
          string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");

          // using will make sure that the resource is cleaned from memory after it exists
          // conn initializes the connection to the .db file.
          using(SqliteConnection conn = new SqliteConnection(dataSource)) {

            conn.Open();

            // sql is the string that will be run as an sql command
            string sql = $"select * from tracks limit 200;";
            // command combines the connection and the command string and creates the query
            using(SqliteCommand command = new SqliteCommand(sql, conn)) {

              // reader allows you to read each value that comes back and do something to it.
              using(SqliteDataReader reader = command.ExecuteReader()) {

                  // Read returns true while there are more rows to advance to. then false when done.
                  while (reader.Read()) {

                      // map the data to the model.
                      //Model newModel = new Model() {
                        //TrackId = reader.GetInt32(0),
                        //Name = reader.GetString(1),
                        //AlbumId = reader.GetInt32(2),
                        //MediaTypeId = reader.GetInt32(3),
                        //GenreId = reader.GetInt32(4),
                        //Composer = reader.GetValue(5).ToString(),
                        //Milliseconds = reader.GetInt32(6),
                        //Bytes = reader.GetInt32(7),
                        //UnitPrice = reader.GetInt32(8)
                    };

                      // add each one to the list.
                      tracks.Add(newTrack);
                 }
              }
            }
          conn.Close();
          }
          
          return tracks;
        }
    }
}