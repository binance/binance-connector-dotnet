open System
open System.Net
open System.Net.Http
open System.Threading.Tasks
open Microsoft.Extensions.Logging
open Binance.Common
open Binance.Spot
open Binance.Spot.Models

[<EntryPoint>]
let main argv =
    let loggerFactory = LoggerFactory.Create(fun (builder:ILoggingBuilder) -> 
        builder.AddConsole() |> ignore
    )
    let logger = loggerFactory.CreateLogger()

    let loggingHandler = new BinanceLoggingHandler(logger)
    let httpClient = new HttpClient(loggingHandler)

    let apiKey = "api-key";
    let apiSecret = "api-secret";
    
    let subAccount = new SubAccount(httpClient, apiKey, apiSecret)
    
    let result = subAccount.FuturesTransferForSubaccount("testaccount@email.com", "BTC", 1.01m, FuturesTransferType.SPOT_TO_USDT_MARGINED_FUTURES) |> Async.AwaitTask |> Async.RunSynchronously
    
    0
