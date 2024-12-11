using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.WebSockets;

namespace WebSocketsTutorial.Utils {
    public class WebSocketHandler : IHttpHandler {
        private readonly static List<WebSocket> _clients = new List<WebSocket>();
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context) {
            if (context.IsWebSocketRequest) {
                context.AcceptWebSocketRequest(HandleWebSocket);
                return;
            }

            context.Response.StatusCode = 400;
            context.Response.End();
        }

        private async Task HandleWebSocket(AspNetWebSocketContext context) {
            WebSocket webSocket = context.WebSocket;
            _clients.Add(webSocket);

            try {
                byte[] buffer = new byte[1024];

                while (true) {
                    WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close) {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                        _clients.Remove(webSocket);
                        break;
                    }

                    string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    await BroadcastMessageAsync(message, webSocket);
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task BroadcastMessageAsync(string message, WebSocket sender) {
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);

            List<WebSocket> disconnectedClients = new List<WebSocket>();

            foreach (var client in _clients) {
                if (client.State == WebSocketState.Open && client != sender) {
                    try {
                        await client.SendAsync(new ArraySegment<byte>(messageBuffer), WebSocketMessageType.Text, true, CancellationToken.None);
                    } catch {
                        disconnectedClients.Add(client);
                    }
                }
            }

            foreach (var client in disconnectedClients) {
                _clients.Remove(client);
            }
        }
    }
}