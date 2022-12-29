namespace Tests
{
    internal class ToolsTests
    {
        [Test]
        public async Task SearchTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Tools.SearchAsync("btc");

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult.Currencies, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task PriceConvertTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Tools.PriceConvertAsync("eth-ethereum", "btc-bitcoin", 100);

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult.Price, Is.GreaterThan(1));
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }
    }
}
