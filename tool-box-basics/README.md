# Common Toolbox methods

In functional programming we pefer to use many small declartive fucntions that are immutable and easy to reason about. In this section we will explore how we could implement some of these fucntions in a few common languages. Now, none of these implementations are designed for production and they have each been kept simple, to make it easier for the reader to understand how they work. 

## Mapping And Filtering
Perhaps the gateway drug of fucntional programming mapping and filtering fucntions have become quite popular in most object oritinted languages over the last decade or so. As they ahve come into fasion developers have leaned less and less of the old trusty for loop. 

Lets jump into some basic sketches of how we could build map

```hs
    -- Simple implementation of map in Haskell.
    -- Hakell provides a great general purpose implementation of map.
    map' :: (a -> b) -> [a] -> [b]
    map' _ [] = []
    map' f (x:xs) = f x : map f xs
```

```fs
    // Basic implementation of map in F#
    // F# provides numerous implementations of map for various data types.
    let rec map' f lis = 
        match lis with
        | x :: xs -> (f x) :: map' f xs
        | [] -> []
```

```cs
    // Basic implementation of Map in C#
    // C# provides a great implementation of this in the linq via the Select method.
    public static IEnumerable<TOut> Map<TIn,TOut>(this IEnumerable<TIn> arr, Func<TIn,TOut> func)
    {
        if(arr is null) throw new ArgumentNullException(nameof(arr));
        if(func is null) throw new ArgumentNullException(nameof(func));

        foreach (var item in arr)
            yield return func(item);
    }
```

```js
    // Basic implementation of map in js
    // js implements this as a member method on the Array class
    function map(arr, func){
        if(!arr || !Array.isArray(arr)) return arr;
        if(!func || typeof func !== 'function') return arr;

        const _map = (arr, func) => {
            for (const item of arr) {
                yield func(item); 
            }
        }

        return Array.from(_map(arr,func));
    }
```

Now lets see how we might take on filtering in each language.

```hs
    -- Simple implementation of filter in Haskell
    -- Hakell provides a great general purpose implementation of filter.
    filter' :: (a -> Bool) -> [a] -> [a]
    filter' _ [] = []
    filter' predicate (x:xs)
        | predicate x = x : filter' predicate xs
        | otherwise   = filter' predicate xs
```

```fs
    // Basic implementation of filter in F#
    // F# provides numerous implementations of filter for various data types.
    let rec filter' f lis =
        match lis with
        | x :: xs when f x -> x :: filter' f xs
        | _ :: xs -> filter' f xs
        | [] -> []
```

```cs
    // Basic implementation of Filter in C#
       // C# provides a great implementation of this in the linq via the Where method.
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> arr, Func<T,bool> func)
    {
        if(arr is null) throw new ArgumentNullException(nameof(arr));
        if(func is null) throw new ArgumentNullException(nameof(func));

        foreach (var item in arr)
            if(func(item)) yield return item;
    }

```

```js
    // Basic implementation of filter in js
    // js implements this as a member method on the Array class
    function filter(arr, func){
        if(!arr || !Array.isArray(arr)) return arr;
        if(!func || typeof func !== 'function') return arr;

        const _filter = (arr, func) => {
            for (const item of arr) {
                if(func(item)) yield item; 
            }};

        return Array.from(_filter(arr,func));
    }
```
Well that was interesting, but did you notice the general pattern that emerged in each of these solutions? Take a list, apply a function to it and accumulate up another list (using the word list here very losely). Well that brings me to my next toolbox function fold. 

```hs
    -- Simple implementation of fold in Haskell
    --
    fold' :: (cur -> acc -> acc) -> acc -> [cur] -> acc
    fold' _ _ [] = []
    fold' f acc (x:xs) = f x (fold' f acc xs)

```

```fs
    // Basic implementation of fold in F#
    // F# has 
    let rec fold' f acc lis =
        match lis with
        | x :: xs  ->  f x (fold' f acc xs)
        | [] -> acc
```

```cs
    // Basic implementation of Fold in C#
    // C# implaments this as the linq method Aggrigate
    public static IEnumerable<TOut> Fold<TIn,TOut>(this IEnumerable<TIn> arr, Func<TIn,TOut,TOut> func, TOut acc){
        if(arr is null) throw new ArgumentNullException(nameof(arr));
        if(func is null) throw new ArgumentNullException(nameof(func));

        var _acc = acc;
        
        foreach (var item in arr){
            _acc = func(item, _acc);
        }

        return _acc;          
    }
```

```js
    // Basic implementation of fold in js
    // js implamnets this as reduce on the Array class.
    function fold(arr, func, acc){
        if(!arr || !Array.isArray(arr)) return arr;
        if(!func || typeof func !== 'function') return arr;

        let _acc = acc;
        for (const item of arr) {
            _acc = func(item, _acc);
        }

        return _acc;
    }
```
