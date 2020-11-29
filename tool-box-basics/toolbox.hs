-- Simple implementation of map in Haskell.
--
map' :: (a -> b) -> [a] -> [b]
map' _ [] = []
map' f (x:xs) = f x : map f xs

-- Simple implementation of filter in Haskell
--
filter' :: (a -> Bool) -> [a] -> [a]
filter' _ [] = []
filter' predicate (x:xs)
    | predicate x = x : filter' predicate xs
    | otherwise   = filter' predicate xs

-- Simple implementation of fold in Haskell
--
fold' :: (cur -> acc -> acc) -> acc -> [cur] -> acc
fold' _ _ [] = []
fold' f acc (x:xs) = f x (fold' f acc xs)