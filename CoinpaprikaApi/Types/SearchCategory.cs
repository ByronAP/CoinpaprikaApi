using System;

namespace CoinpaprikaApi.Types
{
    [Flags]
    public enum SearchCategory
    {
        All = 0,
        currencies = 1,
        exchanges = 2,
        icos = 4,
        people = 8,
        tags = 16
    }
}
