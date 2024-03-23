namespace CookBook.Core.Exceptions
    {
    public class UnauthorisedActionException : Exception
        {
        public UnauthorisedActionException(){ }
        public UnauthorisedActionException(string messe)
            : base(messe) { }
        }
    }
