using Microsoft.AspNetCore.Identity;

namespace Identity.Core.Entities
{
    public class UserRole : IdentityUserRole<string>
    {
        //public virtual User User { get; set; }
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }
        //public virtual Role Role { get; set; }
        public bool IsDefault { get; set; }
    }
}
