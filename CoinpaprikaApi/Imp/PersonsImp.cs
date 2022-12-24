// ***********************************************************************
// Assembly         : CoinpaprikaApi
// Author           : ByronAP
// Created          : 12-23-2022
//
// Last Modified By : ByronAP
// Last Modified On : 12-23-2022
// ***********************************************************************
// <copyright file="PersonsImp.cs" company="ByronAP">
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
    /// <para>Implementation of the '/persons' API calls.</para>
    /// <para>Implementation classes do not have a public constructor
    /// and must be accessed through an instance of <see cref="CoinpaprikaClient"/>.</para>
    /// </summary>
    /// <seealso href="https://api.coinpaprika.com/#tag/People"/>
    public class PersonsImp
    {
        private readonly RestClient _restClient;
        private readonly ILogger<CoinpaprikaClient> _logger;
        private readonly MemCache _cache;

        internal PersonsImp(RestClient restClient, MemCache cache, ILogger<CoinpaprikaClient> logger)
        {
            _logger = logger;
            _cache = cache;
            _restClient = restClient;
        }

        /// <summary>
        /// Get information about a person with the specified ID, related to the cryptocurrency market. Using this endpoint you can get a description of the person, social media links, number of teams she or he is involved in and the positions in those teams.
        /// <para>Always check that the <c>error</c> field of the response is not null or empty. If the person was not found the <c>error</c> field will have data.</para>
        /// </summary>
        /// <param name="person_id">The person identifier (name) (ex: vitalik-buterin).</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/People/operation/getPeopleById"/>
        /// <returns>A Task&lt;<see cref="PersonResponse"/>&gt; representing the asynchronous operation.</returns>
        public async Task<PersonResponse> GetPersonAsync(string person_id)
        {
            var request = new RestRequest(CoinpaprikaClient.BuildUrl("people", person_id));

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 1800);

            return JsonConvert.DeserializeObject<PersonResponse>(jsonStr);
        }
    }
}
