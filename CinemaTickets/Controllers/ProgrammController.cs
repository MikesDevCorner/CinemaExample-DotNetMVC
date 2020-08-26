using CinemaTickets.Models;
using CinemaTickets.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CinemaTickets.Controllers
{
    public class ProgrammController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<CalenderElement> elements = CalenderElementManager.GetAllCalenderElements();
            return View(elements);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {
            try
            {
                User user = new User();
                user.Id = 1;
                user.Username = "georg"; //TODO: User aus Session nehmen!!
                CalenderElement calElement = CalenderElementManager.GetCalenderElementWithId(Int32.Parse(Request.Form["id"]));
                CartManager.AddElementToCart(calElement, user);
                ViewBag.Message = "Film " + calElement.Movie.Title + " mit Startzeit " + calElement.Start + " wurde zu Ihrem Einkaufswagen hinzugefügt.";
            }
            catch (Exception e)
            {
                ViewBag.Message = "Fehler: " + e.Message;
            }
            List<CalenderElement> elements = CalenderElementManager.GetAllCalenderElements();
            return View(elements);
        }
    }
}