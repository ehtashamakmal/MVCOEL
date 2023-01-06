using MVCOEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOEL.Controllers
{
    public class LoginController : Controller
    {

        barterDataEntities db = new barterDataEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Signup()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Signup(user u)
        {

            if (ModelState.IsValid == true)
            {
                db.users.Add(u);
              int a =   db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Succesfully  !!')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Not Registered !!')</script>";
                }
            }

            
            return View();
        }
        [HttpPost]
        public ActionResult Index(user u)
        {
            var user = db.users.Where(model => model.username == u.username && model.password == u.password);
                  if(user!= null)
                {
                    Session["UserId"] = u.Id.ToString();
                    Session["Username"] = u.username.ToString();
                    TempData["LoginSuccessMessage"] = "<script>alert('Login SuccessFully !!')</script>";
                    return RedirectToAction("Index", "Card");
                }

                else
                {
                         ViewBag.ErrorMessage = " < script > alert('UserName or password  incorrect>";
                    return View();
                }
          
          
        
            }
          
        }
    }
