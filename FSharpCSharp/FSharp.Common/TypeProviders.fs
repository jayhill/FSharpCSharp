module TypeProviders

open FSharp.Data

type FuelEconomyData = CsvProvider<"vehicles.csv">
let vehicleData = FuelEconomyData.Load("vehicles.csv")

vehicleData.Rows
|> Seq.filter (fun r -> r.Make = "Ford")
|> Seq.map (fun r -> r.MpgData)
|> Seq.iter (fun data -> System.Console.WriteLine(data))