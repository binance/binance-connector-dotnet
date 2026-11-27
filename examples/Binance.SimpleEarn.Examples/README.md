# Simple Earn examples

One runnable example for every endpoint, grouped like the API: `RestApi/<Tag>/<Operation>.cs`.

```bash
dotnet run --project examples/Binance.SimpleEarn.Examples -- RestApi/Bfusd/GetBfusdAccount
```

The examples target net10.0 and need the .NET 10 SDK (the library itself runs on net8.0 and later). Without an argument the project lists the examples. The examples read `API_KEY` and `API_SECRET` from the environment, and `BASE_PATH` (REST) to use another environment
(testnet, demo); the production endpoint is the default. An example that changes the account says so in a comment; use test keys. The examples that trade
run on the demo environment or the testnet, where the product has one, so that they place no real order.

Each file also has its own `Main`, so it can be started on its own with the `Example` property (the class of the example; build with `--no-incremental` when you change it on a project that is already built):

```bash
dotnet run --project examples/Binance.SimpleEarn.Examples -p:Example=Binance.SimpleEarn.Examples.RestApi.Bfusd.GetBfusdAccount
```
