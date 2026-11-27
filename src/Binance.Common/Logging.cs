//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace Binance.Common;

/// <summary>The level of the log of the connector.</summary>
public enum BinanceLogLevel
{
    /// <summary>Everything, including requests.</summary>
    Debug = 0,
    /// <summary>Connections and lifecycle.</summary>
    Information = 1,
    /// <summary>Problems that were handled (the default).</summary>
    Warning = 2,
    /// <summary>Failures.</summary>
    Error = 3,
    /// <summary>Nothing.</summary>
    None = 4,
}

/// <summary>
/// Routes the log of the connectors to <see cref="ILogger"/>. The log is process-wide and shared by every client, so configure it
/// once, not per client. Until it is configured, warnings and errors are written to stderr (set the <c>LOG_LEVEL</c> environment
/// variable to <c>debug</c>, <c>info</c>, <c>warn</c>, <c>error</c> or <c>none</c> to change that).
/// </summary>
public static unsafe class BinanceLogging
{
    private static ILogger? _logger;
    private static BinanceLogLevel _level = BinanceLogLevel.Warning;

    /// <summary>
    /// Sends the log to a logger named <c>Binance.Common</c> of <paramref name="factory"/>. The level is
    /// the lowest one the logger has enabled, so nothing is formatted that would be dropped. <c>null</c> sends the log to stderr
    /// again; the level stays as it is (see <see cref="SetLevel"/>).
    /// </summary>
    /// <param name="factory">The logger factory, or <c>null</c> for the stderr output.</param>
    public static void Configure(ILoggerFactory? factory)
    {
        Interop.Check();
        if (factory is null)
        {
            Native.bnc_set_log_callback(null, 0);
            _logger = null;
            return;
        }
        var logger = factory.CreateLogger("Binance.Common");
        _logger = logger;
        Native.bnc_set_log_callback(&OnLog, 0);
        Native.bnc_set_log_level(logger.IsEnabled(LogLevel.Debug) ? 0 : logger.IsEnabled(LogLevel.Information) ? 1 : logger.IsEnabled(LogLevel.Warning) ? 2 : logger.IsEnabled(LogLevel.Error) ? 3 : 4);
    }

    // A warning raised in managed code: to the logger when there is one, otherwise to stderr in the format of the native log.
    internal static void Warn(string message)
    {
        if (_logger is { } logger) logger.Log(LogLevel.Warning, default, message, null, static (text, _) => text);
        else if (_level <= BinanceLogLevel.Warning) Console.Error.WriteLine($"[binance] [WARN] {message}");
    }

    /// <summary>Sets the level of the log. <see cref="Configure"/> replaces it with the level of its logger.</summary>
    /// <param name="level">The lowest level that is logged.</param>
    public static void SetLevel(BinanceLogLevel level)
    {
        Interop.Check();
        _level = level;
        Native.bnc_set_log_level((int)level);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void OnLog(nint user, int level, byte* message, nuint length)
    {
        try
        {
            var logger = _logger;
            if (logger is null) return;
            var mapped = level switch { 0 => LogLevel.Debug, 1 => LogLevel.Information, 2 => LogLevel.Warning, _ => LogLevel.Error };
            if (!logger.IsEnabled(mapped)) return;
            logger.Log(mapped, default, Interop.Utf8(message, length), null, static (text, _) => text);
        }
        catch (Exception)
        {
            // A failing logger must not unwind into native code; there is nowhere left to report it.
        }
    }
}
