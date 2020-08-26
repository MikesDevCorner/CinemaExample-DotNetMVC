using CinemaTickets.Models;
using CinemaTickets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTickets.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            User user = new User();
            user.Id = 1;
            user.Username = "georg"; //TODO: User aus Session nehmen!!
            Cart cart = CartManager.GetCartElements(user);
            return View(cart);
        }

        [HttpPost]
        public ActionResult Delete()
        {
            User user = new User();
            user.Id = 1;
            user.Username = "georg"; //TODO: User aus Session nehmen!!

            try
            {   
                bool anz = CartManager.DeleteElementInCart(Int32.Parse(Request.Form["id"]), user);
                if(anz) ViewBag.Message = "Element wurde aus dem Einkaufswagen gelöscht.";
                else ViewBag.Message = "Fehler: Kein Element wurde aus dem Einkaufswagen gelöscht.";
            }
            catch (Exception e)
            {
                ViewBag.Message = "Fehler: " + e.Message;
            }
            Cart cart = CartManager.GetCartElements(user);
            return View("Index", cart);
        }
    }
}