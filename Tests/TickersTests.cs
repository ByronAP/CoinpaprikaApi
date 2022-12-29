namespace Tests
{
    internal class TickersTests
    {
        [Test]
        public async Task GetTickersTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Tickers.GetTickersAsync();

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task GetTickerTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Tickers.GetTickerAsync("btc-bitcoin");

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult.Quotes, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task GetHistoricalTicksTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Tickers.GetHistoricalTicksAsync("btc-bitcoin", DateTimeOffset.UtcNow.AddDays(-5), interval: CoinpaprikaApi.Types.TickerInterval.d1);

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }
    }
}
