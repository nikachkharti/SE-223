using System.Runtime.Serialization;

namespace Library.Helper.Exceptions
{
    public class NoAuthorException : Exception
    {
        public NoAuthorException() : base("Authors not found")
        {
        }
    }
}
