module WinterInMere

// The idea is to practice using the systems implemented in my first published game
// Resources:
//    https://fsharpforfunandprofit.com/posts/correctness-exhaustive-pattern-matching/


// =================================
// Data
// =================================

type Item = Apple | Juice | Peanut | Water


// =================================
// Inventory
// =================================

type Entry = { Item : Item ; Quantity : int }
type ActiveInventory = {Items : Entry list}
type EmptyInventory = NoItems
// Is a FullInventory state necessary?

type Inventory =
    | Empty of EmptyInventory
    | Active of ActiveInventory


// =================================
// operations on empty state
// =================================

let addToEmpty item =
    Inventory.Active {Items = [item]}
    
// =================================
// operations on active state
// =================================

//let hasItem item = fun x -> x.Item = item
let hasItem list item = (List.exists (fun x -> x.Item = item) list)

let addToActiveForce state item =
    let newList = item :: state.Items
    Inventory.Active { state with Items = newList }

let addToActive state item =
    let newList = item :: state.Items
    match (hasItem state.Items item.Item) with
        | true -> 
            Inventory.Active state
        | false -> 
            Inventory.Active {state with Items = newList}

type EmptyInventory with
    member this.Add = addToEmpty

type ActiveInventory with
    member this.Add = addToActive this

    
// =================================
// operations on inventory
// =================================

let addItemToInventory (inventory:Inventory) item =
    match inventory with
    | Empty state -> state.Add item
    | Active state -> state.Add item

let displayInventory inventory =
    match inventory with
    | Empty state -> printfn "The inventory is empty"
    | Active state -> printfn "The inventory contains %A" state.Items

type Inventory with
    static member NewInventory = Inventory.Empty NoItems
    member this.Add = addItemToInventory this
    member this.Display = displayInventory this
    

// =================================
// testing
// =================================

let emptyInventory = Inventory.NewInventory
printf "\nempty="; emptyInventory.Display

let inventoryState1 = emptyInventory.Add {Item=Apple;Quantity=2}
printfn "\nstate1="; inventoryState1.Display

let add i q (x:Inventory) = x.Add {Item=i;Quantity=q}

let inventoryState2 = Inventory.NewInventory |> add Apple 2 |> add Peanut 3
printfn "\nstate2="; inventoryState2.Display
