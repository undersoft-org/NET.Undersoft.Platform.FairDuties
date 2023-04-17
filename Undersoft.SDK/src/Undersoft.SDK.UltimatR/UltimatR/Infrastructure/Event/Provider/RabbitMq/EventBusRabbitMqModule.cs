using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace UltimatR
{
    public class EventBusRabbitMqModule 
    {
        public void ConfigureServices(IServiceConfiguration configuration)
        {
            configuration.Configure<RabbitMqEventBusOptions>("RabbitMQ:EventBus");
        }

        public void OnApplicationInitialization()
        {
            ServiceManager.GetManager()
                .GetRequiredService<RabbitMqEventBus>()
                .Initialize();
        }
    }
}