using AddonMoney.Data.API;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace AddonMoney.API.Services
{
    public class MQProducer : IDisposable
    {
        private readonly string _balanceQueue;
        private readonly string _errorQueue;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MQProducer(IConfiguration configuration)
        {
            _balanceQueue = configuration["MQ:QueueNameBalance"] ?? "AddonMoneyBalanceMsg";
            _errorQueue = configuration["MQ:QueueNameError"] ?? "AddonMoneyErrorMsg";
            var factory = new ConnectionFactory()
            {
                HostName = configuration["MQ:Host"] ?? "localhost",
                UserName = configuration["MQ:Username"] ?? "guest",
                Password = configuration["MQ:Password"] ?? "guest",
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: _balanceQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            _channel.QueueDeclare(queue: _errorQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        public void SendMessage(object data)
        {
            if (data == null) return;
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
            if (data is UpdateBalanceRequest)
            {
                _channel.BasicPublish(exchange: string.Empty,
                        routingKey: _balanceQueue,
                        basicProperties: null,
                        body: body);
            }
            else if (data is UpdateErrorRequest)
            {
                _channel.BasicPublish(exchange: string.Empty,
                        routingKey: _errorQueue,
                        basicProperties: null,
                        body: body);
            }
        }

        public void CloseConnection()
        {
            _channel.Close();
            _connection.Close();
            _channel?.Dispose();
            _connection?.Dispose();
        }

        public void Dispose()
        {
            CloseConnection();
            GC.SuppressFinalize(this);
        }
    }
}
