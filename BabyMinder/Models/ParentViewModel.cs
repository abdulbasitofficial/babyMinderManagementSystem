using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BabyMinder.Models
{
    public class ParentViewModel
    {
        BabyMinderEntities db = new BabyMinderEntities();

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public void insert_Parent(ParentViewModel c)
        {
            Parent ch = new Parent();
            ch.Name = c.Name;
            ch.Password = c.Password;
            ch.Email = c.Email;
            db.Parents.Add(ch);
            db.SaveChanges();

        }
        public List<ParentViewModel> dispaly_Parent()
        {
            List<ParentViewModel> files = new List<ParentViewModel>();

            var query = db.Parents.ToList();
            foreach (var p in query)
            {
                files.Add(new ParentViewModel()
                {
                    ID = p.ID,
                    Name = p.Name,
                    Email = p.Email,
                    Password = p.Password
                });
            }

            return files;

        }
        public ParentViewModel Update_Parent(int id)
        {
            var query = db.Parents.Where(e => e.ID == id).FirstOrDefault();
            ParentViewModel files = new ParentViewModel();
            files.ID = query.ID;
            files.Name = query.Name;
            return files;
        }
        public void Update_Parent(ParentViewModel c)
        {
            var result = db.Parents.SingleOrDefault(b => b.ID == c.ID);
            if (result != null)
            {
                result.Name = c.Name;
                result.Email = c.Email;
                result.Password = c.Password;
                db.SaveChanges();
            }

        }

        public void delete_Parent(int id)
        {
            var u = db.Parents.Where(c => c.ID == id).FirstOrDefault();
            db.Entry(u).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
    }
}