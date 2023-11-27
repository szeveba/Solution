using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DBExample
{
    public abstract class PersonEntity : Entity
    {
        [NotMapped]
        public string? FullName { get => $"{FirstName} {LastName}"; }

        /// <summary>
        /// Keresztnév
        /// </summary>
        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }
        /// <summary>
        /// Vezetéknév
        /// </summary>
        [Required, StringLength(100)]
        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }
        public int? Age { get => BirthDate.HasValue ? new DateTime(DateTime.Now.Ticks - BirthDate.Value.Ticks).Year - 1 : null; }
    }
}
