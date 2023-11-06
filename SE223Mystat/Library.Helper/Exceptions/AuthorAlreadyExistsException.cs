namespace Library.Helper.Exceptions
{
    public class AuthorAlreadyExistsException : Exception
    {
        public AuthorAlreadyExistsException() : base("Author already exists.")
        {
        }
    }
}
