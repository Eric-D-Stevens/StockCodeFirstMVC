using StockCodeFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockCodeFirstMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddUser()
        {
            ViewBag.Message = "Add User";

            using (var db = new StockContext())
            {
                var UsersList = db.Users.ToList();
                return View(UsersList);
            }
        }

        public ActionResult AddUserButton(string userName)
        {
            using (var ctx = new StockContext())
            {
                var usr = new User { Name = userName };
                ctx.Users.Add(usr);
                ctx.SaveChanges();
            }
            return RedirectToAction("AddUser");
        }




        public ActionResult AddOrder()
        {
            using (var db = new StockContext())
            {
                var UsersList = db.Users.ToList();
                return View(UsersList);
            }
        }

        public ActionResult AddOrderButton(string userId, string symbol, string quantity, string pricePaid)
        {
            using (var ctx = new StockContext())
            {
                int theUserId = int.Parse(userId);

                var userQuery = from b in ctx.Users
                           where b.UserId.Equals(theUserId)
                           select b;

                var usr = userQuery.ToList()[0];

                var ordr = new Order
                {
                    UserId = usr.UserId,
                    UserName = usr.Name,
                    Symbol = symbol,
                    Quantity = int.Parse(quantity),
                    PricePaid = double.Parse(pricePaid),
                    DateAndTime = DateTime.Now
                };

                ctx.Orders.Add(ordr);
                ctx.SaveChanges();
            }

            return RedirectToAction("AddOrder");
        }

    }
}