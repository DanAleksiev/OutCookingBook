namespace CookBook.Constants
    {
    public class LenghtParams
        {
        //Recepie
        public const int RecepieNameMinLengt = 2;
        public const int RecepieNameMaxLengt = 50;
        public const int DescriptionMinLengt = 3;
        public const int DescriptionMaxLengt = 50;
        public const int ImageMaxLengt = 1000;
        public const int OrigenMaxLenght = 250;

        public const int CookTimeMinRange = 0;
        public const int CookTimeMaxRange = 1000;
        public const int PrepTimeMinRange = 0;
        public const int PrepTimeMaxRange = 1000;
        public const int PortionsMinRange = 0;
        public const int PortionsMaxRange = 20;
        public const int TemperatureMinRange = 0;
        public const int TemperatureMaxRange = 500;

        //OvenType
        public const int OvenMaxLenght = 25;

        //RecepieType
        public const int RecepieTypeNameLenght = 50;
        public const int RecepieTypeDescriptionLenght = 500;

        //TemperatureMeasurment
        public const int TemperatureMeasurmentMaxLenght = 5;

        //Measurements
        public const int MeasurementsNameMaxLengt = 100;

        //Ingredient
        public const int IngredientNameMinLengt = 1;
        public const int IngredientNameMaxLengt = 100;
        public const int IngredientDescriptionMaxLengt = 500;
        public const double IngredienAmountMinRange = 0.00;
        public const double IngredienAmountMaxRange = 1000.00;


        //Steps
        public const int StepDescriptionMinLengt = 10;
        public const int StepDescriptionMaxLengt = 1000;


        //Admin

        //BanList
        public const int BanReasonMinLenght = 10;
        public const int BanReasonMaxLenght = 200; 
        }
    }
