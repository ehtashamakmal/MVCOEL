using MVCOEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOEL.Controllers
{
    public class CardController : Controller
    {

        barterDataEntities db = new barterDataEntities();
        // GET: Card
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Card(UserCard u)
        {

            if (ModelState.IsValid == true)
            {
                db.UserCards.Add(u);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Succesfully  !!')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Not Registered !!')</script>";
                }
                return RedirectToAction("Index", "Login");
            }



            
            else 
            {
                return View();
            }

            }

       
        }

        }

    
