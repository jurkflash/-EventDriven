using EventBus;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Order.Services;
using Order.Services.Notifications;
using System.Text.Json;

namespace Order.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndPoint;

        public OrderController(
            IPublishEndpoint publishEndPoint
            )
        {
            _publishEndPoint = publishEndPoint;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(OrderUpdateCart orderUpdateCart)
        {
            SendCartEvent sendCardEvent = new();
            //process
            sendCardEvent.Type = orderUpdateCart.Type;
            sendCardEvent.Quantity = orderUpdateCart.Quantity;

            Console.WriteLine("Order update received: " + JsonSerializer.Serialize(orderUpdateCart).ToString());

            await _publishEndPoint.Publish(sendCardEvent);

            Console.WriteLine("Order update send to cart: " + JsonSerializer.Serialize(sendCardEvent).ToString());

            return Ok();
        }

        [HttpPost("Complete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Complete(int orderId)
        {
            //assume get from db
            Order orderInDb = new Order()
            {
                Id = orderId
            };
            var orderService = new OrderService();
            var smsService = new SMSService();
            var emailService = new EmailService();

            orderService.OrderCompleted += smsService.onCompleted;
            orderService.OrderCompleted += emailService.onCompleted;

            orderService.Complete(orderInDb);

            return Ok();
        }
    }
}
