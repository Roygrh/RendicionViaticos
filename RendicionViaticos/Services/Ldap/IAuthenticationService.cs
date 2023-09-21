namespace RendicionViaticos.Services.Ldap
{
    public interface IAuthenticationService
    {
        User Login(string userName, string password);
    }
}
