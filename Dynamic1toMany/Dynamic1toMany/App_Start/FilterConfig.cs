﻿using System.Web;
using System.Web.Mvc;

namespace Dynamic1toMany
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
