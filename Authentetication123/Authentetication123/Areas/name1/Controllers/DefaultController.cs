using Authentetication123.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authentetication123.Areas.name1.Controllers
{
    [Authorize(Roles = " EmployeeName")]
    public class DefaultController : Controller
    {
        // GET: name1/Default
        public ActionResult Index()
        {
            // Retrieve the JSON string from the session
            var userSessionJson = Session["UserSession"] as string;



            // Deserialize the JSON string into a SessionInformation object
            var userSession = JsonConvert.DeserializeObject<SessionInformation>(userSessionJson);

            // Pass the data to the view or use it as needed
            return View(userSession);
        }
    }
}