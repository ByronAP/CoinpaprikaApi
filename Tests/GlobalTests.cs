namespace Tests
{
    internal class GlobalTests
    {
        [Test]
        public async Task GetGlobalTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Global.GetGlobalAsync();

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult.MarketCapUsd, Is.GreaterThan(1));
        }
    }
}
