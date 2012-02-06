﻿using System;

namespace MemBus
{
    /// <summary>
    /// Base class to write a handler that handles messages of the given param type
    /// </summary>
    [Obsolete("In a next release MemBus may not support this class. It was used in the context of resolving handlers from Ioc. You are now able to define your own Handler based on a a generic interface")]
    public abstract class Handles<T> : IHandles<T>
    {
        /// <summary>
        /// <see cref="IHandles{T}.Push(T)"/>
        /// </summary>
        public void Push(T message)
        {
            push(message);
        }

        void ISubscription.Push(object message)
        {
            var typedMsg = (T)message;
            if (matches(typedMsg))
              Push(typedMsg);
        }

        bool ISubscription.Handles(Type messageType)
        {
            return typeof (T).IsAssignableFrom(messageType);
        }

        /// <summary>
        /// return true to handle this message
        /// </summary>
        protected virtual bool matches(T message)
        {
            return true;
        }

        /// <summary>
        /// Implement to obtain message instances of the desired type
        /// </summary>
        protected abstract void push(T message);
        
    }
}