using API.Models.Kafka;
using MassTransit;
using System.Threading.Tasks;

namespace API.UseCases
{
    public class UpdateCommandConsumer : IConsumer<ITrackingUpdateCommand>
    {
        public Task Consume(ConsumeContext<ITrackingUpdateCommand> context)
        {
            return Task.CompletedTask;
        }
    }
}
