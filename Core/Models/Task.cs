namespace Core.Models
{
    public class Task
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
