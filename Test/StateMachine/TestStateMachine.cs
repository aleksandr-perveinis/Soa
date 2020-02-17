using System;
using Automatonymous;
using Automatonymous.Binders;
using Test.Models;

namespace Test.StateMachine
{
    public class TestStateMachine : MassTransitStateMachine<TestState>
    {
    
        public TestStateMachine()
        {
             InstanceState(x => x.State);

            ConfigureCorrelationIds();
            Initially(SetTestSummitedHandler());
          //  During(Processing, SetStockReservedHandler(), SetPaymentProcessedHandler());

            //During(Processing,
            //    When(ReadyForShipment)
            //        .Then(c => Console.WriteLine($"Order {c.Instance.OrderId} was allowed to be shipped"))
            //        .Finalize());

       //     CompositeEvent(() => ReadyForShipment, order => order.CompositeStatus, PaymentProcessed, StockReserved);
        }

        private void ConfigureCorrelationIds()
        {
            Event(() => TestSubmitted, x => x.CorrelateById(c => c.Message.CorrelationId).SelectId(c => c.Message.CorrelationId));
        }


        private EventActivityBinder<TestState, IMessage> SetTestSummitedHandler() =>
            When(TestSubmitted).Then(c =>
                {
                    c.Instance.TestSubmitted = DateTimeOffset.Now;
                    c.Instance.Message = c.Data.Text;
                    Console.WriteLine($"Saga was created with Message: {c.Data.Text}. CorrelationId: {c.Data.CorrelationId}");
                })
                .TransitionTo(Processing);

        public State Processing { get; set; }
        //public Event ReadyForShipment { get; set; }
        public Event<IMessage> TestSubmitted { get; set; }
    }

}
