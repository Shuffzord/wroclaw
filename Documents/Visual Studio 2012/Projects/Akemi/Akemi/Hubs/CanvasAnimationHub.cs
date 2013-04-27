using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

// ReSharper disable CheckNamespace
namespace WeekendMeetingsSandbox.Hubs
// ReSharper restore CheckNamespace
{
    [HubName("Sprites")]
    public class CanvasAnimationHub : Hub
    {
        private static readonly Dictionary<string, string> GroupsByConnectionId = new Dictionary<string, string>();

        public Random Rand = new Random();
        public override Task OnConnected()
        {
            var pickedValue = Rand.Next(0, 2);

            var connectionId = Context.ConnectionId;
            var groupName = pickedValue.ToString(CultureInfo.InvariantCulture);
            Groups.Add(connectionId, groupName);
            GroupsByConnectionId.Add(connectionId, groupName);

            return Clients.Group(groupName, Context.ConnectionId).debugMsg(string.Format("New Client Connected {0} to group {1}", Context.ConnectionId, pickedValue.ToString(CultureInfo.InvariantCulture)));
        }

        public override Task OnReconnected()
        {
            return Clients.All.debugMsg(string.Format("Client {0} reconnected", Context.ConnectionId));
        }

        public override Task OnDisconnected()
        {
            return Clients.All.debugMsg(string.Format("Faggot {0} left", Context.ConnectionId));
        }

        public void Match(int idA, int idB) //toGuid
        {
            Clients.All.debugMsg("wiedz ze cos sie dzieje");
            Clients.OthersInGroup(GroupsByConnectionId[Context.ConnectionId]).debugMsg(string.Format("matching {0} and {1} for user {2}", idA, idB, Context.ConnectionId));
        }
    }
}