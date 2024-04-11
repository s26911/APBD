namespace Kontenery_app.Exceptions;

public class IncorrectProductTypeException : Exception
{
    public IncorrectProductTypeException() : base("Incorrect product type! Aborting operation...")
    {
    }
}