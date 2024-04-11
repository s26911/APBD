namespace Kontenery_app.Exceptions;

public class TemperatureTooHighException : Exception
{
    public TemperatureTooHighException(string productType, double temp) : base("Temperature of the container " +
                                                                               "over required " + temp + " for type " +
                                                                               productType)
    {
    }
}