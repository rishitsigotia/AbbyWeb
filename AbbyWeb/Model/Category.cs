using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="No. of Order")]
        [Range(1,100,ErrorMessage ="The range should be 1 to 100 !! Not more than that")]
        public int DisplayOrder { get; set; }
    }
}
