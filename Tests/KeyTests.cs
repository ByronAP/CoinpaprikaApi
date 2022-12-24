namespace Tests
{
    internal class KeyTests
    {
        [Test]
        public async Task GetKeyInfoTest()
        {
            // I don't have an API key so I can only test failure

            try
            {
                var callResult = await (await Helpers.GetApiClient()).Key.GetKeyInfoAsync();
            }
            catch (HttpRequestException ex)
            {
                if (!ex.Message.Contains("forbidden", StringComparison.InvariantCultureIgnoreCase))
                {
                    Assert.Fail();
                }
            }

            await Task.Delay(10000);

            using CoinpaprikaClient tmpClient = new("AFakeApiKey");

            try
            {
                var callResult = await tmpClient.Key.GetKeyInfoAsync();
            }
            catch (HttpRequestException ex)
            {
                if (!ex.Message.Contains("forbidden", StringComparison.InvariantCultureIgnoreCase))
                {
                    Assert.Fail();
                }
            }

            await Task.Delay(10000);

            Assert.Pass();
        }
    }
}
