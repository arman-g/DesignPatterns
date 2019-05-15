namespace DesignPatterns.EventAggregator.Abstractions
{
    public interface IEventAggregator
    {
        void Publish<TEvent>(TEvent eventToPublish);

        void Subscribe(object subscriber);
    }
}
