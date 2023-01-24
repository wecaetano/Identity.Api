namespace Identity.Core.Entities
{
    public class UserCompanyAccess
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int BranchId { get; set; }
        public virtual Branche Branch { get; set; }
    }
}
