using HamroMaat.Models.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamroMaat.Models.Reprository
{
    internal interface ICatagory
    {
        void InsertCatagory(Catagory cat);
        void EditCatagory(Catagory cat);
        List<Catagory> ViewCatagory();
        Catagory GetCatagory(int id);
    }
}
