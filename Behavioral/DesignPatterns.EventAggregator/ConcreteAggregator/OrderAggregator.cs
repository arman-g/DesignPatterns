using DesignPatterns.EventAggregator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DesignPatterns.EventAggregator.ConcreteAggregator
{
    public class OrderAggregator : IEventAggregator
    {
        private readonly Dictionary<Type, List<WeakReference>> _eventSubscriberList = 
            new Dictionary<Type, List<WeakReference>>();

        private readonly object _lock = new object();


        public void Publish<TEvent>(TEvent eventToPublish)
        {
            var subscriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEvent));
            var subscribers = GetSubscribers(subscriberType);
            var subscribersToRemove = new List<WeakReference>();

            foreach (var weakSubscriber in subscribers)
            {
                if (weakSubscriber.IsAlive)
                {
                    var subscriber = (ISubscriber<TEvent>) weakSubscriber.Target;
                    var syncContext = SynchronizationContext.Current ?? new SynchronizationContext();
                    
                    syncContext.Post(x => subscriber.OnEvent(eventToPublish), null);
                }
                else
                {
                    subscribersToRemove.Add(weakSubscriber);
                }
            }

            if (!subscribersToRemove.Any()) return;
            lock (_lock)
            {
                foreach (var remove in subscribersToRemove)
                {
                    subscribers.Remove(remove);
                }
            }
        }

        public void Subscribe(object subscriber)
        {
            lock (_lock)
            {
                var subscriberTypes = subscriber.GetType().GetInterfaces().Where(x =>
                    x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ISubscriber<>));

                var weakReference = new WeakReference(subscriber);
                foreach (var subscriberType in subscriberTypes)
                {
                    var subscribers = GetSubscribers(subscriberType);
                    subscribers.Add(weakReference);
                }
            }
        }

        private List<WeakReference> GetSubscribers(Type subscriberType)
        {
            List<WeakReference> subscribers;
            lock (_lock)
            {
                var found = _eventSubscriberList.TryGetValue(subscriberType, out subscribers);
                if (found) return subscribers;
                subscribers = new List<WeakReference>();
                _eventSubscriberList.Add(subscriberType, subscribers);
            }

            return subscribers;
        }
    }
}
