using Microsoft.AspNetCore.Identity;

namespace ETJSestateAgency.Areas.Data
{
    public class AppUser : IdentityUser

    {
        public String FirstName {  get; set; }
        public String LastName { get; set; }

    }
}
