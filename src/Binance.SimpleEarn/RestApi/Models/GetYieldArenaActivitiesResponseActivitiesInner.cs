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

namespace Binance.SimpleEarn.RestApi;

public sealed class GetYieldArenaActivitiesResponseActivitiesInner
{
    /// <summary>Activity ID.</summary>
    [JsonPropertyName("activityId")]
    public long? ActivityId { get; set; }

    /// <summary>Activity category: AIRDROP, LEADERBOARD, or EVENT.</summary>
    [JsonPropertyName("activityType")]
    public string? ActivityType { get; set; }

    /// <summary>Activity title, localized via the lang header.</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>Activity description, localized via the lang header.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>USD value of the reward pool.</summary>
    [JsonPropertyName("rewardPoolInUsd")]
    public string? RewardPoolInUsd { get; set; }

    /// <summary>Reward token symbols (e.g. ["BNB"]); may be empty.</summary>
    [JsonPropertyName("rewardToken")]
    public List<string>? RewardToken { get; set; }

    /// <summary>Web URL to the activity landing page.</summary>
    [JsonPropertyName("redirectUrl")]
    public string? RedirectUrl { get; set; }

    /// <summary>
    /// Activity start time in milliseconds; may be null for activities that are immediately effective.
    /// </summary>
    [JsonPropertyName("startTime")]
    public long? StartTime { get; set; }

    /// <summary>Activity end time in milliseconds; may be null for activities with no fixed end.</summary>
    [JsonPropertyName("endTime")]
    public long? EndTime { get; set; }
}
