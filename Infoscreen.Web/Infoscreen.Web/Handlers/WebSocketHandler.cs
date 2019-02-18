using Infoscreen.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;

namespace Infoscreen.Web.Handlers
{
    public class WebSocketHandler : IWebSocketHandler
    {
        private static IList<WebSocket> _websockets { get; set; }
        private ISlideService _slideService { get; set; }

        public WebSocketHandler(ISlideService slideService)
        {
            _slideService = slideService;
            if (_websockets == null)
            {
                _websockets = new List<WebSocket>();
            }
        }

        public void AddSocket(WebSocket socket)
        {
            _websockets.Add(socket);
        }

        public void RemoveSocket(WebSocket socket)
        {
            _websockets.Add(socket);
        }

        public async void SendMessage(string message)
        {
            foreach (var socket in _websockets)
            {
                if (socket.State != WebSocketState.Open)
                {
                    _websockets.Remove(socket);
                    continue;
                }

                var bytes = System.Text.Encoding.UTF8.GetBytes(message);

                await socket.SendAsync(new ArraySegment<byte>(bytes),
                    WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        public async void UpdateSlides()
        {
            var bytes = GetSlides();

            foreach (var socket in _websockets.Where(ws => ws.State == WebSocketState.Open))
            {
                await socket.SendAsync(new ArraySegment<byte>(bytes),
                    WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        public async void UpdateSlide(WebSocket webSocket)
        {
            var bytes = GetSlides();

            await webSocket.SendAsync(new ArraySegment<byte>(bytes),
                    WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private byte[] GetSlides()
        {
            var slideDeck = _slideService.GetSlides().Result;
            slideDeck.Slides = slideDeck.Slides.Where(s => s.IsActive && !s.IsDeleted).ToList();
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var data = JsonConvert.SerializeObject(slideDeck, jsonSerializerSettings);
            return System.Text.Encoding.UTF8.GetBytes(data);

        }
    }
}
