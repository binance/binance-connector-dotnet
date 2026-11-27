//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Common;

/// <summary>A value the API names with a string.</summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public interface IWireValue
{
    /// <summary>The string the API sends and expects.</summary>
    string Value { get; }
}

/// <summary>
/// An extensible enum: a string-backed struct with a static member for each value the SDK knows. A value
/// the API adds later is still read, kept and sent back unchanged, instead of failing.
/// </summary>
/// <typeparam name="TSelf">The struct itself.</typeparam>
public interface IExtensibleValue<TSelf> : IWireValue
    where TSelf : struct, IExtensibleValue<TSelf>
{
    /// <summary>Creates the value for <paramref name="value"/>, known or not.</summary>
    static abstract TSelf Create(string value);
}

/// <summary>Reads and writes an <see cref="IExtensibleValue{TSelf}"/> as its string.</summary>
/// <typeparam name="T">The extensible enum.</typeparam>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public sealed class ExtensibleValueConverter<T> : JsonConverter<T>
    where T : struct, IExtensibleValue<T>
{
    /// <inheritdoc/>
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        T.Create(reader.TokenType == JsonTokenType.String ? reader.GetString()! : JsonElement.ParseValue(ref reader).GetRawText());

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) => writer.WriteStringValue(value.Value);
}
