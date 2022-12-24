using CoinpaprikaApi.Types;
using System;
using System.Collections.Generic;

namespace CoinpaprikaApi
{
    internal static class Extensions
    {
        internal static string ToAPIString(this TickerInterval value)
        {
            switch (value)
            {
                case TickerInterval.m5:
                    return "5m";
                case TickerInterval.m10:
                    return "10m";
                case TickerInterval.m15:
                    return "15m";
                case TickerInterval.m30:
                    return "30m";
                case TickerInterval.m45:
                    return "45m";
                case TickerInterval.h1:
                    return "1h";
                case TickerInterval.h2:
                    return "2h";
                case TickerInterval.h3:
                    return "3h";
                case TickerInterval.h6:
                    return "6h";
                case TickerInterval.h12:
                    return "12h";
                case TickerInterval.h24:
                    return "24h";
                case TickerInterval.d1:
                    return "1d";
                case TickerInterval.d7:
                    return "7d";
                case TickerInterval.d14:
                    return "14d";
                case TickerInterval.d30:
                    return "30d";
                case TickerInterval.d90:
                    return "90d";
                case TickerInterval.d365:
                    return "365d";
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TickerInterval.");
            }
        }

        internal static string[] ToArray(this SearchCategory value)
        {
            if (value.HasFlag(SearchCategory.All))
            {
                return new string[] { SearchCategory.icos.ToString(), SearchCategory.exchanges.ToString(), SearchCategory.tags.ToString(), SearchCategory.people.ToString(), SearchCategory.currencies.ToString() };
            }

            var results = new List<string>();
            if (value.HasFlag(SearchCategory.currencies)) { results.Add(SearchCategory.currencies.ToString()); }
            if (value.HasFlag(SearchCategory.tags)) { results.Add(SearchCategory.tags.ToString()); }
            if (value.HasFlag(SearchCategory.people)) { results.Add(SearchCategory.people.ToString()); }
            if (value.HasFlag(SearchCategory.exchanges)) { results.Add(SearchCategory.exchanges.ToString()); }
            if (value.HasFlag(SearchCategory.icos)) { results.Add(SearchCategory.icos.ToString()); }

            return results.ToArray();
        }
    }
}
