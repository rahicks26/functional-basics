# Common Toolbox methods

In functional programming we pefer to use many small declartive fucntions that are immutable and easy to reason about. In this section we will explore how we could implement some of these fucntions in a few common languages. Now, none of these implementations are designed for production and they have each been kept simple, to make it easier for the reader to understand how they work. 

## Mapping And Filtering
Perhaps the gateway drug of fucntional programming mapping and filtering fucntions have become quite popular in most object oritinted languages over the last decade or so. As they ahve come into fasion developers have leaned less and less of the old trusty for loop. 

At its core the mapping function simple applies a transformation to each element in an array. To understand this better lets look at a few different basic implementations:

```fs
    // Basic implementation of map in F#
    // F# provides numerous implementations of map for various data types.
    let rec map' f lis = 
        match lis with
        | x :: xs -> (f x) :: map' f xs
        | [] -> []
```

First up is my favorite F#. This implementation that follows is designed to work with F# lists, but it demostrates the general solution well. Take a collection when it has at least one item apply that item to the provided function. When no more items are left return an empty list. 

Now for a lttle haskell:

```hs
    -- Simple implementation of map in Haskell.
    -- Hakell provides a great general purpose implementation of map.
    map' :: (a -> b) -> [a] -> [b]
    map' _ [] = []
    map' f (x:xs) = f x : map f xs
```

As you can see the two implementations look the same, but beacause of a few specifics about the underlying languages the haskell version is arguable more felxable the our F# implementation.

How about a little C#?

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
Here I opted to go for a more imparitive solution, mainly becuase working with enumorators directly can get verbose quickly and would really take away from the point. Now, it is note worthy that this is the first time we had to worry about nulls... Either way the implementation is very simple we and actually works for any standard collection in C#. 

Lets see what this looks like in js.

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
Well I am pickup a trend here the weaker my type system gets the more verbose my guard clauses are, also we did opt to use a generator here, but since most js devs would expect an array back we will just make a new one for them.