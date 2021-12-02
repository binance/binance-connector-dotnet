open System
open System.Net
open System.Net.Http
open System.Threading;
open System.Threading.Tasks
open Microsoft.Extensions.Logging
open Binance.Common
open Binance.Spot
open Binance.Spot.Models
open Newtonsoft.Json.Linq

[<EntryPoint>]
let main argv =
    let loggerFactory = LoggerFactory.Create(fun (builder:ILoggingBuilder) -> 
        builder.AddConsole() |> ignore
    )
    let logger = loggerFactory.CreateLogger()

    let loggingHandler = new BinanceLoggingHandler(logger)
    let httpClient = new HttpClient(loggingHandler)

    let apiKey = "vmPUZE6mv9SD5VNHk4HlWFsOr6aKE2zvsw0MuIgwCIPy6utIco14y7Ju91duEh8A";
    let apiSecret = "NhqPtmdSJYdKjVHjA7PZj4Mge3R5YNiP1e3UZjInClVN65XAbvqqM6A7H5fATj0j";
    
    let userDataStreams = new UserDataStreams(httpClient, apiKey = apiKey, apiSecret = apiSecret)
    let response = userDataStreams.CreateSpotListenKey() |> Async.AwaitTask |> Async.RunSynchronously
    let listenKey = JObject.Parse(response).SelectToken("listenKey") |> string

    let websocket = new UserDataWebSocket(listenKey);

    let onlyOneMessage = new TaskCompletionSource<string>();
    websocket.OnMessageReceived(
        (fun data ->
            onlyOneMessage.SetResult(data)
            Task.CompletedTask)
    , CancellationToken.None);
    websocket.ConnectAsync(CancellationToken.None) |> Async.AwaitTask |> Async.RunSynchronously

    let message = onlyOneMessage.Task |> Async.AwaitTask |> Async.RunSynchronously
    logger.LogInformation(message);
    websocket.DisconnectAsync(CancellationToken.None) |> Async.AwaitTask |> Async.RunSynchronously
    
    0