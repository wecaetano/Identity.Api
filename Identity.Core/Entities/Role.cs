using Microsoft.AspNetCore.Identity;

namespace Identity.Core.Entities
{
    public class Role : IdentityRole
    {
        public int DataSourceId { get; set; }
        public virtual DataSource DataSource { get; set; }
        //public virtual ICollection<RoleClaims> RoleClaims { get; set; }

        //public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
