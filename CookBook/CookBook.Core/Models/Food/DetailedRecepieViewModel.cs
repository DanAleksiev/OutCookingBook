using CookBook.Constants;
using CookBook.Core.Models.Utilities;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Core.Models.Food
    {
    public class DetailedRecepieViewModel
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RecepieType { get; set; }
        public string Image { get; set; }
        public int PrepTime { get; set; }
        public int Temperature { get; set; }
        public string TemperatureType { get; set; }
        public int CookTime { get; set; }
        public string OvenType { get; set; }
        public string Measurment { get; set; }
        public bool IsPrivate { get; set; }
        public string Origen { get; set; }
        public int Portions { get; set; }
        }
    }
