using System.ComponentModel.DataAnnotations;

namespace Identity.Core.Entities
{
    public class Claim : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
