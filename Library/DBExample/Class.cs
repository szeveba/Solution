using System.ComponentModel.DataAnnotations;

namespace Library.DBExample
{

    public class Class : Entity
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public virtual ICollection<Student> Students { get; private set; }
    }
}
