namespace Library.Exceptions.Authors
{
    public class AuthorAlreadyExistsException : Exception
    {
        public AuthorAlreadyExistsException() : base("Author already exists.")
        {
        }
    }
}
