using Microsoft.Extensions.Configuration;
namespace LdapFramework.configuration
{
    public class LdapConfig
    {
        private readonly IConfiguration config;

        public string Url { get; set; }
        public string BindDn { get; set; }
        public string BindCredentials { get; set; }
        public string SearchBase { get; set; }
        public string SearchFilter { get; set; }
        public string AdminCn { get; set; }

        public LdapConfig(IConfiguration config)
        {
            this.config = config;
            Url = config["ldap.url"];
            BindDn = config["ldap.bindDn"];
            BindCredentials = config["ldap.bindCredentials"];
            SearchBase = config["ldap.searchBase"];
            SearchFilter = config["ldap.searchFilter"];
            AdminCn = config["ldap.adminCn"];
        }
    }
}
