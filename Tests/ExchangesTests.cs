namespace Tests
{
    internal class ExchangesTests
    {
        [Test]
        public async Task GetExchangesTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Exchanges.GetExchangesAsync();

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task GetExchangeTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Exchanges.GetExchangeAsync("binance");

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult.Quotes, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task GetExchangeMarketsTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Exchanges.GetExchangeMarketsAsync("binance");

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
