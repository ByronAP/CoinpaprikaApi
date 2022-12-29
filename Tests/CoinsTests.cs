namespace Tests
{
    public class CoinsTests
    {
        [Test]
        public async Task GetCoinsTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinsAsync();

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult, Is.Not.Empty);

                var eosItem = callResult.FirstOrDefault(x => x.Id.Equals("eos-eos", StringComparison.InvariantCultureIgnoreCase));

                Assert.That(eosItem, Is.Not.Null);
                Assert.That(eosItem.Name, Is.EqualTo("EOS"));
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task GetCoinTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinAsync("eos-eos");

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult.Name, Is.EqualTo("EOS"));
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task GetCoinTweetsTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinTweetsAsync("btc-bitcoin");

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task GetCoinEventsTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinEventsAsync("btc-bitcoin");

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task GetCoinExchangesTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinExchangesAsync("btc-bitcoin");

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task GetCoinMarketsTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinMarketsAsync("btc-bitcoin");

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task GetCoinOhlcLatestTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinOhlcLatestAsync("btc-bitcoin");

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task GetCoinOhlcHistoricTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinOhlcHistoricAsync("btc-bitcoin", DateTimeOffset.UtcNow.AddDays(-1));

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task GetCoinOhlcTodayTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Coins.GetCoinOhlcTodayAsync("btc-bitcoin");

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