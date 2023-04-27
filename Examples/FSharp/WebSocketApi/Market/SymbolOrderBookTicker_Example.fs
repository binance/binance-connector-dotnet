open System
open System.Collections.Generic
open System.Net
open System.Net.Http
open System.Threading;
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

    let websocket = new WebSocketApi();

    let onlyOneMessage = new TaskCompletionSource<string>();

    websocket.OnMessageReceived(
        (fun data ->
            onlyOneMessage.SetResult(data)
            Task.CompletedTask)
    , CancellationToken.None);

    websocket.ConnectAsync(CancellationToken.None) |> Async.AwaitTask |> Async.RunSynchronously

    let symbols = [| "BNBUSDT"; "BTCUSDT" |]
    websocket.Market.SymbolOrderBookTickerAsync(symbols = symbols, cancellationToken = CancellationToken.None) |> Async.AwaitTask |> Async.RunSynchronously

    let message = onlyOneMessage.Task |> Async.AwaitTask |> Async.RunSynchronously

    logger.LogInformation(message);

    websocket.DisconnectAsync(CancellationToken.None) |> Async.AwaitTask |> Async.RunSynchronously
    
    0
