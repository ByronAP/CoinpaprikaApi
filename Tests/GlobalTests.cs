namespace Tests
{
    internal class GlobalTests
    {
        [Test]
        public async Task GetGlobalTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Global.GetGlobalAsync();

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult.MarketCapUsd, Is.GreaterThan(1));
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }
    }
}
