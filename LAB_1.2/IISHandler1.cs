using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.WebSockets;

namespace LAB_1._2
{
    public class IISHandler1 : IHttpHandler
    {
        WebSocket socket;
        public bool IsReusable
        {

            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(WebSocketRequest);
            }
        }

        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            socket = context.WebSocket;
            await Send(DateTime.Now.ToString("HH:mm:ss"));

            while (socket.State == WebSocketState.Open)
            {
                Thread.Sleep(2000);
                await Send(DateTime.Now.ToString("HH:mm:ss"));
            }
        }

        private async Task Send(string s)
        {
            var sendbuffer = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(s));
            await socket.SendAsync(sendbuffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}