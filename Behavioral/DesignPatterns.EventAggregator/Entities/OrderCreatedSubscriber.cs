using DesignPatterns.EventAggregator.Abstractions;

namespace DesignPatterns.EventAggregator.Entities
{
    public class OrderCreatedSubscriber : ISubscriber<OrderCreated>
    {
        public string EventDescription { get; set; }

        public OrderCreatedSubscriber(IEventAggregator ea)
        {
            ea.Subscribe(this);
        }

        public void OnEvent(OrderCreated e)
        {
            EventDescription = $"{e.Order.GetDetails()}";
        }
    }
}
