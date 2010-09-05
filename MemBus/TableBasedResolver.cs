﻿using System;
using System.Collections.Generic;

namespace MemBus
{
    internal class TableBasedResolver : ISubscriptionResolver
    {
        private readonly Dictionary<Type, CompositeSubscription> subscriptions = new Dictionary<Type, CompositeSubscription>();

        public IEnumerable<ISubscription> GetSubscriptionsFor(object message)
        {
            return getRelevantComposite(message.GetType());
        }

        public bool Add(ISubscription subscription)
        {
            var cs = getRelevantComposite(subscription.Handles);
            cs.Add(subscription);
            return true;
        }

        private CompositeSubscription getRelevantComposite(Type messageType)
        {
            CompositeSubscription cs;
            subscriptions.TryGetValue(messageType, out cs);
            return cs ?? (subscriptions[messageType] = new CompositeSubscription());
        }
    }
}