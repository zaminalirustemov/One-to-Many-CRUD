using System.ComponentModel.DataAnnotations;

namespace Pustok_book_sales_app.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [StringLength(maximumLength:20)]
        public string TitleUp { get; set; }
        [StringLength(maximumLength: 20)]
        public string TitleDown { get; set; }
        [StringLength(maximumLength: 300)]
        public string Description { get; set; }
        public double Price { get; set; }

    }
}
