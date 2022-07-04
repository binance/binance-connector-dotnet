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
    
    let spotAccountTrade = new SpotAccountTrade(httpClient, apiKey = apiKey, apiSecret = apiSecret)
    
    let result = spotAccountTrade.CancelAnExistingOrderAndSendANewOrder("BNBUSDT", Side.SELL, OrderType.LIMIT, "STOP_ON_FAILURE", cancelOrderId = 12, timeInForce = TimeInForce.GTC, quantity = 10.1m, price = 295.92m) |> Async.AwaitTask |> Async.RunSynchronously
    
    0
