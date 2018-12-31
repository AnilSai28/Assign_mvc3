using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_model_dal.Models;
using mvc_model_dal.filters;

namespace mvc_model_dal.Controllers
{
    [customauth]
    public class studentController : Controller
    {
       public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(loginviewmodel model)
        {
            if (ModelState.IsValid)
            {
                studentdal dal = new studentdal();
                bool status = dal.login(model);
                if (status == true)
                {
                    Session["loginid"] = model.loginid;
                    return RedirectToAction("index", "student");

                }
                else
                {
                    ViewBag.msg = "invalid user id or password";
                    ModelState.Clear();
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult index()
        {
            try
            {
                int loginid = Convert.ToInt32(Session["loginid1"]);
                int x = 10;

                x = x / loginid;
                ViewBag.loginid = loginid;
                return View();
            }
            catch(Exception exp)
            {
                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "MVC app";
                log.WriteEntry("MVC error : " + exp.Message);
                return View();
            }
        
            }
        public ActionResult newstudent()
        {
            studentdal dal = new studentdal();
            ViewBag.cities = dal.Getcities();
            return View();
        }
        [HttpPost]
        public ActionResult newstudent(studentmodel model)
        {
            if(ModelState.IsValid)
            {
                model.studentimageaddress = "/images/" + Guid.NewGuid() + ".jpg";
                model.studentimagefile.SaveAs(Server.MapPath(model.studentimageaddress));

                studentdal dal = new studentdal();
                int id = dal.Addstudent(model);
                ViewBag.msg = "student added: " + id;
                ModelState.Clear();
                ViewBag.cities = dal.Getcities();
                return View();

            }
            else
            {
                studentdal dal = new studentdal();
                ViewBag.cities = dal.Getcities();
                return View();
            }
        }

        public ActionResult Search()
        {
            List<studentprojection> list = new List<studentprojection>();
            return View(list);
        }

        [HttpPost]
        public ActionResult Search(string key)
        {
            studentdal dal = new studentdal();
            List<studentprojection> list = dal.Search(key);
            return View(list);
        }

        public ActionResult find(int id)
        {
            studentdal dal = new studentdal();
            studentmodel model = dal.Find(id);
            return View(model);
        }
        public ActionResult delete(int id)
        {
            studentdal dal = new studentdal();
            bool status = dal.delete(id);
            return View();
        }
        public ActionResult edit(int id)
        {
            studentdal dal = new studentdal();
            studentmodel model = dal.Find(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit(studentmodel model)
        {
            studentdal dal = new studentdal();
            dal.update(model.studentid, model.studentpassword, model.studentmobile);
            return View("view_update");
        }

        [ChildActionOnly]
        public ActionResult getprofiledetails()
        {
            int loginid = Convert.ToInt32(Session["loginid"]);
            studentdal dal = new studentdal();
            studentmodel model = dal.Find(loginid);

            ViewBag.id = model.studentid;
            ViewBag.name = model.studentname;
            ViewBag.imageaddress = model.studentimageaddress;
            return PartialView("myprofilepartialview");
        }
    }
}