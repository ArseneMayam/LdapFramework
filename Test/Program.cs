using LdapFramework.entities;
using LdapFramework.services;
using Novell.Directory.Ldap;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            LdapAuthenticationService service = new LdapAuthenticationService("localhost", 10389, "uid=admin,ou=system", "secret");            
            ApplicationUser user = service.Authenticate("cbuckley", "secret");
            Console.WriteLine("CN : "+user.cn);
            Console.WriteLine("SN : " + user.sn);
            Console.WriteLine("UID : " + user.uid);
            Console.WriteLine("PWD : " + user.pwd);

        }
  
    }
}
