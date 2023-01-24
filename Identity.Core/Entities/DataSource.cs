namespace Identity.Core.Entities
{
    public class DataSource : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<Role> Roles { get; set; }
    }
}
