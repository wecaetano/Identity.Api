using Identity.CrossCutting.Enum;

namespace Identity.CrossCutting.DTO
{
    public record Notification
    {
        public NotificationType Type { get; init; }

        public string Message { get; init; }
    }
}
