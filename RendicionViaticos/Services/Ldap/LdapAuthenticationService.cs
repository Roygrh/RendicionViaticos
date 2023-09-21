using Microsoft.Extensions.Options;
using System.DirectoryServices;

namespace RendicionViaticos.Services.Ldap
{
    public class LdapAuthenticationService : IAuthenticationService
    {
        private const string DisplayNameAttribute = "DisplayName";
        private const string SAMAccountNameAttribute = "SAMAccountName";
        private const string DNI = "DNI";
        private const string Email = "mail";
        private const string Department = "Department";
        private const string Flags = "flags";

        private readonly LdapConfig config;

        public LdapAuthenticationService(IOptions<LdapConfig> config)
        {
            this.config = config.Value;
        }
        public User Login(string userName, string password)
        {
            try
            {
                using (DirectoryEntry entry = new DirectoryEntry(config.Path, config.UserDomainName + "\\" + userName, password))
                {
                    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                    {
                        searcher.Filter = String.Format("({0}={1})", SAMAccountNameAttribute, userName);
                        searcher.PropertiesToLoad.Add(DisplayNameAttribute);
                        searcher.PropertiesToLoad.Add(Email);
                        searcher.PropertiesToLoad.Add(SAMAccountNameAttribute);
                        searcher.PropertiesToLoad.Add(DNI);
                        searcher.PropertiesToLoad.Add(Department);
                        searcher.PropertiesToLoad.Add(Flags);
                        var result = searcher.FindOne();
                        if (result != null)
                        {
                            var displayName = result.Properties[DisplayNameAttribute];
                            var samAccountName = result.Properties[SAMAccountNameAttribute];
                            var dni = result.Properties[DNI];
                            var email = result.Properties[Email];
                            var department = result.Properties[Department];
                            var flags = result.Properties[Flags];

                            return new User
                            {
                                IsAuthenticated = true,
                                DisplayName = displayName == null || displayName.Count <= 0 ? null : displayName[0].ToString(),
                                UserName = samAccountName == null || samAccountName.Count <= 0 ? null : samAccountName[0].ToString(),
                                DNI = dni == null || dni.Count <= 0 ? null : dni[0].ToString(),
                                Email = email == null || email.Count <= 0 ? null : email[0].ToString(),
                                Department = department == null || department.Count <= 0 ? null : department[0].ToString(),
                                Flags = flags == null || flags.Count <= 0 ? null : Int32.Parse(flags[0].ToString())
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new User { IsAuthenticated = false, DisplayName = ex.Message };
            }
            return null;
        }
    }
}
