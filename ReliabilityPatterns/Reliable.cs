﻿using System;
using System.Collections.Generic;

namespace ReliabilityPatterns
{
    public static class Reliable
    {
        public static void ForEach<TSource>(
            CircuitBreaker circuitBreaker,
            IEnumerable<TSource> source,
            Action<TSource> body,
            ushort allowedRetriesPerElement,
            TimeSpan retryInterval)
        {
            foreach (var element in source)
            {
                var element1 = element;
                circuitBreaker.ExecuteWithRetries(
                    () => body(element1),
                    allowedRetriesPerElement,
                    retryInterval);
            }
        }
    }
}