using System.ComponentModel.DataAnnotations;

namespace CookBook.Core.Contracts
{
    public interface IRecepie
    {
        public int Id { get; set; }
        [Display(Name = "Recepie Name")]
        public string Name { get; set; }

        [Display(Name = "Date posted")]
        public DateTime DatePosted { get; set; }

        [Display(Name = "Image URL")]
        public string Image { get; set; }

        [Display(Name = "Owner")]
        public string Owner { get; set; }

        [Display(Name = "Tumbs Up")]
        public int TumbsUp { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Private")]
        public bool Private { get; set; }
    }
}
