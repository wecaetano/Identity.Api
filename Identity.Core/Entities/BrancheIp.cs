namespace Identity.Core.Entities
{
    public class BrancheIp
    {
        public string Range { get; set; }
        public int BranchId { get; set; }
        public virtual Branche Branch { get; set; }
    }
}
