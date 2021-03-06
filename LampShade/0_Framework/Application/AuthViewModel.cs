namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public long AccountId { get; set; }
        public long RoleId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }

        public AuthViewModel(long accountId, string fullName,string userName, long roleId)
        {
            AccountId = accountId;
            RoleId = roleId;
            FullName = fullName;
            UserName = userName;
        }
    }
}