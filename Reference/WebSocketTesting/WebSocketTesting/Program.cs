using MessageProject;
using System;
using WebSocketSharp;

namespace WebSocketTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Message();
        }

        private static void Websocket()
        {
            using (var ws = new WebSocket("wss://localhost:44315/ws"))
            {
                ws.OnOpen += (sender, e) =>
                    Console.WriteLine("Connection open");

                ws.OnMessage += (sender, e) =>
                  Console.WriteLine("Server returns says: " + e.Data);

                ws.Connect();

                while (true)
                {
                    var text = Console.ReadLine();
                    var message = new EncapsulatedMessage(MessageType.MESSAGE, text);
                    var binaryMessage = BinarySerialization.SerializeToString(message);
                    ws.Send(binaryMessage);
                }
            }
        }

        private static void Message()
        {
            var text = Console.ReadLine();
            var message = new EncapsulatedMessage(MessageType.MESSAGE, text);
            var binaryMessage = BinarySerialization.SerializeToString(message);
            Console.WriteLine(binaryMessage);
        }

        private static void DMessage()
        {
            var text = Console.ReadLine();
            var message = BinarySerialization.DeserializeFromString<EncapsulatedMessage>(text);
            Console.WriteLine(message.GetData<string>());
        }
    }
}
