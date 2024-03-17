namespace CookBook.Core.Services
    {
    public class RecepieServiceModel
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Owner { get; set; }
        public int TumbsUp { get; set; }
        public DateTime DatePosted { get; set; }
        public bool Private { get; set; } =false;
        }
    }
