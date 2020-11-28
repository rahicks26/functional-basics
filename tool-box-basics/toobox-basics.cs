using System.Collections.Generic;
using System;

namespace ToolBoxBasics
{
    public static class Extentions 
    {
        // Basic implementation of Map in C#
        public static IEnumerable<TOut> Map<TIn,TOut>(this IEnumerable<TIn> arr, Func<TIn,TOut> func)
        {
            if(arr is null) throw new ArgumentNullException(nameof(arr));
            if(func is null) throw new ArgumentNullException(nameof(func));

            foreach (var item in arr)
                yield return func(item);
        }
        // Basic implementation of Filter in C#
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> arr, Func<T,bool> func)
        {
            if(arr is null) throw new ArgumentNullException(nameof(arr));
            if(func is null) throw new ArgumentNullException(nameof(func));

            foreach (var item in arr)
                if(func(item)) yield return item;
        }
    }
}

