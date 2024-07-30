using HamroMaat.Models.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HamroMaat.Models.Reprository
{
    private EcommerceEntities db = new EcommerceEntities();
    public class CatagoryRepository : ICatagory
    {
        private readonly object db;

        public void EditCatagory(Catagory cat)
        {
            throw new NotImplementedException();
        }

        public Catagory GetCatagory(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertCatagory(Catagory cat)
        {
            throw new NotImplementedException();
        }

        public List<Catagory> ViewCatagory()
        {
            List<Catagory>li = new List<Catagory>();
            List<bl_catagory> cat= db.bl_catagory.ToList();
            foreach(var item in cat)
            {
                Catagory c =new Catagory();
                c.cat_id = item.cat_id;
                c.cat_name= item.cat_name;
                c.cat_icon= item.cat_icon;
                c.cat_create_done = item.cat_create_done;
                c.cat_fk_Ad_id = item.cat_fk_Ad_id;
                
                li.Add(c);
            }
            return li;
        }
    }
}