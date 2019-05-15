using DesignPatterns.EventAggregator.ConcreteAggregator;
using DesignPatterns.EventAggregator.Entities;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns.xUnitTests
{
    public class EventAggregatorTests
    {
        private readonly ITestOutputHelper _output;
        private readonly OrderAggregator _orderAggregator;
        private readonly OrderManager _orderManager;

        public EventAggregatorTests(ITestOutputHelper output)
        {
            _orderAggregator = new OrderAggregator();
            _orderManager = new OrderManager(_orderAggregator);
            _output = output;
        }

        [Fact(DisplayName = "Positive Case - Order Created Event")]
        public void OrderCreatedEvent_Test()
        {
            var orderCreated = new OrderCreated
            {
                Order = new Order
                {
                    OrderId = 1,
                    Description = "Order Created"
                }
            };

            _orderAggregator.Publish(orderCreated);

            Thread.Sleep(100);

            Assert.Equal("Order ID: 1 - Order Created", _orderManager.EventDescription);
            _output.WriteLine(_orderManager.EventDescription);
        }

        [Fact(DisplayName = "Positive Case - Order Edited Event")]
        public void OrderEditedEvent_Test()
        {
            var orderEdited = new OrderEdited
            {
                Order = new Order
                {
                    OrderId = 1,
                    Description = "Order Edited"
                }
            };

            _orderAggregator.Publish(orderEdited);

            Thread.Sleep(100);

            Assert.Equal("Order ID: 1 - Order Edited", _orderManager.EventDescription);
            _output.WriteLine(_orderManager.EventDescription);
        }

        [Fact(DisplayName = "Positive Case - Order Saved Event")]
        public void OrderSavedEvent_Test()
        {
            var orderSaved = new OrderSaved
            {
                Order = new Order
                {
                    OrderId = 1,
                    Description = "Order Saved"
                }
            };

            _orderAggregator.Publish(orderSaved);

            Thread.Sleep(100);

            Assert.Equal("Order ID: 1 - Order Saved", _orderManager.EventDescription);
            _output.WriteLine(_orderManager.EventDescription);
        }

        [Fact(DisplayName = "Negative Case - Order Created Event")]
        public void NegativeCase_OrderCreatedEvent_Test()
        {
            var client = new OrderCreatedSubscriber(_orderAggregator);
            var orderCreated = new OrderEdited
            {
                Order = new Order
                {
                    OrderId = 1,
                    Description = "Order Edited"
                }
            };

            _orderAggregator.Publish(orderCreated);

            Thread.Sleep(100);

            Assert.Null(client.EventDescription);
        }
    }
}
