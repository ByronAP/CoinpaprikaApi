namespace Tests
{
    public class CoinsTests
    {
        [Test]
        public async Task GetCoinsTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinsAsync();

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);

            var eosItem = callResult.FirstOrDefault(x => x.Id.Equals("eos-eos", StringComparison.InvariantCultureIgnoreCase));

            Assert.That(eosItem, Is.Not.Null);
            Assert.That(eosItem.Name, Is.EqualTo("EOS"));
        }

        [Test]
        public async Task GetCoinTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinAsync("eos-eos");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult.Name, Is.EqualTo("EOS"));
        }

        [Test]
        public async Task GetCoinTweetsTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinTweetsAsync("btc-bitcoin");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }

        [Test]
        public async Task GetCoinEventsTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinEventsAsync("btc-bitcoin");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }

        [Test]
        public async Task GetCoinExchangesTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinExchangesAsync("btc-bitcoin");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }

        [Test]
        public async Task GetCoinMarketsTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinMarketsAsync("btc-bitcoin");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }

        [Test]
        public async Task GetCoinOhlcLatestTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinOhlcLatestAsync("btc-bitcoin");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }

        [Test]
        public async Task GetCoinOhlcHistoricTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinOhlcHistoricAsync("btc-bitcoin", DateTimeOffset.UtcNow.AddDays(-1));

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }

        [Test]
        public async Task GetCoinOhlcTodayTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinOhlcTodayAsync("btc-bitcoin");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }
    }
}