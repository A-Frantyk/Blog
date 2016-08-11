using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_API.Authentification_Authorization
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            :base("BlogEntityContext")
        {

        }
    }
}