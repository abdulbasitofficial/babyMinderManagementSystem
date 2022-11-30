using BabyMinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BabyMinder.Controllers
{
    public class BabyController : Controller
    {
        BabyViewModel ch = new BabyViewModel();
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                int ParentID = 0;
                List<BabyViewModel> files = ch.dispaly_Baby(ParentID);
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
        public ActionResult Add(BabyViewModel c)
        {
            try
            {
                ch.insert_Baby(c);
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
                BabyViewModel file = ch.Update_Baby(id);

                return View(file);
            }
            catch (Exception e)
            {
                return View(e);
            }


        }
        [HttpPost]
        public ActionResult Edit(BabyViewModel c)
        {
            try
            {
                ch.Update_Baby(c);
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
                ch.delete_Baby(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }

        }
    }
}