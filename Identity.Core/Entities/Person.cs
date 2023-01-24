namespace Identity.Core.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string DocumentId { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
