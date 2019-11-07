using System;
using System.Collections.Generic;
using System.Text;

namespace LdapFramework.entities
{
    public class ApplicationUser
    {
        public string cn { get; set; }
        public string sn { get; set; }
        public string uid { get; set; }
        public string pwd { get; set; }
        public ApplicationUser()
        {

        }
    }
}
