using System.ComponentModel.DataAnnotations;

namespace SampleLoginApp.Data
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string ProductName { get; set; }

        [Required, MaxLength(200)]
        public string ProductDescription { get; set; }

    }

}
