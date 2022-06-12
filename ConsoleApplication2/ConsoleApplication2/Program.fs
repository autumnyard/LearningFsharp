// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.
open System.IO
open System.Data
open Donald


type Almacen = {Id:int; Nombre:string}
type Tela = {Id:int; Nombre:string; Almacen:int}

module Almacen =
    let ofDataReader (rd : IDataReader) : Almacen =
        { Id = rd.ReadInt32 "almacen_id";
            Nombre = rd.ReadString "nombre" }

[<EntryPoint>]
let main argv =
    printfn "Init"

    let path = "C:/Dev/fsharp/swingstring.sqlite"
    File.Exists path |> printfn "Trying to open DB file: %A"

    let command1 = "SELECT * FROM Almacenes"
    let command2 = "INSERT INTO Almacenes"

    Db.query command1
    0 // return an integer exit code
