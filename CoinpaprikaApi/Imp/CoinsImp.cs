// ***********************************************************************
// Assembly         : CoinpaprikaApi
// Author           : ByronAP
// Created          : 12-18-2022
//
// Last Modified By : ByronAP
// Last Modified On : 12-24-2022
// ***********************************************************************
// <copyright file="CoinsImp.cs" company="ByronAP">
//     Copyright © 2022 ByronAP, Coinpaprika. All rights reserved.
// </copyright>
// ***********************************************************************
using CoinpaprikaApi.Models;
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
    /// <para>Implementation of the '/coins' API calls.</para>
    /// <para>Implementation classes do not have a public constructor
    /// and must be accessed through an instance of <see cref="CoinpaprikaClient"/>.</para>
    /// </summary>
    /// <seealso href="https://api.coinpaprika.com/#tag/Coins"/>
    public class CoinsImp
    {
        private readonly RestClient _restClient;
        private readonly ILogger<CoinpaprikaClient> _logger;
        private readonly MemCache _cache;

        internal CoinsImp(RestClient restClient, MemCache cache, ILogger<CoinpaprikaClient> logger)
        {
            _logger = logger;
            _cache = cache;
            _restClient = restClient;
        }

        /// <summary>
        /// Get basic information about cryptocurrencies as an asynchronous operation.
        /// </summary>
        /// <seealso href="https://api.coinpaprika.com/#tag/Coins/paths/~1coins/get"/>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="CoinItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        public async Task<IEnumerable<CoinItem>> GetCoinsAsync()
        {
            var request = new RestRequest(CoinpaprikaClient.BuildUrl("coins"));

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 90);

            return JsonConvert.DeserializeObject<IEnumerable<CoinItem>>(jsonStr);
        }

        /// <summary>
        /// Get detailed descriptive information about a single coin as an asynchronous operation, without price or volume data. For price data, check the /tickers and /tickers/{coin_id} endpoints.
        /// </summary>
        /// <param name="coin_id">The coin identifier (ex: btc-bitcoin).</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Coins/operation/getCoinById"/>
        /// <returns>A Task&lt;<see cref="CoinResponse"/>&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">coin_id - Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)</exception>
        public async Task<CoinResponse> GetCoinAsync(string coin_id)
        {
            if (string.IsNullOrEmpty(coin_id) || string.IsNullOrWhiteSpace(coin_id)) { throw new ArgumentNullException(nameof(coin_id), "Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)"); }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("coins", coin_id));

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 90);

            return JsonConvert.DeserializeObject<CoinResponse>(jsonStr);
        }


        /// <summary>
        /// Get the last 50 timeline tweets from the official Twitter profile for a given coin..
        /// </summary>
        /// <param name="coin_id">The coin identifier (ex: btc-bitcoin).</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Coins/paths/~1coins~1%7Bcoin_id%7D~1twitter/get"/>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="CoinTweetItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">coin_id - Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)</exception>
        public async Task<IEnumerable<CoinTweetItem>> GetCoinTweetsAsync(string coin_id)
        {
            if (string.IsNullOrEmpty(coin_id) || string.IsNullOrWhiteSpace(coin_id)) { throw new ArgumentNullException(nameof(coin_id), "Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)"); }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("coins", coin_id, "twitter"));

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 150);

            return JsonConvert.DeserializeObject<IEnumerable<CoinTweetItem>>(jsonStr);
        }

        /// <summary>
        /// Get coin events as an asynchronous operation.
        /// </summary>
        /// <param name="coin_id">The coin identifier (ex: btc-bitcoin).</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Coins/paths/~1coins~1%7Bcoin_id%7D~1events/get"/>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="CoinEventItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">coin_id - Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)</exception>
        public async Task<IEnumerable<CoinEventItem>> GetCoinEventsAsync(string coin_id)
        {
            if (string.IsNullOrEmpty(coin_id) || string.IsNullOrWhiteSpace(coin_id)) { throw new ArgumentNullException(nameof(coin_id), "Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)"); }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("coins", coin_id, "events"));

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 150);

            return JsonConvert.DeserializeObject<IEnumerable<CoinEventItem>>(jsonStr);
        }


        /// <summary>
        /// Get exchanges where a given coin is traded.
        /// </summary>
        /// <param name="coin_id">The coin identifier (ex: btc-bitcoin).</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Coins/paths/~1coins~1%7Bcoin_id%7D~1exchanges/get"/>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="CoinEventItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">coin_id - Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)</exception>
        public async Task<IEnumerable<CoinExchangeItem>> GetCoinExchangesAsync(string coin_id)
        {
            if (string.IsNullOrEmpty(coin_id) || string.IsNullOrWhiteSpace(coin_id)) { throw new ArgumentNullException(nameof(coin_id), "Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)"); }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("coins", coin_id, "exchanges"));

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 90);

            return JsonConvert.DeserializeObject<IEnumerable<CoinExchangeItem>>(jsonStr);
        }

        /// <summary>
        /// Get all available markets for a given coin.
        /// </summary>
        /// <param name="coin_id">The coin identifier (ex: btc-bitcoin).</param>
        /// <param name="quotes">A list of quotes to return (ex: BTC,USD). Default: USD</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Coins/paths/~1coins~1%7Bcoin_id%7D~1markets/get"/>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="CoinMarketItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">coin_id - Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)</exception>
        public async Task<IEnumerable<CoinMarketItem>> GetCoinMarketsAsync(string coin_id, IEnumerable<string> quotes = null)
        {
            if (string.IsNullOrEmpty(coin_id) || string.IsNullOrWhiteSpace(coin_id)) { throw new ArgumentNullException(nameof(coin_id), "Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)"); }

            if (quotes == null || !quotes.Any()) { quotes = new[] { "USD" }; }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("coins", coin_id, "markets"));
            request.AddQueryParameter("quotes", string.Join(",", quotes));

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 90);

            return JsonConvert.DeserializeObject<IEnumerable<CoinMarketItem>>(jsonStr);
        }


        /// <summary>
        /// Get Open/High/Low/Close values with volume and market capitalization for the last full day.
        /// </summary>
        /// <param name="coin_id">The coin identifier (ex: btc-bitcoin).</param>
        /// <param name="btc_quote">If set to <c>true</c> the quote currency is BTC, otherwise quote currency is USD.</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Coins/paths/~1coins~1%7Bcoin_id%7D~1ohlcv~1latest~1/get"/>
        /// <returns>A Task&lt;IEnumerable<see cref="OhlcvItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">coin_id - Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)</exception>
        public async Task<IEnumerable<OhlcvItem>> GetCoinOhlcLatestAsync(string coin_id, bool btc_quote = false)
        {
            if (string.IsNullOrEmpty(coin_id) || string.IsNullOrWhiteSpace(coin_id)) { throw new ArgumentNullException(nameof(coin_id), "Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)"); }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("coins", coin_id, "ohlcv", "latest"));
            if (btc_quote) { request.AddQueryParameter("quote", "btc"); }

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 1800);

            return JsonConvert.DeserializeObject<IEnumerable<OhlcvItem>>(jsonStr);
        }


        /// <summary>
        /// Get Open/High/Low/Close values with volume and market capitalization for any date range. If the end date is the current day, data can change with every request until actual close of the day.
        /// </summary>
        /// <param name="coin_id">The coin identifier (ex: btc-bitcoin).</param>
        /// <param name="start">The start start point for historical data.</param>
        /// <param name="end">The end point for for historical data (max 1 year). If not provided calculated by the limit parameter.</param>
        /// <param name="limit">The limit of result rows (max 366). Default: 1</param>
        /// <param name="btc_quote">If set to <c>true</c> the quote currency is BTC, otherwise quote currency is USD.</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Coins/paths/~1coins~1%7Bcoin_id%7D~1ohlcv~1historical/get"/>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="OhlcvItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">coin_id - Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)</exception>
        /// <exception cref="System.ArgumentNullException">start</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">start - Invalid value, start must be a reasonable value.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">end - Invalid value, end must be a maximum of 1 year from start.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">end - Invalid value, end must be greater than start.</exception>
        public async Task<IEnumerable<OhlcvItem>> GetCoinOhlcHistoricAsync(string coin_id, DateTimeOffset start, DateTimeOffset? end = null, uint limit = 1, bool btc_quote = false)
        {
            if (string.IsNullOrEmpty(coin_id) || string.IsNullOrWhiteSpace(coin_id)) { throw new ArgumentNullException(nameof(coin_id), "Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)"); }

            if (start == null) { throw new ArgumentNullException(nameof(start)); }
            if (start == DateTimeOffset.MinValue || start == DateTimeOffset.MaxValue) { throw new ArgumentOutOfRangeException(nameof(start), "Invalid value, start must be a reasonable value."); }
            if (end != null && start.AddYears(1) < end) { throw new ArgumentOutOfRangeException(nameof(end), "Invalid value, end must be a maximum of 1 year from start."); }
            if (end != null && end < start) { throw new ArgumentOutOfRangeException(nameof(end), "Invalid value, end must be greater than start."); }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("coins", coin_id, "ohlcv", "historical"));
            request.AddQueryParameter("start", start.ToUnixTimeSeconds());
            if (end != null) { request.AddQueryParameter("end", end.Value.ToUnixTimeSeconds()); }
            if (btc_quote) { request.AddQueryParameter("quote", "btc"); }
            if (limit > 1) { request.AddQueryParameter("limit", limit); }

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 150);

            return JsonConvert.DeserializeObject<IEnumerable<OhlcvItem>>(jsonStr);
        }


        /// <summary>
        /// Get Open/High/Low/Close values with volume and market capitalization for the current day. Data can change every each request until actual close of the day.
        /// </summary>
        /// <param name="coin_id">The coin identifier (ex: btc-bitcoin)..</param>
        /// <param name="btc_quote">>If set to <c>true</c> the quote currency is BTC, otherwise quote currency is USD.</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Coins/paths/~1coins~1%7Bcoin_id%7D~1ohlcv~1today~1/get"/>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="OhlcvItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">coin_id - Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)</exception>
        public async Task<IEnumerable<OhlcvItem>> GetCoinOhlcTodayAsync(string coin_id, bool btc_quote = false)
        {
            if (string.IsNullOrEmpty(coin_id) || string.IsNullOrWhiteSpace(coin_id)) { throw new ArgumentNullException(nameof(coin_id), "Invalid value, coin_id must be a valid coin identified (ex: btc-bitcoin)"); }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("coins", coin_id, "ohlcv", "today"));
            if (btc_quote) { request.AddQueryParameter("quote", "btc"); }

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 150);

            return JsonConvert.DeserializeObject<IEnumerable<OhlcvItem>>(jsonStr);
        }
    }
}
