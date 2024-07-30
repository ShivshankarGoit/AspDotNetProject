using System.Web.Mvc;

namespace Authentetication123.Areas.name1
{
    public class name1AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "name1";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "name1_default",
                "name1/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}