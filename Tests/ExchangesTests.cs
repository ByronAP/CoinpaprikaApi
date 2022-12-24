namespace Tests
{
    internal class ExchangesTests
    {
        [Test]
        public async Task GetExchangesTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Exchanges.GetExchangesAsync();

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }

        [Test]
        public async Task GetExchangeTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Exchanges.GetExchangeAsync("binance");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult.Quotes, Is.Not.Empty);
        }

        [Test]
        public async Task GetExchangeMarketsTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Exchanges.GetExchangeMarketsAsync("binance");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }
    }
}
