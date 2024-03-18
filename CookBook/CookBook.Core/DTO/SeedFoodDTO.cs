namespace CookBook.Core.DTO
    {
    public class SeedFoodDTO
        {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Descripton { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }
        public string Image { get; set; } = string.Empty;
        public int PrepTime { get; set; }
        public string? Origen { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public int TumbsUp { get; set; }
        public int CookTime { get; set; }
        public int Portions { get; set; }
        public int RecepieTypeId { get; set; }
        public int Temperature { get; set; }
        public int TemperatureMeasurmentId { get; set; }
        public int OvenTypeId { get; set; }

        public bool IsPrivate { get; set; }

        public TempStepModel[] Steps { get; set; }
        public TempIngrediantModel[] IngredientsRecepies { get; set; }

        }

    }
