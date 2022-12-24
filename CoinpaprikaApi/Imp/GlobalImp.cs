// ***********************************************************************
// Assembly         : CoinpaprikaApi
// Author           : ByronAP
// Created          : 12-18-2022
//
// Last Modified By : ByronAP
// Last Modified On : 12-18-2022
// ***********************************************************************
// <copyright file="GlobalImp.cs" company="ByronAP">
//     Copyright © 2022 ByronAP, Coinpaprika. All rights reserved.
// </copyright>
// ***********************************************************************

using CoinpaprikaApi.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace CoinpaprikaApi.Imp
{
    /// <summary>
    /// <para>Implementation of the '/global' API calls.</para>
    /// <para>Implementation classes do not have a public constructor
    /// and must be accessed through an instance of <see cref="CoinpaprikaClient"/>.</para>
    /// </summary>
    /// <seealso href="https://api.coinpaprika.com/#tag/Global"/>
    public class GlobalImp
    {
        private readonly RestClient _restClient;
        private readonly ILogger<CoinpaprikaClient> _logger;
        private readonly MemCache _cache;

        internal GlobalImp(RestClient restClient, MemCache cache, ILogger<CoinpaprikaClient> logger)
        {
            _logger = logger;
            _cache = cache;
            _restClient = restClient;
        }

        /// <summary>
        /// Get market overview data as an asynchronous operation.
        /// </summary>
        /// <seealso href="https://api.coinpaprika.com/#tag/Global/paths/~1global/get"/>
        /// <returns>A Task&lt;<see cref="GlobalResponse"/>&gt; representing the asynchronous operation.</returns>
        public async Task<GlobalResponse> GetGlobalAsync()
        {
            var request = new RestRequest(CoinpaprikaClient.BuildUrl("global"));

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 240);

            return JsonConvert.DeserializeObject<GlobalResponse>(jsonStr);
        }
    }
}
