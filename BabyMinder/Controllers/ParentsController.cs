using BabyMinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BabyMinder.Controllers
{
    public class ParentsController : Controller
    {
        ParentViewModel ch = new ParentViewModel();
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<ParentViewModel> files = ch.dispaly_Parent();
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
        public ActionResult Add(ParentViewModel c)
        {
            try
            {
                ch.insert_Parent(c);
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
                ParentViewModel file = ch.Update_Parent(id);

                return View(file);
            }
            catch (Exception e)
            {
                return View(e);
            }


        }
        [HttpPost]
        public ActionResult Edit(ParentViewModel c)
        {
            try
            {
                ch.Update_Parent(c);
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
                ch.delete_Parent(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }

        }
    }
}