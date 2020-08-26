using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CinemaTickets.Services
{
    public static class CalenderElementManager
    {
        public static List<CalenderElement> GetAllCalenderElements()
        {
            SqlCommand vSQLcommand;
            SqlDataReader vSQLreader;
            List<CalenderElement> returnList = new List<CalenderElement>();

            try
            {
                using (SqlConnection objSQLconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["movies"].ConnectionString))
                {
                    objSQLconn.Open();
                    string query = "SELECT movies.Id as id_movie, movies.Price, Title, Description, Start, calelements.Id as id_calel";
                    query += " FROM calelements INNER JOIN movies";
                    query += " ON calelements.id_Movie = movies.Id;";
                    vSQLcommand = new SqlCommand(query, objSQLconn);
                    vSQLreader = vSQLcommand.ExecuteReader();
                    vSQLcommand.Dispose();

                    while (vSQLreader.Read())
                    {
                        Movie m = new Movie();
                        m.Id = (int)vSQLreader["id_movie"];
                        m.Title = (string)vSQLreader["Title"];
                        m.Description = (string)vSQLreader["Description"];
                        m.Price = (double)vSQLreader["Price"];

                        CalenderElement c = new CalenderElement();
                        c.Start = Convert.ToDateTime(vSQLreader["Start"].ToString());
                        c.Id = (int)vSQLreader["id_calel"];
                        c.Movie = m;
                        returnList.Add(c);
                    }
                    vSQLreader.Close();
                    return returnList;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Fehler beim Ausführen der Datenbankselektion. Bitte InnerException beachten für Fehlerdetails.", e);
            }
        }


        public static CalenderElement GetCalenderElementWithId(int Id)
        {
            SqlCommand vSQLcommand;
            SqlDataReader vSQLreader;
            CalenderElement returnElement = null;

            try
            {
                using (SqlConnection objSQLconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["movies"].ConnectionString))
                {
                    objSQLconn.Open();
                    string query = "SELECT movies.Id as id_movie, movies.Price, Title, Description, Start, calelements.Id as id_calel";
                    query += " FROM calelements INNER JOIN movies";
                    query += " ON calelements.Id_Movie = movies.Id";
                    query += " WHERE calelements.Id = @Id;";
                    vSQLcommand = new SqlCommand(query, objSQLconn);
                    vSQLcommand.Parameters.AddWithValue("@Id", Id);
                    vSQLreader = vSQLcommand.ExecuteReader();
                    vSQLcommand.Dispose();

                    if (vSQLreader.Read())
                    {
                        returnElement = new CalenderElement();

                        Movie m = new Movie();
                        m.Id = (int)vSQLreader["id_movie"];
                        m.Title = (string)vSQLreader["Title"];
                        m.Description = (string)vSQLreader["Description"];
                        m.Price = (double)vSQLreader["Price"];

                        returnElement.Id = (int)vSQLreader["id_calel"];
                        returnElement.Start = Convert.ToDateTime(vSQLreader["Start"].ToString());
                        returnElement.Movie = m;
                    }
                    vSQLreader.Close();
                    return returnElement;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Fehler beim Ausführen der Datenbankselektion. Bitte InnerException beachten für Fehlerdetails.", e);
            }
        }


    }
}