using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Domains;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Web.Api.Controllers.Base
{
    public class MainController : Controller
    {
        private readonly Infrastructure.IoC.Utils.Notifications.Contracts.INotifications _notification;

        protected MainController(Infrastructure.IoC.Utils.Notifications.Contracts.INotifications notification)
        {
            _notification = notification;
            //AppUser = appUser;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result

                });
            }

            return BadRequest(new
            {
                success = false,
                error = _notification.GetAllNotifications().Select(s => s.Message)
            });
        }

        protected void NotifyError(string message)
        {
            _notification.Handle(new Notification(message));
        }

        protected bool ValidOperation()
        {
            return !_notification.HasNotification();
        }
    }
}
