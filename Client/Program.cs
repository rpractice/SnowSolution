using NATS.Client;
using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static bool _exit = false;
        private static string _userName;

        static void Main(string[] args)
        {
            PrintMessage("Simple Snow chat client demo");
            SubjectConsumer();
            PrintMessage("Consumers started");
            SubjectPublisher();
        }

        private static void SubjectConsumer()
        {

            //We can also subscribe subject here which will fetch the data instantly, but need to call Nats service from here.
            PrintMessage("Please enter username to start a chat");
            _userName = Console.ReadLine();
            Task.Run(() =>
            {
                while (!_exit)
                {
                    string message = Service.GetMessage().Result;
                    if (!string.IsNullOrEmpty(message))
                    {
                        PrintMessage(message);
                    }
                }
            });
        }

        private static void SubjectPublisher()
        {
            string response;
            PrintMessage("Please type something to chat");
            do
            {
                response = Console.ReadLine();
                string message = _userName + ": " + response + " " + DateTime.UtcNow.ToString();
                var serverResponse = Service.SendMessage(message).Result;
                if (!serverResponse)
                {
                    PrintMessage("Some problem with the server, Please try again later!");
                }
            } while (response.ToLower() != "quit");
            _exit = true;
        }
        private static void PrintMessage(string message)
        {
            Console.WriteLine($"{message}");
        }

    }
}
