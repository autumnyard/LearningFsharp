module ListExists


// =================================
// Inventory
// =================================

// Working out a complex Contains/Exists, that works with complex types
type Item = Apple | Juice | Peanut | Water
type Entry = { Item : Item ; Quantity : int }
let hasItem list item = (List.exists (fun x -> x.Item = item) list)

let test1 = [1 ; 3 ; 5]
printfn "Test1 Correct %b" (List.exists ((=)3) test1)
printfn "Test1 Wrong %b" (List.exists ((=)4) test1)

let test2 = [ Apple; Water]
printfn "Test2 Correct %b" (List.exists ((=)Apple) test2)
printfn "Test2 Wrong %b" (List.exists ((=)Peanut) test2)

let test3 = [ {Item = Apple ; Quantity = 2} ; {Item = Water ; Quantity = 4} ]
//printfn "Test3 Correct %b" (List.exists (fun x -> x.Item = Apple) test3)
printfn "Test3 Correct %b" (hasItem test3 Apple)
//printfn "Test3 Wrong %b" (List.exists (fun x -> x.Item = Peanut) test3)
//printfn "Test3 Wrong %b" (List.exists (hasItem Peanut) test3)
printfn "Test3 Wrong %b" (hasItem test3 Peanut)

