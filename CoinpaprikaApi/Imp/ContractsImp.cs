// ***********************************************************************
// Assembly         : CoinpaprikaApi
// Author           : ByronAP
// Created          : 12-24-2022
//
// Last Modified By : ByronAP
// Last Modified On : 12-24-2022
// ***********************************************************************
// <copyright file="ContractsImp.cs" company="ByronAP">
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
using System.Threading.Tasks;

namespace CoinpaprikaApi.Imp
{
    /// <summary>
    /// <para>Implementation of the '/contracts' API calls.</para>
    /// <para>Implementation classes do not have a public constructor
    /// and must be accessed through an instance of <see cref="CoinpaprikaClient"/>.</para>
    /// </summary>
    /// <seealso href="https://api.coinpaprika.com/#tag/Contracts"/>
    public class ContractsImp
    {
        private readonly RestClient _restClient;
        private readonly ILogger<CoinpaprikaClient> _logger;
        private readonly MemCache _cache;

        internal ContractsImp(RestClient restClient, MemCache cache, ILogger<CoinpaprikaClient> logger)
        {
            _logger = logger;
            _cache = cache;
            _restClient = restClient;
        }

        /// <summary>
        /// Get all available contract platforms.
        /// </summary>
        /// <seealso href="https://api.coinpaprika.com/#tag/Contracts/operation/getPlatforms"/>
        /// <returns>A Task&lt;IEnumerable&lt;string&gt;&gt; representing the asynchronous operation.</returns>
        public async Task<IEnumerable<string>> GetPlatformsAsync()
        {
            var request = new RestRequest(CoinpaprikaClient.BuildUrl("contracts"));

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 90);

            return JsonConvert.DeserializeObject<IEnumerable<string>>(jsonStr);
        }


        /// <summary>
        /// Get all available contracts for a given platform.
        /// </summary>
        /// <param name="platform_id">The platform identifier. <see cref="GetPlatformsAsync"/></param>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="ContractItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        /// <seealso href="https://api.coinpaprika.com/#tag/Contracts/operation/getContracts"/>
        /// <exception cref="System.ArgumentNullException">platform_id - Invalid value, platform_id must be a valid platform identified (ex: eth-ethereum)</exception>
        public async Task<IEnumerable<ContractItem>> GetContractsAsync(string platform_id)
        {
            if (string.IsNullOrEmpty(platform_id) || string.IsNullOrWhiteSpace(platform_id)) { throw new ArgumentNullException(nameof(platform_id), "Invalid value, platform_id must be a valid platform identified (ex: eth-ethereum)"); }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("contracts", platform_id));

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 90);

            return JsonConvert.DeserializeObject<IEnumerable<ContractItem>>(jsonStr);
        }


        /// <summary>
        /// Get ticker data for a contract with a given address..
        /// </summary>
        /// <param name="platform_id">The platform identifier. <see cref="GetPlatformsAsync"/></param>
        /// <param name="contract_address">The contract address (ex: 0xd26114cd6ee289accf82350c8d8487fedb8a0c07).</param>
        /// <returns>A Task&lt;<see cref="TickerItem"/>&gt; representing the asynchronous operation.</returns>
        /// <seealso href="https://api.coinpaprika.com/#tag/Contracts/operation/getTicker"/>
        /// <exception cref="System.ArgumentNullException">platform_id - Invalid value, platform_id must be a valid platform identified (ex: eth-ethereum)</exception>
        /// <exception cref="System.ArgumentNullException">contract_address - Invalid value, contract_address must be a valid smart contract identified (ex: 0xd26114cd6ee289accf82350c8d8487fedb8a0c07)</exception>
        public async Task<TickerItem> GetTickerByContractAddressAsync(string platform_id, string contract_address)
        {
            if (string.IsNullOrEmpty(platform_id) || string.IsNullOrWhiteSpace(platform_id)) { throw new ArgumentNullException(nameof(platform_id), "Invalid value, platform_id must be a valid platform identified (ex: eth-ethereum)"); }
            if (string.IsNullOrEmpty(contract_address) || string.IsNullOrWhiteSpace(contract_address)) { throw new ArgumentNullException(nameof(contract_address), "Invalid value, contract_address must be a valid smart contract identified (ex: 0xd26114cd6ee289accf82350c8d8487fedb8a0c07)"); }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("contracts", platform_id, contract_address));

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 150);

            return JsonConvert.DeserializeObject<TickerItem>(jsonStr);
        }


        /// <summary>
        /// Get historical ticks for a contract with a given address.
        /// </summary>
        /// <param name="platform_id">The platform identifier. <see cref="GetPlatformsAsync"/></param>
        /// <param name="contract_address">The contract address (ex: 0xd26114cd6ee289accf82350c8d8487fedb8a0c07).</param>
        /// <param name="start"> The start start point for historical data.</param>
        /// <param name="end">The end point for for historical data.</param>
        /// <param name="limit">The limit of result rows (max 5000). Default: 1000</param>
        /// <param name="quote_btc">Set to <c>true</c> to use BTC as quote currency, else quote is USD.</param>
        /// <param name="interval">The bucket interval.</param>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="TickItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        /// <seealso href="https://api.coinpaprika.com/#tag/Contracts/operation/getHistoricalTicker"/>
        /// <exception cref="System.ArgumentNullException">platform_id - Invalid value, platform_id must be a valid platform identified (ex: eth-ethereum)</exception>
        /// <exception cref="System.ArgumentNullException">contract_address - Invalid value, contract_address must be a valid smart contract identified (ex: 0xd26114cd6ee289accf82350c8d8487fedb8a0c07)</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">end - Invalid value, end must be a valid date after start.</exception>
        public async Task<IEnumerable<TickItem>> GetHistoricalTicksByContractAddressAsync(string platform_id, string contract_address, DateTimeOffset start, DateTimeOffset? end = null, uint limit = 1000, bool quote_btc = false, TickerInterval interval = TickerInterval.m5)
        {
            if (string.IsNullOrEmpty(platform_id) || string.IsNullOrWhiteSpace(platform_id)) { throw new ArgumentNullException(nameof(platform_id), "Invalid value, platform_id must be a valid platform identified (ex: eth-ethereum)"); }
            if (string.IsNullOrEmpty(contract_address) || string.IsNullOrWhiteSpace(contract_address)) { throw new ArgumentNullException(nameof(contract_address), "Invalid value, contract_address must be a valid smart contract identified (ex: 0xd26114cd6ee289accf82350c8d8487fedb8a0c07)"); }

            if (end != null && end <= start) { throw new ArgumentOutOfRangeException(nameof(end), "Invalid value, end must be a valid date after start."); }

            if (end != null && end > DateTimeOffset.UtcNow) { end = null; }

            if (limit > 5000) { limit = 5000; }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("contracts", platform_id, contract_address, "historical"));
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
