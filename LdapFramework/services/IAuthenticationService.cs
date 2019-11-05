using LdapFramework.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LdapFramework.services
{
    public interface IAuthenticationService
    {
         ApplicationUser Login(string username, string password);
    }
}
