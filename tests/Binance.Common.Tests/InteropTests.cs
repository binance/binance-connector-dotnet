//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Reflection;

namespace Binance.Common.Tests;

// The structs must have the layout binance_c.h documents (and the native library asserts): a mismatch corrupts memory
// silently, typically only on the 32-bit platforms.
public class InteropLayoutTests
{
    [Fact]
    public unsafe void TheErrorRecordHasTheLayoutOfTheHeader()
    {
        BncError e = default;
        var start = (byte*)&e;
        Assert.Equal(600, sizeof(BncError));
        Assert.Equal(0, (byte*)&e.Kind - start);
        Assert.Equal(4, (byte*)&e.HttpStatus - start);
        Assert.Equal(8, (byte*)&e.HasCode - start);
        Assert.Equal(12, (byte*)&e.Reserved0 - start);
        Assert.Equal(16, (byte*)&e.Code - start);
        Assert.Equal(24, (byte*)&e.RetryAfterSeconds - start);
        Assert.Equal(32, (byte*)&e.RetryAtMs - start);
        Assert.Equal(40, (byte*)&e.TransportCode - start);
        Assert.Equal(44, e.TransportCategory - start);
        Assert.Equal(76, (byte*)&e.RequestSent - start);
        Assert.Equal(80, e.Message - start);
        Assert.Equal(592, (byte*)&e.WsKind - start);
        Assert.Equal(596, (byte*)&e.Reserved1 - start);
    }

    [Fact]
    public unsafe void TheOtherStructsFollowThePointerSize()
    {
        var p = sizeof(nint);

        BncRestResponse r = default;
        var rs = (byte*)&r;
        Assert.Equal(5 * p, sizeof(BncRestResponse));
        Assert.Equal(0, (byte*)&r.Status - rs);
        Assert.Equal(p, (byte*)&r.Body - rs);
        Assert.Equal(2 * p, (byte*)&r.BodyLen - rs);
        Assert.Equal(3 * p, (byte*)&r.HeadersJson - rs);
        Assert.Equal(4 * p, (byte*)&r.RateLimitsJson - rs);

        BncClientOptions o = default;
        var os = (byte*)&o;
        Assert.Equal(5 * p, sizeof(BncClientOptions));
        Assert.Equal(0, (byte*)&o.StructSize - os);
        Assert.Equal(p, (byte*)&o.TlsVerify - os);
        Assert.Equal(2 * p, (byte*)&o.TlsVerifyData - os);
        Assert.Equal(3 * p, (byte*)&o.Timestamp - os);
        Assert.Equal(4 * p, (byte*)&o.TimestampData - os);
    }
}

// Alone: it moves the shared id counter.
[CollectionDefinition(nameof(RegistryTests), DisableParallelization = true)]
public class RegistryCollection { }

[Collection(nameof(RegistryTests))]
public class RegistryTests
{
    private static readonly FieldInfo Next =
        typeof(Registry).GetField("_next", BindingFlags.NonPublic | BindingFlags.Static)!;

    // Negative ids are reached only by wrapping around, so no other entry can hold them here.
    [Fact]
    public void IdsSurviveTheWrapAroundOfTheCounter()
    {
        var saved = (long)Next.GetValue(null)!;
        try
        {
            // The next ids are -1, then 0, which means "no id" and is skipped.
            Next.SetValue(null, -2L);
            var a = new object();
            var b = new object();
            var idA = Registry.Add(a);
            var idB = Registry.Add(b);
            Assert.Equal(-1, idA);
            Assert.True(idB > 0);
            Assert.Same(a, Registry.Get<object>(idA));
            Assert.Same(b, Registry.Take<object>(idB));
            Assert.Null(Registry.Get<object>(idB));
            Registry.Remove(idA);

            // An id still in use is not handed out again.
            Next.SetValue(null, -100L);
            var held = Registry.Add(a);
            Next.SetValue(null, -100L);
            var other = Registry.Add(b);
            Assert.Equal(-99, held);
            Assert.Equal(-98, other);
            Assert.Same(a, Registry.Get<object>(held));
            Assert.Same(b, Registry.Get<object>(other));
            Registry.Remove(held);
            Registry.Remove(other);
        }
        finally
        {
            Next.SetValue(null, saved);
        }
    }
}
