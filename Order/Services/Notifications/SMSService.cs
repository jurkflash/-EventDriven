namespace Order.Services.Notifications
{
    public class SMSService
    {
        public void onCompleted(object source, OrderEventArgs orderEventArgs)
        {
            Console.WriteLine("Sending sms for order id " + orderEventArgs.Order.Id + "...");
        }
    }
}
