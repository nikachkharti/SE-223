using System.Runtime.Serialization;

namespace Library.Exceptions.Authors
{
    public class NoAuthorException : Exception
    {
        public NoAuthorException() : base("Authors not found")
        {
        }
    }
}
