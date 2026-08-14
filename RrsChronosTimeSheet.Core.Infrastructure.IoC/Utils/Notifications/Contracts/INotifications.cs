using RrsChronosTimeSheet.Core.Infrastructure.IoC.Domains;

namespace RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts
{
    public interface INotifications
    {
        bool HasNotification();

        List<Notification> GetAllNotifications();

        void Handle(Notification notification);
    }
}
