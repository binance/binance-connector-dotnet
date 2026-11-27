//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Binance.Common;

/// <summary>The <c>User-Agent</c> of the connectors: <c>binance-connector-dotnet/&lt;product&gt;/&lt;version&gt; (.NET/&lt;runtime&gt;; &lt;os&gt;; &lt;arch&gt;)</c>.</summary>
public static partial class BinanceUserAgent
{
    // Set by the command line tools and skills of Binance, which name themselves in the same format.
    private const string OverrideVariable = "BINANCE_CONNECTOR_DOTNET_USER_AGENT";

    [GeneratedRegex(@"^binance-(?:cli|skill)(?:/[A-Za-z0-9._-]+){0,2} \([^;()]+; [^;()]+; [^;()]+\)$")]
    private static partial Regex OverridePattern();

    /// <summary>Builds the user agent of a product package.</summary>
    /// <param name="product">The product, e.g. <c>spot</c>.</param>
    /// <param name="assembly">The assembly of the product package, whose version is used.</param>
    public static string Build(string product, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(product);
        ArgumentNullException.ThrowIfNull(assembly);
        var overridden = Environment.GetEnvironmentVariable(OverrideVariable)?.Trim();
        if (overridden is not null && OverridePattern().IsMatch(overridden)) return overridden;
        var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? assembly.GetName().Version?.ToString() ?? "0.0.0";
        var os = OperatingSystem.IsWindows() ? "windows" : OperatingSystem.IsMacOS() ? "macos" : OperatingSystem.IsLinux() ? "linux" : "other";
        return $"binance-connector-dotnet/{product}/{version.Split('+')[0]} (.NET/{Environment.Version}; {os}; {RuntimeInformation.ProcessArchitecture.ToString().ToLowerInvariant()})";
    }

    internal static T WithDefault<T>(T config, string? product, Assembly? assembly) where T : ConnectorConfig =>
        config.UserAgent is not null ? config
        : config with { UserAgent = product is null || assembly is null ? Build("common", typeof(ConnectorConfig).Assembly) : Build(product, assembly) };
}
