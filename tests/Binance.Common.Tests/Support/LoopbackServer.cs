//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace Binance.Common.Tests;

/// <summary>A request the loopback server received.</summary>
/// <param name="Method">HTTP method.</param>
/// <param name="Url">Path and query, as sent.</param>
/// <param name="Body">The body.</param>
/// <param name="Headers">The headers, by case-insensitive name.</param>
public sealed record Seen(string Method, string Url, string Body, IReadOnlyDictionary<string, string> Headers)
{
    /// <summary>The path.</summary>
    public string Path => Url.Split('?')[0];

    /// <summary>The raw query string, or empty.</summary>
    public string Query => Url.Contains('?', StringComparison.Ordinal) ? Url[(Url.IndexOf('?', StringComparison.Ordinal) + 1)..] : "";

    /// <summary>The <c>X-MBX-APIKEY</c> header.</summary>
    public string? Key => Header("X-MBX-APIKEY");

    /// <summary>A header, or null.</summary>
    public string? Header(string name) => Headers.TryGetValue(name, out var value) ? value : null;

    /// <summary>A parameter of the query or of the form body, decoded, or null.</summary>
    public string? Param(string name) =>
        HttpUtility.ParseQueryString(Query)[name] ?? HttpUtility.ParseQueryString(Body)[name];
}

/// <summary>An HTTP server on a free loopback port that records the requests and answers with <c>reply</c>.</summary>
public sealed class Loopback : IDisposable
{
    private readonly HttpListener _listener = new();

    /// <summary>Starts the server.</summary>
    /// <param name="reply">Gets the request and returns the status and the body.</param>
    public Loopback(Func<Seen, (int Status, string Body)> reply)
    {
        for (var attempt = 1; ; attempt++)
        {
            var probe = new TcpListener(IPAddress.Loopback, 0);
            probe.Start();
            var port = ((IPEndPoint)probe.LocalEndpoint).Port;
            probe.Stop();
            _listener.Prefixes.Clear();
            _listener.Prefixes.Add($"http://127.0.0.1:{port}/");
            try
            {
                _listener.Start();
                Url = $"http://127.0.0.1:{port}";
                break;
            }
            catch (HttpListenerException) when (attempt < 20)
            {
            }
        }

        _ = Task.Run(async () =>
        {
            while (_listener.IsListening)
            {
                var ctx = await _listener.GetContextAsync();
                var request = ctx.Request;
                var headers = request.Headers.AllKeys.Where(k => k is not null).ToDictionary(k => k!, k => request.Headers[k]!, StringComparer.OrdinalIgnoreCase);
                var seen = new Seen(request.HttpMethod, request.Url!.PathAndQuery, await new StreamReader(request.InputStream).ReadToEndAsync(), headers);
                lock (Requests) Requests.Add(seen);
                var (status, body) = reply(seen);
                if (Delay > TimeSpan.Zero) await Task.Delay(Delay);
                foreach (var (name, value) in Headers) ctx.Response.Headers[name] = value;
                var bytes = Encoding.UTF8.GetBytes(body);
                ctx.Response.StatusCode = status;
                ctx.Response.ContentType = "application/json";
                ctx.Response.ContentLength64 = bytes.Length;
                await ctx.Response.OutputStream.WriteAsync(bytes);
                ctx.Response.Close();
            }
        });
    }

    /// <summary>The answer of Binance to a malformed request: HTTP 400 with the error code -1102.</summary>
    public static (int Status, string Body) BadRequest => (400, """{"code":-1102,"msg":"Mandatory parameter was not sent, was empty/null, or malformed."}""");

    /// <summary>The base URL.</summary>
    public string Url { get; }

    /// <summary>The requests received so far.</summary>
    public List<Seen> Requests { get; } = [];

    /// <summary>Headers added to every response.</summary>
    public Dictionary<string, string> Headers { get; } = [];

    /// <summary>How long the server waits before it answers.</summary>
    public TimeSpan Delay { get; set; }

    /// <inheritdoc/>
    public void Dispose() => _listener.Close();
}
