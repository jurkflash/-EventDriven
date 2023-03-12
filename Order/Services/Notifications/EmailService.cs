namespace Order.Services.Notifications
{
    public class EmailService
    {
        public void onCompleted(object source, OrderEventArgs orderEventArgs)
        {
            Console.WriteLine("Sending email for order id " + orderEventArgs.Order.Id + "...");
        }
    }
}
