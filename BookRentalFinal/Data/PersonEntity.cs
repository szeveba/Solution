using System.ComponentModel.DataAnnotations;

namespace BookRentalFinal.Data
{
    abstract class PersonEntity : ObservableEntity
    {
        [Required, StringLength(100, MinimumLength = 1)]
        public string? FirstName { get; set; }
        [Required, StringLength(100, MinimumLength = 1)]
        public string? LastName { get; set; }
    }
}
