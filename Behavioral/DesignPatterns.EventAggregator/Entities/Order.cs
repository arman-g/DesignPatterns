namespace DesignPatterns.EventAggregator.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public string GetDetails()
        {
            return $"Order ID: {OrderId} - {Description}";
        }
    }
}
