using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Serilog;
using AddonMoney.Data.API;
using AddonMoney.Data.Repositories;

namespace AddonMoney.API.Services
{
    public class MQConsumer : IDisposable
    {
        private static readonly string _logPrefix = "[MQCallbackConsumer]";

        private readonly string _balanceQueue;
        private readonly string _errorQueue;
        private readonly string _proxyStatusQueue;

        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _services;

        public MQConsumer(IServiceProvider services, IConfiguration configuration)
        {
            _services = services;
            _balanceQueue = configuration["MQ:QueueNameBalance"] ?? "AddonMoneyBalanceMsg";
            _errorQueue = configuration["MQ:QueueNameError"] ?? "AddonMoneyErrorMsg";
            _proxyStatusQueue = configuration["MQ:QueueNameProxyStatus"] ?? "AddonMoneyProxyStatus";

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

            _channel.QueueDeclare(queue: _proxyStatusQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        public void StartBalanceConsuming()
        {
            var semaphore = new SemaphoreSlim(10);
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                await semaphore.WaitAsync();
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var balanceRq = JsonConvert.DeserializeObject<UpdateBalanceRequest>(message);
                    if (balanceRq == null) return;

                    using var scoped = _services.CreateScope();
                    var balanceRepo = scoped.ServiceProvider.GetRequiredService<BalanceInfoRepository>();
                    await balanceRepo.UpdateBalance(balanceRq);
                    _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    Log.Error($"{_logPrefix} Handle balance {ea.DeliveryTag} failed.", ex);
                    _channel.BasicNack(ea.DeliveryTag, false, false);
                }
                finally { semaphore.Release(); }
            };
            _channel.BasicConsume(queue: _balanceQueue, autoAck: false, consumer: consumer);
        }

        public void StartErrorConsuming()
        {
            var semaphore = new SemaphoreSlim(10);
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                await semaphore.WaitAsync();
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    
                    var errorRq = JsonConvert.DeserializeObject<UpdateErrorRequest>(message);
                    if (errorRq == null) return;

                    using var scoped = _services.CreateScope();
                    var errRepo = scoped.ServiceProvider.GetRequiredService<ErrorInfoRepository>();
                    await errRepo.AddError(errorRq.Host, errorRq.Message);
                    _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    Log.Error($"{_logPrefix} Handle error {ea.DeliveryTag} failed.", ex);
                    _channel.BasicNack(ea.DeliveryTag, false, false);
                }
                finally { semaphore.Release(); }
            };
            _channel.BasicConsume(queue: _errorQueue, autoAck: false, consumer: consumer);
        }

        public void StartProxyStatusConsuming()
        {
            var semaphore = new SemaphoreSlim(10);
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                await semaphore.WaitAsync();
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var proStatRq = JsonConvert.DeserializeObject<UpdateProxyStatusRequest>(message);
                    if (proStatRq == null) return;

                    using var scoped = _services.CreateScope();
                    var balanceRepo = scoped.ServiceProvider.GetRequiredService<BalanceInfoRepository>();
                    await balanceRepo.UpdateProxyStatus(proStatRq);
                    _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    Log.Error($"{_logPrefix} Handle proxy status {ea.DeliveryTag} failed.", ex);
                    _channel.BasicNack(ea.DeliveryTag, false, false);
                }
                finally { semaphore.Release(); }
            };
            _channel.BasicConsume(queue: _balanceQueue, autoAck: false, consumer: consumer);
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
