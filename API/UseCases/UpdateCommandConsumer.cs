using API.Models.Kafka;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace API.UseCases
{
    public class UpdateCommandConsumer : IConsumer<ITrackingUpdateCommand>
    {
        public Task Consume(ConsumeContext<ITrackingUpdateCommand> context)
        {
            Console.WriteLine(context.Message.Text);
            return Task.CompletedTask;
        }
    }
}
