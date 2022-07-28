// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.
open System.Collections.Generic



// === Solucion con Dictionaries ===

type Modelo = Nissan | Honda
let cuchos : IDictionary<Modelo,float> =
    [ Nissan, 3.1; Honda, 3.7; Honda, 2.2]
    |> dict

type Destino = Girona | Morella | Segovia | Perpignan
let destinos : IDictionary<Destino,float> =
    [ Girona, 450.0; Morella, 204.0; Segovia, 441.0; Perpignan, 532.0]
    |> dict

let CosteGasolina = 2

let calcular_coste_gasolina consumo distancia costeGasolina =
    consumo*distancia/100.0 * costeGasolina


// === Solucion con Variables ===


// === Program ===

[<EntryPoint>]
let main argv =
    printfn "asd: %A" (calcular_coste_gasolina cuchos.[Nissan] destinos.[Girona] CosteGasolina)
    0 // return an integer exit code
