namespace MultiTierProject.Core.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Region Region { get; set; }
    }
}
