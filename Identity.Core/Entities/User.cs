using Microsoft.AspNetCore.Identity;

namespace Identity.Core.Entities
{
    public class User : IdentityUser
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int DataSourceId { get; set; }
        public virtual DataSource DataSource { get; set; }
        public virtual ICollection<UserCompanyAccess> UserCompanyAccesses { get; set; }

        //public virtual ICollection<UserRole> UserRoles { get; set; }
        //public virtual ICollection<UserClaim> UserClaims { get; set; }
    }
}
