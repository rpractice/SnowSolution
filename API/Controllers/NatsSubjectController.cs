using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NATS.Client;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NatsSubjectController : ControllerBase
    {
        private static readonly string url = "nats://localhost:4222";
        private static readonly string subject = "snow.test.pubsub";
        private static IConnection _connection;
        private static ISyncSubscription sub;

        public NatsSubjectController()
        {
            if (_connection == null)
            {
                _connection = ConnectToNats();
                sub = _connection.SubscribeSync(subject);
            }
        }

        private static IConnection ConnectToNats()
        {
            ConnectionFactory factory = new ConnectionFactory();
            var options = ConnectionFactory.GetDefaultOptions();
            options.Url = url;
            return factory.CreateConnection(options);
        }


        [HttpGet()]
        public async Task<string> Get()
        {
            string response = string.Empty;
            try
            {
                sub = _connection.SubscribeSync(subject);
                await Task.Run(() =>
                {
                    var message = sub.NextMessage();
                    if (message != null)
                    {
                        response = Encoding.UTF8.GetString(message.Data);
                    }
                });
                return response;
            }
            catch (Exception ex)
            {

                return response;
            }
        }

        [HttpPost()]
        public async void Post([FromBody]string message)
        {
            await Task.Run(() =>
            {
                _connection.Publish(subject, Encoding.UTF8.GetBytes(message));
            });

        }
    }
}