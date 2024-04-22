using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookRentalFinal.Data
{
    abstract class ObservableEntity : ObservableObject
    {
        [Key, StringLength(32, MinimumLength = 1)]
        public string? ID { get; set; }
        public void GenID()
        {
            ID = Guid.NewGuid().ToString("N");
        }
    }
}
