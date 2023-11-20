using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DBExample
{
    public class Context : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
    }
    public abstract class Entity
    {
        [Key]
        [StringLength(32)]
        public string? ID { get; set; }
    }

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

    public class Class : Entity
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public virtual Teacher HeadMaster { get; set; }
        public virtual ICollection<Student> Students { get; private set; }
    }



    public class Teacher : PersonEntity
    {
        public virtual Class? Class { get; set; }
    }

    public class Student : PersonEntity
    {
        public virtual Class? Class { get; set; }
    }
}
