namespace Order.Services
{
    public class OrderService
    {
        public delegate void OrderCompletedEventHandler(object source, OrderEventArgs orderEventArgs);

        public event OrderCompletedEventHandler OrderCompleted;

        public void Complete(Order order)
        {
            Console.WriteLine("Completing order id + " + order.Id + " ...");

            onCompleted(order);
        }

        protected virtual void onCompleted(Order order)
        {
            if (OrderCompleted != null)
            {
                OrderCompleted(this, new OrderEventArgs() { Order = order });
            }
        }
    }
}
