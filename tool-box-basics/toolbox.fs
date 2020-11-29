module Toolbox

// Basic implementation of map in F#
let rec map' f lis = 
    match lis with
    | x :: xs -> (f x) :: map' f xs
    | [] -> []
   
// Basic implementation of filter in F#
let rec filter' f lis =
    match lis with
    | x :: xs when f x -> x :: filter' f xs
    | _ :: xs -> filter' f xs
    | [] -> []

// Basic implementation of fold in F#
let rec fold' f acc lis =
    match lis with
    | x :: xs  ->  f x (fold' f acc xs)
    | [] -> acc