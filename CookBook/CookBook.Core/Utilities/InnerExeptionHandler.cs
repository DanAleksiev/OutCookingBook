using System.Text;

namespace CookBook.Core.Utilities
    {
    public static class InnerExeptionHandler
        {
        public static string GetCompleteMessage(this Exception error)
            {
            StringBuilder builder = new StringBuilder();
            Exception realerror = error;
            builder.AppendLine(error.Message);
            while (realerror.InnerException != null)
                {
                builder.AppendLine(realerror.InnerException.Message);
                realerror = realerror.InnerException;
                }
            return builder.ToString();
            }
        }
    }
