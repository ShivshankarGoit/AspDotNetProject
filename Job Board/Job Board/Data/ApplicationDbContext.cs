using Job_Board.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Job_Board.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {


    }
}
