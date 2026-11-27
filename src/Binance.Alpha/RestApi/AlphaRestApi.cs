//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using Binance.Common;

namespace Binance.Alpha.RestApi;

/// <summary>
/// The Alpha Trading REST API client, with one method for each endpoint. Create it with Production (or another environment), or
/// from a <see cref="RestApiConfig"/>. Dispose it when done.
/// </summary>
public sealed partial class AlphaRestApi : IDisposable
{
    /// <summary>The production endpoint.</summary>
    public static readonly string ProductionUrl = BinanceUrls.AlphaRestApiProdUrl;

    private readonly RestApiClient _client;

    /// <summary>Creates a client; <see cref="RestApiConfig.BasePath"/> is required.</summary>
    /// <param name="config">The configuration, which is validated and copied.</param>
    /// <exception cref="BinanceConfigException">The configuration is invalid.</exception>
    public AlphaRestApi(RestApiConfig config)
    {
        ArgumentNullException.ThrowIfNull(config);
        _client = new RestApiClient(config with { TimeUnit = null }, "alpha", typeof(AlphaRestApi).Assembly);
    }

    /// <summary>Creates a client of the production environment.</summary>
    /// <param name="config">Credentials and options; the endpoint is set.</param>
    public static AlphaRestApi Production(RestApiConfig? config = null) =>
        new((config ?? new()) with { BasePath = ProductionUrl });

    /// <summary>Creates a client for the endpoint of the configuration (<c>BasePath</c>), or of production when it is empty.</summary>
    /// <param name="config">The configuration.</param>
    public static AlphaRestApi FromConfig(RestApiConfig config)
    {
        ArgumentNullException.ThrowIfNull(config);
        return new(string.IsNullOrEmpty(config.BasePath) ? config with { BasePath = ProductionUrl } : config);
    }

    /// <summary>
    /// Sends an unsigned request to any endpoint, for one that has no method yet, like <c>sendRequest</c> of the other connectors.
    /// Parameters are encoded as for the other methods.
    /// </summary>
    /// <param name="endpoint">The endpoint path, e.g. <c>/api/v3/time</c>.</param>
    /// <param name="method">The HTTP method, e.g. <see cref="HttpMethod.Get"/>.</param>
    /// <param name="query">Query parameters (null values are skipped).</param>
    /// <param name="body">Body parameters.</param>
    /// <param name="cancellationToken">Cancels the request.</param>
    /// <returns>The response, with the body as raw JSON.</returns>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public Task<RestApiResponse<JsonElement>> SendRequestAsync(string endpoint, HttpMethod method, IEnumerable<KeyValuePair<string, object?>>? query = null,
        IEnumerable<KeyValuePair<string, object?>>? body = null, CancellationToken cancellationToken = default) =>
        _client.SendRequestAsync(endpoint, method, query, body, signed: false, cancellationToken);

    /// <summary>As <c>SendRequestAsync</c>, with the body decoded by <paramref name="info"/>.</summary>
    /// <typeparam name="T">The type of the body.</typeparam>
    /// <param name="endpoint">The endpoint path, e.g. <c>/api/v3/time</c>.</param>
    /// <param name="method">The HTTP method, e.g. <see cref="HttpMethod.Get"/>.</param>
    /// <param name="info">Type info of the body, e.g. from the serializer context of the product.</param>
    /// <param name="query">Query parameters (null values are skipped).</param>
    /// <param name="body">Body parameters.</param>
    /// <param name="cancellationToken">Cancels the request.</param>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public Task<RestApiResponse<T>> SendRequestAsync<T>(string endpoint, HttpMethod method, System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> info,
        IEnumerable<KeyValuePair<string, object?>>? query = null, IEnumerable<KeyValuePair<string, object?>>? body = null, CancellationToken cancellationToken = default) =>
        _client.SendRequestAsync(endpoint, method, info, query, body, signed: false, cancellationToken);

    /// <summary>As <c>SendRequestAsync</c>, but signed: the timestamp and the signature are added.</summary>
    /// <param name="endpoint">The endpoint path, e.g. <c>/api/v3/account</c>.</param>
    /// <param name="method">The HTTP method, e.g. <see cref="HttpMethod.Get"/>.</param>
    /// <param name="query">Query parameters (null values are skipped).</param>
    /// <param name="body">Body parameters.</param>
    /// <param name="cancellationToken">Cancels the request.</param>
    /// <returns>The response, with the body as raw JSON.</returns>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public Task<RestApiResponse<JsonElement>> SendSignedRequestAsync(string endpoint, HttpMethod method, IEnumerable<KeyValuePair<string, object?>>? query = null,
        IEnumerable<KeyValuePair<string, object?>>? body = null, CancellationToken cancellationToken = default) =>
        _client.SendRequestAsync(endpoint, method, query, body, signed: true, cancellationToken);

    /// <summary>As <c>SendSignedRequestAsync</c>, with the body decoded by <paramref name="info"/>.</summary>
    /// <typeparam name="T">The type of the body.</typeparam>
    /// <param name="endpoint">The endpoint path, e.g. <c>/api/v3/account</c>.</param>
    /// <param name="method">The HTTP method, e.g. <see cref="HttpMethod.Get"/>.</param>
    /// <param name="info">Type info of the body, e.g. from the serializer context of the product.</param>
    /// <param name="query">Query parameters (null values are skipped).</param>
    /// <param name="body">Body parameters.</param>
    /// <param name="cancellationToken">Cancels the request.</param>
    /// <exception cref="BinanceException">The request failed (the task faults with the exception).</exception>
    public Task<RestApiResponse<T>> SendSignedRequestAsync<T>(string endpoint, HttpMethod method, System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> info,
        IEnumerable<KeyValuePair<string, object?>>? query = null, IEnumerable<KeyValuePair<string, object?>>? body = null, CancellationToken cancellationToken = default) =>
        _client.SendRequestAsync(endpoint, method, info, query, body, signed: true, cancellationToken);

    /// <summary>Frees the client; requests in flight end with <see cref="BinanceCancelledException"/>.</summary>
    public void Dispose() => _client.Dispose();
}
