// ***********************************************************************
// Assembly         : CoinpaprikaApi
// Author           : ByronAP
// Created          : 12-17-2022
//
// Last Modified By : ByronAP
// Last Modified On : 12-24-2022
// ***********************************************************************
// <copyright file="CoinPaprikaClient.cs" company="ByronAP">
//     Copyright © 2022 ByronAP, Coinpaprika. All rights reserved.
// </copyright>
// ***********************************************************************
using CoinpaprikaApi.Exceptions;
using CoinpaprikaApi.Imp;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoinpaprikaApi
{
    /// <summary>
    /// <para>Create an instance of this class to access the API methods.</para>
    /// <para>
    /// Methods and parameters are named as specified in the official
    /// Coinpaprika API documentation (Ex: API call '/coins' 
    /// translates to 'CoinpaprikaClient.Coins.GetCoinsAsync()').
    /// </para>
    /// <para>By default response caching is enabled. To disable it set <see cref="IsCacheEnabled"/> to <c>false</c>.</para>
    /// </summary>
    public class CoinpaprikaClient : IDisposable
    {
        /// <summary>
        /// The RestSharp client instance used to make the API calls.
        /// This is exposed in case you wish to change options such as use a proxy.
        /// </summary>
        /// <value>The RestSharp client instance.</value>
        public RestClient CPRestClient { get; }

        /// <summary>
        /// <para>Gets or sets whether this instance is using response caching.</para>
        /// <para>Caching is enabled by default.</para>
        /// </summary>
        /// <value><c>true</c> if this instances cache is enabled; otherwise, <c>false</c>.</value>
        public bool IsCacheEnabled { get { return _cache.Enabled; } set { _cache.Enabled = value; } }

        /// <summary>
        /// <para>Provides access to the Key API calls.</para>
        /// An instance of <see cref="KeyImp"/>.
        /// </summary>
        /// <value>Key API calls.</value>
        public KeyImp Key { get; }

        /// <summary>
        /// <para>Provides access to the Global API calls.</para>
        /// An instance of <see cref="GlobalImp"/>.
        /// </summary>
        /// <value>Global API calls.</value>
        public GlobalImp Global { get; }

        /// <summary>
        /// <para>Provides access to the Coins API calls.</para>
        /// An instance of <see cref="CoinsImp"/>.
        /// </summary>
        /// <value>Coins API calls.</value>
        public CoinsImp Coins { get; }

        /// <summary>
        /// <para>Provides access to the Persons API calls.</para>
        /// An instance of <see cref="PersonsImp"/>.
        /// </summary>
        /// <value>Persons API calls.</value>
        public PersonsImp Persons { get; }

        /// <summary>
        /// <para>Provides access to the Tags API calls.</para>
        /// An instance of <see cref="TagsImp"/>.
        /// </summary>
        /// <value>Tags API calls.</value>
        public TagsImp Tags { get; }

        /// <summary>
        /// <para>Provides access to the Exchanges API calls.</para>
        /// An instance of <see cref="ExchangesImp"/>.
        /// </summary>
        /// <value>Exchanges API calls.</value>
        public ExchangesImp Exchanges { get; }

        /// <summary>
        /// <para>Provides access to the Tickers API calls.</para>
        /// An instance of <see cref="TickersImp"/>.
        /// </summary>
        /// <value>Tickers API calls.</value>
        public TickersImp Tickers { get; }

        /// <summary>
        /// <para>Provides access to the Tools API calls.</para>
        /// An instance of <see cref="ToolsImp"/>.
        /// </summary>
        /// <value>Tools API calls.</value>
        public ToolsImp Tools { get; }

        /// <summary>
        /// <para>Provides access to the Contracts API calls.</para>
        /// An instance of <see cref="ContractsImp"/>.
        /// </summary>
        /// <value>Contracts API calls.</value>
        public ContractsImp Contracts { get; }

        private readonly MemCache _cache;
        private bool _disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoinpaprikaClient"/> class.
        /// <para>Using an API key is optional but highly recommended since the free tier is very limited.</para>
        /// <para>Using a logger is optional but recommended. This can be supplied via dependency injection.</para>
        /// </summary>
        /// <param name="apiKey">Your API key.</param>
        /// <param name="logger">Your logger.</param>
        public CoinpaprikaClient(string apiKey = null, ILogger<CoinpaprikaClient> logger = null)
        {
            _cache = new MemCache(logger);


            if (!string.IsNullOrEmpty(apiKey) && !String.IsNullOrWhiteSpace(apiKey))
            {
                CPRestClient = new RestClient(Constants.API_PRO_BASE_URL);
                CPRestClient.AddDefaultHeader("Authorization", apiKey);
            }
            else
            {
                CPRestClient = new RestClient(Constants.API_BASE_URL);
            }

            CPRestClient.AddDefaultHeader("Accept-Encoding", "gzip, deflate, br");
            CPRestClient.AddDefaultHeader("Accept", "application/json");
            CPRestClient.AddDefaultHeader("Connection", "keep-alive");
            CPRestClient.AddDefaultHeader("User-Agent", $"CoinpaprikaApi .NET Client/{Assembly.GetExecutingAssembly().GetName().Version}");

            Key = new KeyImp(CPRestClient, _cache, logger);
            Global = new GlobalImp(CPRestClient, _cache, logger);
            Coins = new CoinsImp(CPRestClient, _cache, logger);
            Persons = new PersonsImp(CPRestClient, _cache, logger);
            Tags = new TagsImp(CPRestClient, _cache, logger);
            Exchanges = new ExchangesImp(CPRestClient, _cache, logger);
            Tickers = new TickersImp(CPRestClient, _cache, logger);
            Tools = new ToolsImp(CPRestClient, _cache, logger);
            Contracts = new ContractsImp(CPRestClient, _cache, logger);
        }

        internal static async Task<string> GetStringResponseAsync(RestClient client, RestRequest request, MemCache cache, ILogger logger, int cacheTime)
        {
            var fullUrl = client.BuildUri(request).ToString();

            try
            {
                if (cache.TryGet(fullUrl, out var cacheResponse))
                {
                    return (string)cacheResponse;
                }
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "");
            }

            try
            {
                var response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    cache.CacheRequest(fullUrl, response, cacheTime);

                    return response.Content;
                }

                if (response.ErrorException != null)
                {
                    logger?.LogError(response.ErrorException, "GetStringResponseAsync failed.");
                    throw response.ErrorException;
                }

                throw new UnknownException($"Unknown exception, http response code is not success, {response.StatusCode}.");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "GetStringResponseAsync request failure.");
                throw;
            }
        }

        internal static string BuildUrl(params string[] parts)
        {
            if (parts.Length > 2)
            {
                var sb = new StringBuilder();
                sb.Append("/v").Append(Constants.API_VERSION);
                foreach (var part in parts)
                {
                    sb.Append('/');
                    sb.Append(part);
                }
                return sb.ToString();
            }
            else
            {
                var result = $"/v{Constants.API_VERSION}";
                foreach (var part in parts)
                {
                    result += $"/{part}";
                }
                return result;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_cache != null)
                    {
                        try
                        {
                            _cache.Dispose();
                        }
                        catch
                        {
                            // ignore
                        }
                    }
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
