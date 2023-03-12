using Cart.Domain;
using Cart.Services;
using Cart.Services.Interfaces;
using EventBus;
using MassTransit;
using System.Text.Json;

namespace Cart.EventBusConsumer
{
    public class SendCartConsumer : IConsumer<SendCartEvent>
    {
        private readonly IUpdateService _updateService;
        public SendCartConsumer(
            IUpdateService updateService)
        {
            _updateService = updateService;
        }

        public async Task Consume(ConsumeContext<SendCartEvent> context)
        {
            var sendCartEvent = context.Message;
            CartDetail cartDetail = new();
            cartDetail.ItemName = sendCartEvent.ItemName;
            cartDetail.Quantity = sendCartEvent.Quantity;
            cartDetail.Type = sendCartEvent.Type;

            await _updateService.UpdateAsync(cartDetail);
        }
    }
}
