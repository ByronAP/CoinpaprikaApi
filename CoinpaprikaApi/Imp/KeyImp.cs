// ***********************************************************************
// Assembly         : CoinpaprikaApi
// Author           : ByronAP
// Created          : 12-18-2022
//
// Last Modified By : ByronAP
// Last Modified On : 12-18-2022
// ***********************************************************************
// <copyright file="KeyImp.cs" company="ByronAP">
//     Copyright © 2022 ByronAP, Coinpaprika. All rights reserved.
// </copyright>
// ***********************************************************************
using CoinpaprikaApi.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinpaprikaApi.Imp
{
    /// <summary>
    /// <para>Implementation of the '/key' API calls.</para>
    /// <para>Implementation classes do not have a public constructor
    /// and must be accessed through an instance of <see cref="CoinpaprikaClient"/>.</para>
    /// </summary>
    /// <seealso href="https://api.coinpaprika.com/#tag/Key"/>
    public class KeyImp
    {
        private readonly RestClient _restClient;
        private readonly ILogger<CoinpaprikaClient> _logger;
        private readonly MemCache _cache;

        internal KeyImp(RestClient restClient, MemCache cache, ILogger<CoinpaprikaClient> logger)
        {
            _logger = logger;
            _cache = cache;
            _restClient = restClient;
        }

        /// <summary>
        /// Get API key information.
        /// </summary>
        /// <returns>A Task&lt;<see cref="KeyInfoResponse" />&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.Net.Http.HttpRequestException">403 forbidden error code: 1020</exception>
        /// <seealso href="https://api.coinpaprika.com/#tag/Key/paths/~1key~1info/get" />
        public async Task<KeyInfoResponse> GetKeyInfoAsync()
        {
            if (!_restClient.Options.BaseUrl.Equals(Constants.API_PRO_BASE_URL))
            {
                throw new HttpRequestException("403 forbidden error code: 1020");
            }
            var request = new RestRequest(CoinpaprikaClient.BuildUrl("key", "info"));

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 30);

            return JsonConvert.DeserializeObject<KeyInfoResponse>(jsonStr);
        }
    }
}
