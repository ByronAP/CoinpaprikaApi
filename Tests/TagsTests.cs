namespace Tests
{
    internal class TagsTests
    {
        [Test]
        public async Task GetTagsTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Tags.GetTagsAsync();

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }

        [Test]
        public async Task GetTagTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Tags.GetTagAsync("blockchain-service", true, true);

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult.Coins, Is.Not.Empty);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }
    }
}
