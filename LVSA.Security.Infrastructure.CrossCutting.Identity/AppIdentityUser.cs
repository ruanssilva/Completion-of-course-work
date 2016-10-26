﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Security.Infrastructure.CrossCutting.Identity
{
    public class AppIdentityUser : IdentityUser
    {
        public long? UsuarioId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppIdentityUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
