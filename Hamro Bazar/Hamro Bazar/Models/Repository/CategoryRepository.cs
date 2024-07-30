using Hamro_Bazar.Models.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hamro_Bazar.Models.Repository
{
    private EcommerceEntities db = new EcommerceEntities();
    public class CategoryRepository : ICatagory
    {
        private object db;

        public void EditCategory(Catagorey cat)
        {
            throw new NotImplementedException();
        }

        public Catagorey GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertCategory(Catagorey cat)
        {
            throw new NotImplementedException();
        }

        public List<Catagorey> ViewCategory()
        {
            List<Catagorey>li= new List<Catagorey>();
            List<bl_catagory> cat = db.bl_ca>tagory.ToList();
            return db.bl_catagory.ToList().OrderByDescending(x=>x.cat_id).ToList();
        }
    }
}