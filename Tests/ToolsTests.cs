namespace Tests
{
    internal class ToolsTests
    {
        [Test]
        public async Task SearchTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Tools.SearchAsync("btc");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult.Currencies, Is.Not.Empty);
        }

        [Test]
        public async Task PriceConvertTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Tools.PriceConvertAsync("eth-ethereum", "btc-bitcoin", 100);

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult.Price, Is.GreaterThan(1));
        }
    }
}
