// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.
open System.Collections.Generic


// === Solucion con Dictionaries ===

type Modelo = Nissan | Honda
let coches : IDictionary<Modelo,float> =
    [ 
        Nissan, 3.1; 
        Honda, 3.7; 
        Honda, 2.2
    ]
    |> dict
let getConsumoCoche modelo = coches.[modelo]
type Modelo with static member GetConsumo = getConsumoCoche

type Destino = Girona | Morella | Segovia | Perpignan
let destinos : IDictionary<Destino,float> =
    [ 
        Girona, 450.0; 
        Morella, 204.0; 
        Segovia, 441.0; 
        Perpignan, 532.0
    ]
    |> dict
let getDistanciaDestino destino = destinos.[destino]


let CosteGasolina = 2

let formula consumo distancia costeGasolina =
    consumo*distancia/100.0 * costeGasolina

let calculaCoste1 modelo destino = (formula (Modelo.GetConsumo Nissan) destinos.[destino] CosteGasolina)
let calculaCoste2 modelo destino = (formula (getConsumoCoche modelo) (getDistanciaDestino destino) CosteGasolina)

// === Solucion con Variables ===
//let Nissan = 3.1
//let Honda = 3.7
//let Girona = 450.0


// === Program ===

[<EntryPoint>]
let main argv =
    // Con dictionary
    
    printfn "Coste del viaje: %AEUR" (calculaCoste1 Nissan Girona)
    printfn "Coste del viaje: %AEUR" (calculaCoste2 Nissan Girona)
    // Con variables
    //printfn "asd: %A" (calcular_coste_gasolina Nissan Girona CosteGasolina)
    0 // return an integer exit code
