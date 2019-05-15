using DesignPatterns.EventAggregator.Abstractions;

namespace DesignPatterns.EventAggregator.Entities
{
    public class OrderManager : 
        ISubscriber<OrderCreated>, 
        ISubscriber<OrderEdited>, 
        ISubscriber<OrderSaved>
    {
        public string EventDescription { get; set; }

        public OrderManager(IEventAggregator ea)
        {
            ea.Subscribe(this);
        }

        public void OnEvent(OrderCreated e)
        {
            EventDescription = $"{e.Order.GetDetails()}";
        }

        public void OnEvent(OrderEdited e)
        {
            EventDescription = $"{e.Order.GetDetails()}";
        }

        public void OnEvent(OrderSaved e)
        {
            EventDescription = $"{e.Order.GetDetails()}";
        }
    }
}