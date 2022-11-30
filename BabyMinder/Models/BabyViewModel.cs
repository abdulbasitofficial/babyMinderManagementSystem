using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabyMinder.Models
{
    public class BabyViewModel
    {
        BabyMinderEntities db = new BabyMinderEntities();

        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public DateTime DOB { get; set; }

        public void insert_Baby(BabyViewModel c)
        {
            Baby ch = new Baby();
            ch.ParentID = c.ParentID;
            ch.Name = c.Name;
            ch.Contact = c.Contact;
            ch.DOB = c.DOB;
            db.Babies.Add(ch);
            db.SaveChanges();

        }
        public List<BabyViewModel> dispaly_Baby(int ParentID)
        {
            List<BabyViewModel> files = new List<BabyViewModel>();

            var query = db.Babies.Where(w=>w.ParentID == ParentID).ToList();
            foreach (var p in query)
            {
                files.Add(new BabyViewModel()
                {
                    ID = p.ID,
                    Name = p.Name,
                    Contact = p.Contact,
                    DOB = (DateTime)p.DOB
                });
            }

            return files;

        }
        public BabyViewModel Update_Baby(int id)
        {
            var query = db.Babies.Where(e => e.ID == id).FirstOrDefault();
            BabyViewModel files = new BabyViewModel();
            files.ID = query.ID;
            files.Name = query.Name;
            files.Contact = query.Contact;
            files.DOB = (DateTime)query.DOB;
            return files;
        }
        public void Update_Baby(BabyViewModel c)
        {
            var result = db.Babies.SingleOrDefault(b => b.ID == c.ID);
            if (result != null)
            {
                result.Name = c.Name;
                result.Contact = c.Contact;
                result.DOB = c.DOB;
                db.SaveChanges();
            }

        }

        public void delete_Baby(int id)
        {
            var u = db.Babies.Where(c => c.ID == id).FirstOrDefault();
            db.Entry(u).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
    }
}