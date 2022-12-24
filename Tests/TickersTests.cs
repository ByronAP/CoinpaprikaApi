namespace Tests
{
    internal class TickersTests
    {
        [Test]
        public async Task GetTickersTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Tickers.GetTickersAsync();

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }

        [Test]
        public async Task GetTickerTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Tickers.GetTickerAsync("btc-bitcoin");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult.Quotes, Is.Not.Empty);
        }

        [Test]
        public async Task GetHistoricalTicksTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Tickers.GetHistoricalTicksAsync("btc-bitcoin", DateTimeOffset.UtcNow.AddDays(-5), interval: CoinpaprikaApi.Types.TickerInterval.d1);

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }
    }
}
