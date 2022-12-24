namespace Tests
{
    internal class TagsTests
    {
        [Test]
        public async Task GetTagsTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Tags.GetTagsAsync();

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }

        [Test]
        public async Task GetTagTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Tags.GetTagAsync("blockchain-service", true, true);

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult.Coins, Is.Not.Empty);
        }
    }
}
