namespace DesignPatterns.EventAggregator.Abstractions
{
    public interface ISubscriber<in TEvent>
    {
        void OnEvent(TEvent e);
    }
}
