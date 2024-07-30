using System.Web.Mvc;

namespace AreaApplication.Areas.DatabaseToExcell
{
    public class DatabaseToExcellAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DatabaseToExcell";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DatabaseToExcell_default",
                "DatabaseToExcell/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}