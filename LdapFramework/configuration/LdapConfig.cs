using Microsoft.Extensions.Configuration;

namespace LdapFramework.configuration
{
    public class LdapConfig
    {

        public string Url { get; set; } = "localhost";
        public string BindDn { get; set; } = "uid=admin,ou=system";
        public string BindCredentials { get; set; } = "secret";
        public string SearchBase { get; set; } = "DC=contoso,DC=local";
        public string SearchFilter { get; set; } = "(&(objectClass=user)(objectClass=person)(sAMAccountName={0}))";
        public string AdminCn { get; set; } = "CN=Admins,OU=branch,DC=contoso,DC=local";

    }
}
