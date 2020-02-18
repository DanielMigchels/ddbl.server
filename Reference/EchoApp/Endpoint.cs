using MessageProject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EchoApp
{
    public class Endpoint
    {
        public static async Task Handle(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[8192];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                string str = Encoding.UTF8.GetString(buffer, 0, result.Count);
                var message = BinarySerialization.DeserializeFromString<EncapsulatedMessage>(str);

                if (message.MessageType == MessageType.MESSAGE)
                {
                    string ret = "Right back at ya: " + message.GetData<string>();
                    await webSocket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(ret), 0, ret.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
                }

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}
