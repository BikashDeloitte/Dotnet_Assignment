using InboundService.Models;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;
using InboundService.Controllers;

namespace InboundService.RabbitMQ
{
    /*
    public class RabbitMQSender : IRabbitMQSender
    {
        private readonly ILogger<RabbitMQSender> _logger;
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _username;
        private IConnection _connection;

        //amps://vdpwwddq:YiiHpmjG8ytEeGEoOKrLCLpDnE_n6zyk@fly.rmq.cloudamqp.com/vdpwwddq
        public RabbitMQSender(ILogger<RabbitMQSender> logger)
        {
            _logger = logger;
            _hostname = "fly.rmq.cloudamqp.com";
            _password = "guYiiHpmjG8ytEeGEoOKrLCLpDnE_n6zykest";
            _username = "vdpwwddq";
        }

        public void SendMessage(Order message, string queueName)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amps://vdpwwddq:YiiHpmjG8ytEeGEoOKrLCLpDnE_n6zyk@fly.rmq.cloudamqp.com/vdpwwddq:15672")
            };
            _connection = factory.CreateConnection();
            // if (ConnectionExists())
            // {
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            _logger.LogInformation("completed sending");
            //}
        }

        //private void CreateConnection()
        //{
        //    try
        //    {
        //        var factory = new ConnectionFactory
        //        {
        //            HostName = _hostname,
        //            UserName = _username,
        //            Password = _password
        //        };
        //        _connection = factory.CreateConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //    }
        //}

        //private bool ConnectionExists()
        //{
        //    if (_connection != null)
        //    {
        //        return true;
        //    }
        //    CreateConnection();
        //    return _connection != null;
        //}
    }*/
}

