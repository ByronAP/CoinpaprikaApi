using CoinpaprikaApi.Properties;

namespace CoinpaprikaApi
{
    public static class Constants
    {
        /// <summary>
        /// The display name of the API provider.
        /// </summary>
        public static readonly string API_NAME = "Coinpaprika";

        /// <summary>
        /// The base API URL.
        /// </summary>
        public static readonly string API_BASE_URL = "https://api.coinpaprika.com";

        /// <summary>
        /// The base URL for PRO feature calls.
        /// </summary>
        public static readonly string API_PRO_BASE_URL = "https://api-pro.coinpaprika.com/v1/";

        /// <summary>
        /// The major API version.
        /// </summary>
        public static readonly uint API_VERSION = 1;

        /// <summary>
        /// The full API version.
        /// </summary>
        public static readonly string API_VERSION_FULL = "1.7.5";

        /// <summary>
        /// The API logo at 128 X 128 in PNG format.
        /// This is an embedded resource.
        /// </summary>
        public static readonly byte[] API_LOGO_128X128_PNG = Resources.coinpaprika_logo;

        /// <summary>
        /// The API minimum cache time in milliseconds.
        /// </summary>
        public static readonly uint API_MIN_CACHE_TIME_MS = 30000;
    }
}
