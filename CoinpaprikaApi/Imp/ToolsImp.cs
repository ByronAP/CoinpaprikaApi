// ***********************************************************************
// Assembly         : CoinpaprikaApi
// Author           : ByronAP
// Created          : 12-24-2022
//
// Last Modified By : ByronAP
// Last Modified On : 12-24-2022
// ***********************************************************************
// <copyright file="ToolsImp.cs" company="ByronAP">
//     Copyright © 2022 ByronAP, Coinpaprika. All rights reserved.
// </copyright>
// ***********************************************************************
using CoinpaprikaApi.Models;
using CoinpaprikaApi.Types;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace CoinpaprikaApi.Imp
{
    /// <summary>
    /// <para>Implementation of the Tools API calls.</para>
    /// <para>Implementation classes do not have a public constructor
    /// and must be accessed through an instance of <see cref="CoinpaprikaClient"/>.</para>
    /// </summary>
    /// <seealso href="https://api.coinpaprika.com/#tag/Tools"/>
    public class ToolsImp
    {
        private readonly RestClient _restClient;
        private readonly ILogger<CoinpaprikaClient> _logger;
        private readonly MemCache _cache;

        internal ToolsImp(RestClient restClient, MemCache cache, ILogger<CoinpaprikaClient> logger)
        {
            _logger = logger;
            _cache = cache;
            _restClient = restClient;
        }

        /// <summary>
        /// Get currencies, exchanges, icos, people, tags for a given search query.
        /// </summary>
        /// <param name="query">The query term / phrase for search (ex: eth).</param>
        /// <param name="categories">One or more categories to search. Default: all</param>
        /// <param name="symbol_search">If set to <c>true</c> search only by symbol (works for currencies only).</param>
        /// <param name="limit">The limit of results per category (max 250). Default: 6</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Tools/paths/~1search/get"/>
        /// <returns>A Task&lt;<see cref="SearchResponse"/>&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">query - Invalid value, query must be a valid search term (phrase).</exception>
        public async Task<SearchResponse> SearchAsync(string query, SearchCategory categories = SearchCategory.All, bool symbol_search = false, uint limit = 6)
        {
            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query)) { throw new ArgumentNullException(nameof(query), "Invalid value, query must be a valid search term (phrase)."); }

            if (limit <= 0) { limit = 1; }

            if (limit > 250) { limit = 250; }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("search"));
            request.AddParameter("q", query);
            if (categories != SearchCategory.All) { request.AddParameter("c", string.Join(",", categories.ToArray())); }
            if (symbol_search) { request.AddParameter("modifier", "symbol_search"); }
            if (limit != 6) { request.AddParameter("limit", limit); }

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 90);

            return JsonConvert.DeserializeObject<SearchResponse>(jsonStr);
        }

        /// <summary>
        /// Converts a set amount of base currency to quote currency.
        /// </summary>
        /// <param name="base_currency_id">The base currency identifier.</param>
        /// <param name="quote_currency_id">The quote currency identifier.</param>
        /// <param name="amount">The amount.</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Tools/paths/~1price-converter/get"/>
        /// <returns>A Task&lt;<see cref="PriceConverterResponse"/>&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">base_currency_id - Invalid value, base_currency_id must be a valid currency id.</exception>
        /// <exception cref="System.ArgumentNullException">quote_currency_id - Invalid value, quote_currency_id must be a valid currency id.</exception>
        public async Task<PriceConverterResponse> PriceConvertAsync(string base_currency_id, string quote_currency_id, decimal amount)
        {
            if (string.IsNullOrEmpty(base_currency_id) || string.IsNullOrWhiteSpace(base_currency_id)) { throw new ArgumentNullException(nameof(base_currency_id), "Invalid value, base_currency_id must be a valid currency id."); }
            if (string.IsNullOrEmpty(quote_currency_id) || string.IsNullOrWhiteSpace(quote_currency_id)) { throw new ArgumentNullException(nameof(quote_currency_id), "Invalid value, quote_currency_id must be a valid currency id."); }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("price-converter"));
            request.AddParameter("base_currency_id", base_currency_id);
            request.AddParameter("quote_currency_id", quote_currency_id);
            request.AddParameter("amount", amount);

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 90);

            return JsonConvert.DeserializeObject<PriceConverterResponse>(jsonStr);
        }
    }
}
