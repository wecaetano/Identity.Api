namespace Identity.Core.Entities
{
    public class Application : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}
