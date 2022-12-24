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
    /// <para>Implementation of the '/tags' API calls.</para>
    /// <para>Implementation classes do not have a public constructor
    /// and must be accessed through an instance of <see cref="CoinpaprikaClient"/>.</para>
    /// </summary>
    /// <seealso href="https://api.coinpaprika.com/#tag/Tags"/>
    public class TagsImp
    {
        private readonly RestClient _restClient;
        private readonly ILogger<CoinpaprikaClient> _logger;
        private readonly MemCache _cache;

        internal TagsImp(RestClient restClient, MemCache cache, ILogger<CoinpaprikaClient> logger)
        {
            _logger = logger;
            _cache = cache;
            _restClient = restClient;
        }

        /// <summary>
        /// Get basic information about cryptocurrencies tags (categories).
        /// </summary>
        /// <param name="include_coins">If set to <c>true</c> coin list will be included.</param>
        /// <param name="include_icos">If set to <c>true</c> icos list will be included.</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Tags/paths/~1tags/get"/>
        /// <returns>A Task&lt;IEnumerable&lt;<see cref="TagItem"/>&gt;&gt; representing the asynchronous operation.</returns>
        public async Task<IEnumerable<TagItem>> GetTagsAsync(bool include_coins = false, bool include_icos = false)
        {
            var request = new RestRequest(CoinpaprikaClient.BuildUrl("tags"));
            if (include_coins && include_icos)
            {
                request.AddQueryParameter("additional_fields", "coins,icos");
            }
            else
            {
                if (include_coins)
                {
                    request.AddQueryParameter("additional_fields", "coins");
                }

                if (include_icos)
                {
                    request.AddQueryParameter("additional_fields", "icos");
                }
            }

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 1800);

            return JsonConvert.DeserializeObject<IEnumerable<TagItem>>(jsonStr);
        }

        /// <summary>
        /// Get information about a given cryptocurrency tag.
        /// </summary>
        /// <param name="tag_id">The tag identifier (ex: blockchain-service).</param>
        /// <param name="include_coins">If set to <c>true</c> coin list will be included.</param>
        /// <param name="include_icos">If set to <c>true</c> icos list will be included.</param>
        /// <seealso href="https://api.coinpaprika.com/#tag/Tags/paths/~1tags~1%7Btag_id%7D/get"/>
        /// <returns>A Task&lt;<see cref="TagItem"/>&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">tag_id - Invalid value, tag_id must be a valid tag identified (ex: blockchain-service)</exception>
        public async Task<TagItem> GetTagAsync(string tag_id, bool include_coins = false, bool include_icos = false)
        {
            if (string.IsNullOrEmpty(tag_id) || string.IsNullOrWhiteSpace(tag_id)) { throw new ArgumentNullException(nameof(tag_id), "Invalid value, tag_id must be a valid tag identified (ex: blockchain-service)"); }

            var request = new RestRequest(CoinpaprikaClient.BuildUrl("tags", tag_id));
            if (include_coins && include_icos)
            {
                request.AddQueryParameter("additional_fields", "coins,icos");
            }
            else
            {
                if (include_coins)
                {
                    request.AddQueryParameter("additional_fields", "coins");
                }

                if (include_icos)
                {
                    request.AddQueryParameter("additional_fields", "icos");
                }
            }

            var jsonStr = await CoinpaprikaClient.GetStringResponseAsync(_restClient, request, _cache, _logger, 1800);

            return JsonConvert.DeserializeObject<TagItem>(jsonStr);
        }
    }
}
