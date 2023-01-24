namespace Identity.Core.Entities
{
    public class Branche : BaseEntity
    {
        public int DataSourceId { get; set; }
        public virtual DataSource? DataSource { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual ICollection<BrancheIp> BranchIps { get; set; }
        public virtual ICollection<UserCompanyAccess> UserCompanyAccesses { get; set; }
    }
}
