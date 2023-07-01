namespace AddonMoney.API.Services
{
    public class ConsumerHostedService : IHostedService
    {
        private readonly MQConsumer _consumer;

        public ConsumerHostedService(IServiceProvider services, IConfiguration configuration)
        {
            _consumer = new(services, configuration);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _consumer.StartBalanceConsuming();
            _consumer.StartErrorConsuming();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _consumer.CloseConnection();
            return Task.CompletedTask;
        }
    }
}
