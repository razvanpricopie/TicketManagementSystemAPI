using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Identity.Models;

namespace TicketManagementSystemAPI.Identity
{
    public class TicketManagementSystemIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public TicketManagementSystemIdentityDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
