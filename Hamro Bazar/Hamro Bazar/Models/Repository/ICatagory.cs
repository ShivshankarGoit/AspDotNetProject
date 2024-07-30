using Hamro_Bazar.Models.View_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamro_Bazar.Models.Repository
{
    internal interface ICatagory
    {
        void InsertCategory(Catagorey cat);
        void EditCategory(Catagorey cat);
        List<Catagorey> ViewCategory();
        Catagorey GetCategory(int id);
    }
}
