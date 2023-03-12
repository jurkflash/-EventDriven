using Order.Services;

namespace Order.NUnitTests
{
    [TestFixture]
    public class OrderServiceTests
    {
        private OrderService _orderService;

        [SetUp]
        public void Setup()
        {
            _orderService = new OrderService();
        }

        [Test]
        public void Complete_WhenCalled_RaiseOrderCompletedEvent()
        {
            OrderEventArgs orderEventArgs = new OrderEventArgs();
            _orderService.OrderCompleted += (sender, args) => { orderEventArgs = args; };
            _orderService.Complete(new Order() { Id = 1 });

            Assert.That(orderEventArgs.Order.Id, Is.EqualTo(1));
        }
    }
}