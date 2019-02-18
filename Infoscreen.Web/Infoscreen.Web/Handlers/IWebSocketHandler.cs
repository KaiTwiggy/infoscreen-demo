using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Infoscreen.Web.Handlers
{
    public interface IWebSocketHandler
    {
        void AddSocket(WebSocket socket);
        void RemoveSocket(WebSocket socket);

        void SendMessage(string message);

        void UpdateSlide(WebSocket webSocket);

        void UpdateSlides();
    }
}
