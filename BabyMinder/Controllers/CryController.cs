using BabyMinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BabyMinder.Controllers
{
    public class CryController : Controller
    {
        CryViewModel ch = new CryViewModel();
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                int ParentID = 0;
                int BabyID = 0;
                List<CryViewModel> files = ch.dispaly_Cry(ParentID, BabyID);
                return View(files);
            }
            catch (Exception e)
            {
                return View(e);
            }
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CryViewModel c, HttpPostedFileBase PostedFile)
        {
            try
            {
                ch.insert_Cry(c, PostedFile);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                CryViewModel file = ch.Update_Cry(id);

                return View(file);
            }
            catch (Exception e)
            {
                return View(e);
            }


        }
        [HttpPost]
        public ActionResult Edit(CryViewModel c)
        {
            try
            {
                ch.Update_Cry(c);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                ch.delete_Cry(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }

        }
    }
}