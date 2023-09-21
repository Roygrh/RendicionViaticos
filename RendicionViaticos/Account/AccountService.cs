using AutoMapper;
using RendicionViaticos.Services.Ldap;
using RendicionViaticos.Services.Unit;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace RendicionViaticos.Account
{
    public class AccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const string DisplayNameAttribute = "DisplayName";
        private const string SAMAccountNameAttribute = "SAMAccountName";
        private const string DNI = "DNI";
        private const string Email = "mail";
        private const string Department = "Department";
        private const string Flags = "flags";
        public AccountService(IMapper mapper)
        {
            this._mapper = mapper;
        }
        public bool IsSignedIn()
        {
            return true;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (var context = new PrincipalContext(ContextType.Domain, "imarpe.gob.pe"))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    foreach (var result in searcher.FindAll())
                    {
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        Console.WriteLine("First Name: " + de.Properties["givenName"].Value);
                        Console.WriteLine("Last Name : " + de.Properties["sn"].Value);
                        Console.WriteLine("SAM account name   : " + de.Properties["samAccountName"].Value);
                        Console.WriteLine("User principal name: " + de.Properties["userPrincipalName"].Value);
                        Console.WriteLine();

                        var displayName = de.Properties[DisplayNameAttribute];
                        var samAccountName = de.Properties[SAMAccountNameAttribute];
                        var dni = de.Properties[DNI];
                        var email = de.Properties[Email];
                        var department = de.Properties[Department];
                        var flags = de.Properties[Flags];

                        var user = new User
                        {
                            IsAuthenticated = true,
                            DisplayName = displayName == null || displayName.Count <= 0 ? null : displayName[0].ToString(),
                            UserName = samAccountName == null || samAccountName.Count <= 0 ? null : samAccountName[0].ToString(),
                            DNI = dni == null || dni.Count <= 0 ? null : dni[0].ToString(),
                            Email = email == null || email.Count <= 0 ? null : email[0].ToString(),
                            Department = department == null || department.Count <= 0 ? null : department[0].ToString(),
                            Flags = flags == null || flags.Count <= 0 ? null : Int32.Parse(flags[0].ToString())
                        };

                        users.Add(user);
                    }
                }
            }

            return users;


        }
    }
}
