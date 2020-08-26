using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CinemaTickets.Services
{
    public static class CartManager
    {

        public static bool AddElementToCart(CalenderElement calEl, User user)
        {
            SqlCommand vSQLcommand;

            try
            {
                using (SqlConnection objSQLconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["movies"].ConnectionString))
                {
                    int anz = 0;
                    objSQLconn.Open();
                    vSQLcommand = new SqlCommand("INSERT INTO cart (Id_CalElement, Id_User) VALUES (@idElement, @idUser); ", objSQLconn);
                    vSQLcommand.Parameters.AddWithValue("@idElement", calEl.Id);
                    vSQLcommand.Parameters.AddWithValue("@idUser", user.Id);
                    anz = vSQLcommand.ExecuteNonQuery();
                    vSQLcommand.Dispose();
                    return anz > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Fehler beim Hinzufügen des Elementes zum Einkaufswagen. Bitte InnerException beachten für Fehlerdetails.",e);
            }
        }

        public static bool DeleteElementInCart(int ElementId, User user)
        {
            SqlCommand vSQLcommand;

            try
            {
                using (SqlConnection objSQLconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["movies"].ConnectionString))
                {
                    int anz = 0;
                    objSQLconn.Open();
                    vSQLcommand = new SqlCommand("DELETE FROM cart WHERE Id_CalElement = @idElement AND Id_User = @idUser;", objSQLconn);
                    vSQLcommand.Parameters.AddWithValue("@idElement", ElementId);
                    vSQLcommand.Parameters.AddWithValue("@idUser", user.Id);
                    anz = vSQLcommand.ExecuteNonQuery();
                    vSQLcommand.Dispose();
                    return anz > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Fehler beim Hinzufügen des Elementes zum Einkaufswagen. Bitte InnerException beachten für Fehlerdetails.", e);
            }
        }


        public static Cart GetCartElements(User user)
        {
            SqlCommand vSQLcommand;
            SqlDataReader vSQLreader;
            Cart actualCart = new Cart();
            actualCart.User = user;
            try
            {
                using (SqlConnection objSQLconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["movies"].ConnectionString))
                {
                    objSQLconn.Open();
                    string query = "SELECT movies.Id as id_movie, movies.Price, Title, Description, Start, calelements.Id as id_calel";
                    query += " FROM cart";
                    query += " INNER JOIN calelements";
                    query += " ON cart.Id_CalElement = calelements.Id";
                    query += " INNER JOIN movies";
                    query += " ON calelements.id_Movie = movies.Id";
                    query += " WHERE cart.Id_User = @userId";
                    vSQLcommand = new SqlCommand(query, objSQLconn);
                    vSQLcommand.Parameters.AddWithValue("@userId", user.Id);
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
                        actualCart.Add(c);
                    }
                    vSQLreader.Close();
                    return actualCart;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Fehler beim Ausführen der Datenbankselektion. Bitte InnerException beachten für Fehlerdetails.", e);
            }
        }

    }
}