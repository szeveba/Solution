using System.ComponentModel.DataAnnotations;

namespace Library.DBExample
{
    public abstract class Entity
    {
        [Key]
        [StringLength(32)]
        public string? ID { get; set; }
    }
}
