using LibraryManagementSystemBackend.Hubs;
using LibraryManagementSystemBackend.Observer;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.SignalR;

namespace LibraryManagementSystemBackend.Core.Entities
{
    public class MemberModel : UserModel, IObserver
    {
        public int MemberID { get; set; }
        public string? Address { get; set; }

        private readonly IHubContext<NotificationHub> _hubContext;

        public MemberModel(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void Update(string message)
        {
            // Send the notification to the frontend via SignalR
            _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }

    }
}
