using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace WeekendMeetingsSandbox.Hubs
{
    [HubName("Sprites")]
    public class CanvasAnimationHub : Hub
    {

        public void Match(string a, string b)
        {
            Clients.All.match();
        }
    }
}