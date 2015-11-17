using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TIGE.Models;

namespace TIGE.DAL
{
    public class TIGEContext : IdentityDbContext<ApplicationUser>
    {
        public TIGEContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TIGEContext Create()
        {
            return new TIGEContext();
        }
    }
}