using System;
using Automatonymous;

namespace Test.StateMachine
{
    public class TestState : SagaStateMachineInstance
    {
        public TestState(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
        public Guid CorrelationId { get; set; }
        public CompositeEventStatus CompositeStatus { get; set; }
        public string State { get; set; }

        public string Message { get; set; }
        public DateTimeOffset? TestSubmitted { get; set; }

    }
}
