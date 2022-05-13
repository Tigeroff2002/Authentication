using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.DAO;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        RecordsDAO recordsDAO = new RecordsDAO();

        //[Authorize(Roles = "Role1, Role2, Role3 ...")]
        public ActionResult Index()
        {
            return View(recordsDAO.GetAllRecords());
        }

        [Authorize (Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize (Roles = "Admin, Server, Visitor")]
        public ActionResult Details()
        {
            return View();
        }

        [Authorize(Users = "parahinkv@gmail.com, parahinkirill@gmail.com")]
        public ActionResult Edit()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "ID")] Records
       records)
        {
            try
            {
                if (recordsDAO.AddRecord(records))
                    return RedirectToAction("Index");
                else
                    return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Details([Bind(Exclude = "ID")] Records
   records)
        {
            try
            {
                if (recordsDAO.AddRecord(records))
                    return RedirectToAction("Index");
                else
                    return View("Details");
            }
            catch
            {
                return View("Details");
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit([Bind(Exclude = "ID")] Records
records)
        {
            try
            {
                if (recordsDAO.AddRecord(records))
                    return RedirectToAction("Index");
                else
                    return View("Edit");
            }
            catch
            {
                return View("Edit");
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([Bind(Exclude = "ID")] Records records)
        {
            try
            {
                if (recordsDAO.AddRecord(records))
                    return RedirectToAction("Index");
                else
                    return View("Delete");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}

