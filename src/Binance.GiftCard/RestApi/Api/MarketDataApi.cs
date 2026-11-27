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

namespace Binance.GiftCard.RestApi;

public sealed class CreateADualTokenGiftCardRequest
{
    /// <summary>The token you want to pay, example: BUSD</summary>
    public required string BaseToken { get; init; }

    /// <summary>
    /// The token you want to buy, example: BNB. If faceToken = baseToken, it's the same as createCode
    /// endpoint.
    /// </summary>
    public required string FaceToken { get; init; }

    /// <summary>The base token asset quantity, example : 1.002</summary>
    public required decimal BaseTokenAmount { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class CreateASingleTokenGiftCardRequest
{
    /// <summary>The token type contained in the Binance Gift Card</summary>
    public required string Token { get; init; }

    /// <summary>The amount of the token contained in the Binance Gift Card</summary>
    public required decimal Amount { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class FetchRsaPublicKeyRequest
{
    public long? RecvWindow { get; init; }
}

public sealed class FetchTokenLimitRequest
{
    /// <summary>The token you want to pay, example: BUSD</summary>
    public required string BaseToken { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class RedeemABinanceGiftCardRequest
{
    /// <summary>
    /// Redemption code of Binance Gift Card to be redeemed, supports both Plaintext &amp; Encrypted code.
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// Each external unique ID represents a unique user on the partner platform. The function helps you to
    /// identify the redemption behavior of different users, such as redemption frequency and amount. It
    /// also helps risk and limit control of a single account, such as daily limit on redemption volume,
    /// frequency, and incorrect number of entries. This will also prevent a single user account reach the
    /// partner's daily redemption limits. We strongly recommend you to use this feature and transfer us the
    /// User ID of your users if you have different users redeeming Binance Gift Cards on your platform. To
    /// protect user data privacy, you may choose to transfer the user id in any desired format (max. 400
    /// characters).
    /// </summary>
    public string? ExternalUid { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class VerifyBinanceGiftCardByGiftCardNumberRequest
{
    /// <summary>Enter the Gift Card Number</summary>
    public required string ReferenceNo { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class GiftCardRestApi
{

    /// <summary>Create a dual-token gift card (fixed value, discount feature) (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// - This API is for creating a dual-token ( stablecoin-denominated) Binance Gift Card. You may create
    /// a gift card
    /// </para>
    /// <para>
    /// using USDT as baseToken, that is redeemable to another designated token (faceToken). For example,
    /// you can create a fixed-value BTC gift card and pay with 100 USDT plus minting fee. This gift card
    /// can keep the value fixed at 100 USDT before redemption, and will be redeemable to BTC equivalent to
    /// 100 USDT upon redemption.
    /// </para>
    /// <para>
    /// - Once successfully created, the amount of baseToken (e.g. USDT) in the fixed-value gift card along
    /// with the fee
    /// </para>
    /// <para>would be deducted from your Spot wallet.</para>
    /// <para>- To get started with, please make sure:</para>
    /// <para>- You have a Binance account</para>
    /// <para>- You have passed KYB</para>
    /// <para>- You have a sufﬁcient balance(Gift Card amount and fee amount) in your Binance Spot wallet</para>
    /// <para>- You need Enable Withdrawals for the API Key which requests this endpoint.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CreateADualTokenGiftCardResponse>> CreateADualTokenGiftCardAsync(CreateADualTokenGiftCardRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/giftcard/buyCode", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CreateADualTokenGiftCardResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("baseToken", request.BaseToken);
        r.Query("faceToken", request.FaceToken);
        r.Query("baseTokenAmount", request.BaseTokenAmount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, GiftCardRestApiJson.Default.CreateADualTokenGiftCardResponse, cancellationToken);
    }

    /// <summary>Create a single-token gift card (USER_DATA)</summary>
    /// <remarks>
    /// <para>This API is for creating a Binance Gift Card.</para>
    /// <para>To get started with, please make sure:</para>
    /// <para>- You have a Binance account</para>
    /// <para>- You have passed KYB</para>
    /// <para>- You have a sufﬁcient balance(Gift Card amount and fee amount) in your Binance Spot wallet</para>
    /// <para>- You need Enable Withdrawals for the API Key which requests this endpoint.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CreateASingleTokenGiftCardResponse>> CreateASingleTokenGiftCardAsync(CreateASingleTokenGiftCardRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/giftcard/createCode", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<CreateASingleTokenGiftCardResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("token", request.Token);
        r.Query("amount", request.Amount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, GiftCardRestApiJson.Default.CreateASingleTokenGiftCardResponse, cancellationToken);
    }

    /// <summary>Fetch RSA Public Key (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// This API is for fetching the RSA Public Key. This RSA Public key will be used to encrypt the card
    /// code.
    /// </para>
    /// <para>Please note that the RSA Public key fetched is valid only for the current day.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FetchRsaPublicKeyResponse>> FetchRsaPublicKeyAsync(FetchRsaPublicKeyRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/giftcard/cryptography/rsa-public-key", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, GiftCardRestApiJson.Default.FetchRsaPublicKeyResponse, cancellationToken);
    }

    /// <summary>Fetch Token Limit (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// This API is to help you verify which tokens are available for you to create Stablecoin-Denominated
    /// gift cards as mentioned in section 2 and its’ limitation.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<FetchTokenLimitResponse>> FetchTokenLimitAsync(FetchTokenLimitRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/giftcard/buyCode/token-limit", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<FetchTokenLimitResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("baseToken", request.BaseToken);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, GiftCardRestApiJson.Default.FetchTokenLimitResponse, cancellationToken);
    }

    /// <summary>Redeem a Binance Gift Card (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// This API is for redeeming a Binance Gift Card. Once redeemed, the coins will be deposited in your
    /// Spot wallet.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Parameter code can be sent in two formats: Plaintext and Encrypted.</para>
    /// <para>- Sending code in encrypted format is more secure than plaintext.</para>
    /// <para>- To send encrypted code:</para>
    /// <para>- Fetch RSA public key from GET /sapi/v1/giftcard/cryptography/rsa-public-key.</para>
    /// <para>- Encrypt card code using RSA/ECB/OAEPWithSHA-256AndMGF1Padding.</para>
    /// <para>
    /// - If you enter the wrong redemption code 5 times within 24 hours, you will no longer be able to
    /// redeem any Binance Gift Cards that day.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<RedeemABinanceGiftCardResponse>> RedeemABinanceGiftCardAsync(RedeemABinanceGiftCardRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/giftcard/redeemCode", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<RedeemABinanceGiftCardResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("code", request.Code);
        r.Query("externalUid", request.ExternalUid);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, GiftCardRestApiJson.Default.RedeemABinanceGiftCardResponse, cancellationToken);
    }

    /// <summary>Verify Binance Gift Card by Gift Card Number (USER_DATA)</summary>
    /// <remarks>
    /// <para>
    /// This API is for verifying whether the Binance Gift Card is valid or not by entering Gift Card
    /// Number.
    /// </para>
    /// <para>
    /// **Please note that if you enter the wrong Gift Card Number 5 times within an hour, you will no
    /// longer be able to verify any Gift Card Number for that hour.**
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<VerifyBinanceGiftCardByGiftCardNumberResponse>> VerifyBinanceGiftCardByGiftCardNumberAsync(VerifyBinanceGiftCardByGiftCardNumberRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/giftcard/verify", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<VerifyBinanceGiftCardByGiftCardNumberResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("referenceNo", request.ReferenceNo);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, GiftCardRestApiJson.Default.VerifyBinanceGiftCardByGiftCardNumberResponse, cancellationToken);
    }
}
