namespace CookBook.Core.Models.Shared
{
    public class AllRecepieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DatePosted { get; set; }
        public string Image { get; set; }
        public string Owner { get; set; }
        public int TumbsUp { get; set; }
        public string Description { get; set; }

    }
}
