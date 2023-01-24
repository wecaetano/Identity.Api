using System.Net;

namespace Identity.CrossCutting.DTO
{
    public class CustomApiResponse<T>
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();

        public long Total { get; set; }

        public long ResponseTime { get; set; }

        public string Feedback { get; set; }

        public HttpStatusCode Status { get; set; }

        public IEnumerable<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
