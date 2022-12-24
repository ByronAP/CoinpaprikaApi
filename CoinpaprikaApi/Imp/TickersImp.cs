// ***********************************************************************
// Assembly         : CoinpaprikaApi
// Author           : ByronAP
// Created          : 12-23-2022
//
// Last Modified By : ByronAP
// Last Modified On : 12-23-2022
// ***********************************************************************
// <copyright file="TickersImp.cs" company="ByronAP">
//     Copyright © 2022 ByronAP, Coinpaprika. All rights reserved.
// </copyright>
// ***********************************************************************

using CoinpaprikaApi.Models;
using CoinpaprikaApi.Types;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinpaprikaApi.Imp
{
    /// <summary>
    /// <para>Implementation of the '/tickers' API calls.</para>
    /// <para>Implementation classes do not have a public constructor
    /// and must be accessed through an instance of <see cref="CoinpaprikaClient"/>.</para>
    /// </summary>
    /// <seealso href="https://api.coinpaprika.com/#tag/Tickers"/>
    public class TickersImp
    {
        private readonly RestClient _restClient;
        private readonly ILogger<CoinpaprikaClient> _logger;
        private readonly MemCache _cache;

        internal TickersImp(RestClient restClient, MemCache cache, ILogger<CoinpaprikaClient> logger)
        {
            _logger = logger;
            _cache = cache;
            _restClient = restClient;
        }

        /// <summary>
        /// Get price data of all active cryptocurrencies. Free plan is limited to 2500 results.
        /// </summary>
        /// <param name="quotes">A list of quotes to return. Up to 3 quotes at once. Currently allowed values: BTC, ETH, USD, EUR, PLN, KRW, GBP, CAD, JPY, RUB, TRY, NZD, AUD, CHF, UAH, HKD, SGD, NGN, PHP, MXN, BRL, THB, CLP, CNY, CZK, DKK, HUF, IDR, ILS, INR, MYR, NOK, PKR, SEK, TWD, ZAR, VND, BOB, COP, PEN, ARS, ISK. Default: USD</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Tickers/operation/getTickers"/>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="TickerItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        public async Task<IEnumerable<TickerItem>> GetTickersAsync(IEnumerable<string> quotes = null)
        {
            if (quotes != null && quotes.Count() > 3) { quotes = quotes.Take(3); };

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("tickers"));

            if (quotes != null) { request.AddParameter("quotes", string.Join(",", quotes)); }

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 150);

            return JsonConvert.DeserializeObject<IEnumerable<TickerItem>>(jsonStr);
        }

        /// <summary>
        /// Get price data of a single cryptocurrency.
        /// </summary>
        /// <param name="coin_id">The coin identifier (ex: btc-bitcoin).</param>
        /// <param name="quotes">A list of quotes to return. Up to 3 quotes at once. Currently allowed values: BTC, ETH, USD, EUR, PLN, KRW, GBP, CAD, JPY, RUB, TRY, NZD, AUD, CHF, UAH, HKD, SGD, NGN, PHP, MXN, BRL, THB, CLP, CNY, CZK, DKK, HUF, IDR, ILS, INR, MYR, NOK, PKR, SEK, TWD, ZAR, VND, BOB, COP, PEN, ARS, ISK. Default: USD</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Tickers/operation/getTickersById"/>
        /// <returns>A Task&lt;<see cref="TickerItem"/>&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">coin_id - Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)</exception>
        public async Task<TickerItem> GetTickerAsync(string coin_id, IEnumerable<string> quotes = null)
        {
            if (string.IsNullOrEmpty(coin_id) || string.IsNullOrWhiteSpace(coin_id)) { throw new ArgumentNullException(nameof(coin_id), "Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)"); }

            if (quotes != null && quotes.Count() > 3) { quotes = quotes.Take(3); };

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("tickers", coin_id));

            if (quotes != null) { request.AddParameter("quotes", string.Join(",", quotes)); }

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 150);

            return JsonConvert.DeserializeObject<TickerItem>(jsonStr);
        }

        /// <summary>
        /// Get historical values of price, volume_24h, market_cap for a given cryptocurrency.
        /// </summary>
        /// <param name="coin_id">The coin identifier (ex: btc-bitcoin).</param>
        /// <param name="start">The start start point for historical data.</param>
        /// <param name="end">The end point for for historical data.</param>
        /// <param name="limit">The limit of result rows (max 5000). Default: 1000</param>
        /// <param name="quote_btc">Set to <c>true</c> to use BTC as quote currency, else quote is USD.</param>
        /// <param name="interval">The bucket interval.</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Tickers/operation/getTickersHistoricalById"/>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="TickItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">coin_id - Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">end - Invalid value, end must be a valid date after start.</exception>
        public async Task<IEnumerable<TickItem>> GetHistoricalTicksAsync(string coin_id, DateTimeOffset start, DateTimeOffset? end = null, uint limit = 1000, bool quote_btc = false, TickerInterval interval = TickerInterval.m5)
        {
            if (string.IsNullOrEmpty(coin_id) || string.IsNullOrWhiteSpace(coin_id)) { throw new ArgumentNullException(nameof(coin_id), "Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)"); }

            if (end != null && end <= start) { throw new ArgumentOutOfRangeException(nameof(end), "Invalid value, end must be a valid date after start."); }

            if (end != null && end > DateTimeOffset.UtcNow) { end = null; }

            if (limit > 5000) { limit = 5000; }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("tickers", coin_id, "historical"));

            request.AddParameter("start", start.ToUnixTimeSeconds());
            if (end != null) { request.AddParameter("end", end.Value.ToUnixTimeSeconds()); }
            if (limit != 1000 && limit != 0) { request.AddParameter("limit", limit); }
            if (quote_btc) { request.AddParameter("quote", "btc"); }
            request.AddParameter("interval", interval.ToAPIString());

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 150);

            return JsonConvert.DeserializeObject<IEnumerable<TickItem>>(jsonStr);
        }
    }
}
