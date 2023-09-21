namespace RendicionViaticos.Services.Ldap
{
    public class User
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public decimal UserType { get; set; }
        public string UserTypeName { get; set; }
        public string Department { get; set; }
        public Nullable<int> Flags { get; set; }
        public string ImmediateBoss { get; set; }
        public string WorkerType { get; set; }
    }
}
