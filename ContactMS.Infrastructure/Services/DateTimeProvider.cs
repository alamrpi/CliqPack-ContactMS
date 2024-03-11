using ContactMS.Application.Interfaces.Services;

namespace ContactMS.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
