using CookBook.Core.Contracts;
using System.Text.RegularExpressions;

namespace CookBook.Core.Extentions
    {
    public static class ModelExtentions
        {
        public static string GetInformation(this IRecepie recepie)
            {
            string info = recepie.Name.Replace(" ", "-");
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);
            return info;
            }
        }
    }
