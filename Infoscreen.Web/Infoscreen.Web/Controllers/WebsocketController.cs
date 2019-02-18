using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Threading;
using Infoscreen.Web.Handlers;
using Infoscreen.Web.Services;

namespace Infoscreen.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Websocket")]
    public class WebsocketController : Controller
    {
        private IWebSocketHandler _websocketHandler;        

        public WebsocketController(IWebSocketHandler handler)
        {
            _websocketHandler = handler;
            
        }
        [HttpGet]
        public async Task<StatusCodeResult> GetAsync()
        {
            if (this.HttpContext.WebSockets.IsWebSocketRequest)
            {
                var webSocket = await this.HttpContext.WebSockets.AcceptWebSocketAsync();
                if (webSocket != null && webSocket.State == WebSocketState.Open)
                {
                    _websocketHandler.AddSocket(webSocket);
                    _websocketHandler.UpdateSlide(webSocket);

                    var buffer = new byte[1024 * 4];
                    WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    while (!result.CloseStatus.HasValue)
                    {
                        result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    }

                    await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                    _websocketHandler.RemoveSocket(webSocket);
                }
            }

            return new OkResult();
        }

        [Route("sendmessage")]
        [HttpGet]
        public async Task<StatusCodeResult> SendMessageAsync(string message)
        {
            _websocketHandler.SendMessage(message);
            return new OkResult();
        }

        [Route("UpdateSlides")]
        [HttpGet]
        public async Task<StatusCodeResult> UpdateSlides()
        {
            _websocketHandler.UpdateSlides();
            return new OkResult();
        }
        
    }
}