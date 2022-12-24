// ***********************************************************************
// Assembly         : CoinpaprikaApi
// Author           : ByronAP
// Created          : 12-24-2022
//
// Last Modified By : ByronAP
// Last Modified On : 12-24-2022
// ***********************************************************************
// <copyright file="ExchangesImp.cs" company="ByronAP">
//     Copyright © 2022 ByronAP, Coinpaprika. All rights reserved.
// </copyright>
// ***********************************************************************
using CoinpaprikaApi.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinpaprikaApi.Imp
{
    /// <summary>
    /// <para>Implementation of the '/exchanges' API calls.</para>
    /// <para>Implementation classes do not have a public constructor
    /// and must be accessed through an instance of <see cref="CoinpaprikaClient"/>.</para>
    /// </summary>
    /// <seealso href="https://api.coinpaprika.com/#tag/Exchanges"/>
    public class ExchangesImp
    {
        private readonly RestClient _restClient;
        private readonly ILogger<CoinpaprikaClient> _logger;
        private readonly MemCache _cache;

        internal ExchangesImp(RestClient restClient, MemCache cache, ILogger<CoinpaprikaClient> logger)
        {
            _logger = logger;
            _cache = cache;
            _restClient = restClient;
        }

        /// <summary>
        /// Get basic information about exchanges.
        /// </summary>
        /// <param name="quotes">A list of quotes to return. Currently allowed values: BTC, ETH, USD, EUR, PLN, KRW, GBP, CAD, JPY, RUB, TRY, NZD, AUD, CHF, UAH, HKD, SGD, NGN, PHP, MXN, BRL, THB, CLP, CNY, CZK, DKK, HUF, IDR, ILS, INR, MYR, NOK, PKR, SEK, TWD, ZAR, VND, BOB, COP, PEN, ARS, ISK. Default: USD</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Exchanges/operation/getExchanges"/>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="ExchangeItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        public async Task<IEnumerable<ExchangeItem>> GetExchangesAsync(IEnumerable<string> quotes = null)
        {
            var request = new RestRequest(CoinpaprikaClient.BuildUrl("exchanges"));
            if (quotes != null) { request.AddParameter("quotes", string.Join(",", quotes)); }

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 90);

            return JsonConvert.DeserializeObject<IEnumerable<ExchangeItem>>(jsonStr);
        }

        /// <summary>
        /// Get basic information about a given exchange.
        /// </summary>
        /// <param name="exchange_id">The exchange identifier (ex: binance).</param>
        /// <param name="quotes">A list of quotes to return. Currently allowed values: BTC, ETH, USD, EUR, PLN, KRW, GBP, CAD, JPY, RUB, TRY, NZD, AUD, CHF, UAH, HKD, SGD, NGN, PHP, MXN, BRL, THB, CLP, CNY, CZK, DKK, HUF, IDR, ILS, INR, MYR, NOK, PKR, SEK, TWD, ZAR, VND, BOB, COP, PEN, ARS, ISK. Default: USD</param>
        /// <returns>A Task&lt;<see cref="ExchangeItem" />&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">exchange_id - Invalid value, exchange_id must be a valid exchange identified (ex: binance)</exception>
        /// <seealso href="https://api.coinpaprika.com/#tag/Exchanges/operation/getExchangeByID" />
        public async Task<ExchangeItem> GetExchangeAsync(string exchange_id, IEnumerable<string> quotes = null)
        {
            if (string.IsNullOrEmpty(exchange_id) || string.IsNullOrWhiteSpace(exchange_id)) { throw new ArgumentNullException(nameof(exchange_id), "Invalid value, exchange_id must be a valid exchange identified (ex: binance)"); }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("exchanges", exchange_id));
            if (quotes != null) { request.AddParameter("quotes", string.Join(",", quotes)); }

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 90);

            return JsonConvert.DeserializeObject<ExchangeItem>(jsonStr);
        }

        /// <summary>
        /// Get a list of all available markets on a given exchange.
        /// </summary>
        /// <param name="exchange_id">The exchange identifier (ex: binance).</param>
        /// <param name="quotes">A list of quotes to return. Currently allowed values: BTC, ETH, USD, EUR, PLN, KRW, GBP, CAD, JPY, RUB, TRY, NZD, AUD, CHF, UAH, HKD, SGD, NGN, PHP, MXN, BRL, THB, CLP, CNY, CZK, DKK, HUF, IDR, ILS, INR, MYR, NOK, PKR, SEK, TWD, ZAR, VND, BOB, COP, PEN, ARS, ISK. Default: USD</param>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="ExchangeMarketItem" />&gt;&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">exchange_id - Invalid value, exchange_id must be a valid exchange identified (ex: binance)</exception>
        /// <seealso href="https://api.coinpaprika.com/#tag/Exchanges/paths/~1exchanges~1%7Bexchange_id%7D~1markets/get" />
        public async Task<IEnumerable<ExchangeMarketItem>> GetExchangeMarketsAsync(string exchange_id, IEnumerable<string> quotes = null)
        {
            if (string.IsNullOrEmpty(exchange_id) || string.IsNullOrWhiteSpace(exchange_id)) { throw new ArgumentNullException(nameof(exchange_id), "Invalid value, exchange_id must be a valid exchange identified (ex: binance)"); }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("exchanges", exchange_id, "markets"));
            if (quotes != null) { request.AddParameter("quotes", string.Join(",", quotes)); }

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 90);

            return JsonConvert.DeserializeObject<IEnumerable<ExchangeMarketItem>>(jsonStr);
        }
    }
}
