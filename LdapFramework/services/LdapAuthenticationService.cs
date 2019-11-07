using LdapFramework.configuration;
using LdapFramework.entities;
using Novell.Directory.Ldap;
using System;

namespace LdapFramework.services
{
    public class LdapAuthenticationService : IAuthenticationService
    {
   
        private readonly LdapConnection connection;

        public LdapAuthenticationService(string host, int port, string dn, string dnPassword)
        {
            connection = new LdapConnection();
            connection.Connect(host, port);
            connection.Bind(dn, dnPassword);
        }
    

        public ApplicationUser Authenticate(string username, string pwd)
        {
            ApplicationUser user = null;
            try
            {
                string searchBase = "ou=people,o=sevenSeas";
                string searchUIDFilter = "(uid=" + username + ")";
                string[] requiredAttributes = { "cn", "sn", "uid", "userpassword" };
                LdapSearchResults searchResults = connection.Search(searchBase, LdapConnection.SCOPE_SUB, searchUIDFilter, requiredAttributes, false);

                while (searchResults.hasMore())
                {
                    LdapEntry nextEntry = null;
                    try
                    {
                        nextEntry = searchResults.next();
                    }
                    catch (LdapException e)
                    {
                        Console.WriteLine("Error : " + e.LdapErrorMessage);
                        continue;
                    }
                    LdapAttributeSet attributeSet = nextEntry.getAttributeSet();
                    System.Collections.IEnumerator enumerator = attributeSet.GetEnumerator();
                    user = new ApplicationUser();
                    while (enumerator.MoveNext())
                    {
                        LdapAttribute attribute = (LdapAttribute)enumerator.Current;
                        string attributeName = attribute.Name;
                        string attributeVal = attribute.StringValue;
                        if (attributeName.Equals("cn")) { user.cn = attributeVal; }
                        if (attributeName.Equals("sn")) { user.sn = attributeVal; }
                        if (attributeName.Equals("uid")) { user.uid = attributeVal; }
                        if (attributeName.Equals("userpassword")) { user.pwd = attributeVal; }
                    }
                }


            }
            catch (LdapException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }
            finally
            {
                connection.Disconnect();
            }
            return user;
        }
    }
}
