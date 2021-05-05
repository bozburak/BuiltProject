namespace Core.Models
{
    public class Task
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
