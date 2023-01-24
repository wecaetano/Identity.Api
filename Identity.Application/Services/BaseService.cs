using Identity.CrossCutting.DTO;
using Identity.CrossCutting.Enum;
using System.Data.Common;
using System.Net;

namespace Identity.Application.Services
{
    public abstract class BaseService
    {
        protected static CustomApiResponse<T> ManageException<T>(CustomApiResponse<T> result, Exception inputException)
        {
            var notifications = new List<Notification>();

            switch (inputException)
            {
                case DbException:
                    {
                        notifications.Add(new Notification
                        {
                            Type = NotificationType.Database,
                            Message = inputException.Message
                        });

                        result.Status = HttpStatusCode.InternalServerError;

                        break;
                    }
                case ApplicationException:
                    {
                        notifications.Add(new Notification
                        {
                            Type = NotificationType.Generic,
                            Message = inputException.Message
                        });

                        result.Status = HttpStatusCode.InternalServerError;

                        break;
                    }
                default:
                    {
                        throw inputException;
                    }
            }

            result.Notifications = notifications;

            return result;
        }
    }
}
