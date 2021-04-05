using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Models
{
    public class Category
    {
        public Category()
        {
            Tasks = new Collection<Task>();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
