using System.Web.Mvc;

namespace AreaApplication.Areas.ExceltoDatabase
{
    public class ExceltoDatabaseAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ExceltoDatabase";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ExceltoDatabase_default",
                "ExceltoDatabase/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}