//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

namespace Binance.Common.Tests;

/// <summary>Keys for the tests. They are not credentials of any account.</summary>
public static class TestKeys
{
    /// <summary>A throwaway Ed25519 private key (PEM), for <c>session.logon</c>.</summary>
    public const string Ed25519Pem = """
        -----BEGIN PRIVATE KEY-----
        MC4CAQAwBQYDK2VwBCIEIPc4pKWmf6KsUErY12H7uz2L+kcByE1EXHzBPzLpd2Ez
        -----END PRIVATE KEY-----
        """;
}
