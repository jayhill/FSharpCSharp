module TypeProviders

open FSharp.Data

// Type providers generate types that are accessible -- with Intellisense -- in F# files in VS and in FSI (REPL).
// This makes consuming data very easy and powerful.
// However, it is often not possible to consume these types from C#. Many type providers are "erasing" type providers,
// there the types are transient.

type FuelEconomyData = CsvProvider<"vehicles.csv">
let vehicleData = FuelEconomyData.Load("vehicles.csv")

// Example of consuming strongly typed row data from a CSV
vehicleData.Rows
|> Seq.filter (fun r -> r.Make = "Ford")
|> Seq.map (fun r -> r.MpgData)
|> Seq.iter (fun data -> System.Console.WriteLine(data))

// If you acces vehicleData in C#, you can access rows, etc., but they are represented as
// multiply nested Tuples and are effectively useless.