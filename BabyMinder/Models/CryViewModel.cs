using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BabyMinder.Models
{
    public class CryViewModel
    {
        BabyMinderEntities db = new BabyMinderEntities();
        public int ID { get; set; }
        public int ParentID { get; set; }
        public int BabyID { get; set; }
        public byte[] Audio { get; set; }
        public string Type { get; set; }
        public void insert_Cry(CryViewModel c, HttpPostedFileBase PostedFile)
        {
            byte[] bytes;
            BinaryReader br = new BinaryReader(PostedFile.InputStream);
            bytes = br.ReadBytes(PostedFile.ContentLength);

            Cry hr = new Cry();
            hr.ParentID = c.ParentID;
            hr.BabyID = c.BabyID;
            hr.Audio = bytes;
            hr.Type = PostedFile.ContentType;
            db.Cries.Add(hr);
            db.SaveChanges();
        }
        public List<CryViewModel> dispaly_Cry(int ParentID, int BabyID)
        {
            List<CryViewModel> files = new List<CryViewModel>();

            var query = db.Cries.Where(w=>w.BabyID==BabyID && w.ParentID==ParentID).ToList();
            foreach (var p in query)
            {
                files.Add(new CryViewModel()
                {
                    ID = p.ID,
                    Audio = (byte[])p.Audio,
                    Type = p.Type
                });
            }

            return files;
        }
        public CryViewModel Update_Cry(int id)
        {
            //Create object of model type to get Varible and save data and pass on View
            CryViewModel h = new CryViewModel();
            var query = db.Cries.Where(e => e.ID == id).FirstOrDefault();
            h.ID = query.ID;
            h.Audio = (byte[])query.Audio;
            h.Type = query.Type;
            return h;
        }
        public void Update_Cry(CryViewModel hr)
        {
            //Create object of model type to get Varible and save data and pass on View
            Cry h = new Cry();
            var result = db.Cries.SingleOrDefault(b => b.ID == hr.ID);
            if (result != null)
            {
                result.ID = hr.ID;
                result.Audio = (byte[])hr.Audio;
                result.Type = hr.Type;
                db.SaveChanges();
            }

        }
        public void delete_Cry(int id)
        {
            var u = db.Cries.Where(c => c.ID == id).FirstOrDefault();
            db.Entry(u).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

    }
}