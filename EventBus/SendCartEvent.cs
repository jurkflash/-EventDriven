namespace EventBus
{
    public class SendCartEvent
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateTime CreatedTime { get; private set; } = DateTime.UtcNow;

        public string ItemName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}