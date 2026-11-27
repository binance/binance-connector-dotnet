//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Binance.Common.Tests;

/// <summary>Checks that a model decoded from an example of the API documentation holds all of it.</summary>
public static class ExampleAssert
{
    /// <summary>The example fields the model does not declare, found so far (they are reported as warnings, not failures).</summary>
    public static IList<string> Warnings { get; } = new List<string>();

    private static readonly JsonSerializerOptions Options = new() { TypeInfoResolver = new DefaultJsonTypeInfoResolver() };

    /// <summary>
    /// Serializes <paramref name="model"/> and compares it with <paramref name="exampleJson"/>: every field of the example that the schema
    /// declares must be in the model with the same value (numbers and numbers written as strings compare as numbers); fields the schema
    /// does not declare are reported as warnings. Every oneOf in the model must also decode as one of its alternatives.
    /// </summary>
    /// <param name="exampleJson">The example.</param>
    /// <param name="model">The decoded model.</param>
    public static void Matches(string exampleJson, object? model)
    {
        Assert.NotNull(model);
        using var expected = JsonDocument.Parse(exampleJson);
        var actual = JsonSerializer.SerializeToElement(model, model.GetType(), Options);
        var problems = new List<string>();
        var undeclared = new List<string>();
        Compare(expected.RootElement, actual, "$", problems, undeclared);
        VisitOneOfs(model, problems, undeclared, "$");
        foreach (var field in undeclared.Distinct())
        {
            Console.WriteLine($"warning: the example has {field}, which the schema of the response does not declare");
            Warnings.Add(field);
        }
        Assert.True(problems.Count == 0, "The model does not hold the example:\n" + string.Join("\n", problems.Take(10)));
    }

    /// <summary>The types of the models the checked examples were decoded into (including oneOf alternatives); for coverage reports.</summary>
    public static ISet<Type> VisitedTypes { get; } = new HashSet<Type>();

    private static void VisitOneOfs(object? model, List<string> problems, List<string> undeclared, string path, int depth = 0)
    {
        if (model is null || depth > 40) return;
        var type = model.GetType();
        if (model is string || type.IsPrimitive || type.IsEnum || type == typeof(decimal) || model is JsonElement || model is IWireValue) return;
        lock (VisitedTypes) VisitedTypes.Add(type);
        if (model is OneOf oneOf)
        {
            if (oneOf.Json.ValueKind == JsonValueKind.Null) return;
            // The alternative that holds all of the JSON, or else the one whose declared fields match and that leaves out the fewest.
            object? best = null;
            var leastUndeclared = int.MaxValue;
            if (oneOf.TryGetValue(out var exact)) { best = exact; leastUndeclared = 0; }
            else
            {
                foreach (var alternative in oneOf.AlternativeTypes)
                {
                    var value = oneOf.As(alternative);
                    if (value is null) continue;
                    var inner = new List<string>();
                    var left = new List<string>();
                    Compare(oneOf.Json, JsonSerializer.SerializeToElement(value, value.GetType(), Options), path, inner, left);
                    if (inner.Count == 0 && left.Count < leastUndeclared) { best = value; leastUndeclared = left.Count; }
                }
            }
            if (best is null) problems.Add($"{path}: no alternative of {type.Name} matches {Trim(oneOf.Json.GetRawText())}");
            else
            {
                lock (VisitedTypes) VisitedTypes.Add(best.GetType());
                var left = new List<string>();
                Compare(oneOf.Json, JsonSerializer.SerializeToElement(best, best.GetType(), Options), path, new List<string>(), left);
                undeclared.AddRange(left);
                VisitOneOfs(best, problems, undeclared, path, depth + 1);
            }
            return;
        }
        if (model is System.Collections.IDictionary dictionary)
        {
            foreach (var item in dictionary.Values) VisitOneOfs(item, problems, undeclared, path + "{}", depth + 1);
            return;
        }
        if (model is System.Collections.IEnumerable items)
        {
            var i = 0;
            foreach (var item in items) VisitOneOfs(item, problems, undeclared, $"{path}[{i++}]", depth + 1);
            return;
        }
        foreach (var property in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Where(p => p.GetIndexParameters().Length == 0 && p.GetCustomAttributes(typeof(System.Text.Json.Serialization.JsonIgnoreAttribute), true).Length == 0))
            VisitOneOfs(property.GetValue(model), problems, undeclared, $"{path}.{property.Name}", depth + 1);
    }

    private static string Trim(string text) => text.Length > 200 ? text[..200] + "..." : text;

    private static void Compare(JsonElement expected, JsonElement actual, string path, List<string> problems, List<string> undeclared)
    {
        switch (expected.ValueKind)
        {
            case JsonValueKind.Null:
                return;
            case JsonValueKind.Object:
                if (actual.ValueKind != JsonValueKind.Object) { problems.Add($"{path}: expected an object, got {actual.ValueKind}"); return; }
                foreach (var property in expected.EnumerateObject())
                {
                    if (!actual.TryGetProperty(property.Name, out var value)) undeclared.Add($"{System.Text.RegularExpressions.Regex.Replace(path, @"\[\d+\]", "[]")}.{property.Name}");
                    else Compare(property.Value, value, $"{path}.{property.Name}", problems, undeclared);
                }
                return;
            case JsonValueKind.Array:
                if (actual.ValueKind != JsonValueKind.Array) { problems.Add($"{path}: expected an array, got {actual.ValueKind}"); return; }
                if (actual.GetArrayLength() != expected.GetArrayLength()) { problems.Add($"{path}: expected {expected.GetArrayLength()} items, got {actual.GetArrayLength()}"); return; }
                for (var i = 0; i < expected.GetArrayLength(); i++) Compare(expected[i], actual[i], $"{path}[{i}]", problems, undeclared);
                return;
            case JsonValueKind.True or JsonValueKind.False:
                if (actual.ValueKind != expected.ValueKind) problems.Add($"{path}: expected {expected.ValueKind}, got {actual.ValueKind}");
                return;
            default:
                if (!SameScalar(expected, actual)) problems.Add($"{path}: expected {expected}, got {actual}");
                return;
        }
    }

    private static bool SameScalar(JsonElement expected, JsonElement actual)
    {
        if (expected.ValueKind == JsonValueKind.String && actual.ValueKind == JsonValueKind.String) return expected.GetString() == actual.GetString();
        return decimal.TryParse(expected.ToString(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var e)
            && decimal.TryParse(actual.ToString(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var a)
            && e == a;
    }
}
