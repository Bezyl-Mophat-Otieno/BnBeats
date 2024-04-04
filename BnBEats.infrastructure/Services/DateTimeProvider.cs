using BnBEats.application;

namespace BnBEats.infrastructure;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime utcNow => DateTime.UtcNow;
}
