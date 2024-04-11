namespace Kontenery_app.Exceptions;

public class OverfillException : Exception
{
    public OverfillException() : base("Attempt to overfill the container!")
    {
    }
}