module ToolBoxBasics 

// Basic implementation of map in F#
let rec map' f a = 
    match a with
    | x::xs -> f x :: map' f xs
    | [] -> []

// Basic implementation of filter in F#
let rec filter' f a =
    match a with
    | x::xs  -> if f x then x:: filter' f xs else filter' f xs
    | [] -> []