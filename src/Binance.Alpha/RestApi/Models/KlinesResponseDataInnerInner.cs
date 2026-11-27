//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;
using Binance.Common;

namespace Binance.Alpha.RestApi;

[JsonConverter(typeof(OneOfConverter<KlinesResponseDataInnerInner>))]
public sealed class KlinesResponseDataInnerInner : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => AlphaRestApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(string), typeof(long)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;
}
