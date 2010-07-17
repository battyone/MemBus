﻿namespace MemBus
{
    public interface IConfigurableBus
    {
        void InsertResolver(ISubscriptionResolver resolver);
        void InsertPublishPipelineMember(IPublishPipelineMember publishPipelineMember);
        void AddSubscription(ISubscription subscription);
        void AddAutomaton(object automaton);
    }
}