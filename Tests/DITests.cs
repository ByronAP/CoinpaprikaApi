namespace Tests
{
    internal class DITests
    {
        [Test]
        public void CreateViaDITest()
        {
            var services = new ServiceCollection();

            services.AddLogging();
            services.AddCoinpaprikaApi();

            using var provider = services.BuildServiceProvider();

            var api = provider.GetService<CoinpaprikaClient>();

            Assert.That(api, Is.Not.Null);

            Assert.That(api.CPRestClient.Options.BaseUrl, Is.Not.Null);
            Assert.That(api.CPRestClient.Options.BaseUrl.ToString(), Is.EqualTo(Constants.API_BASE_URL + "/"));
        }

        [Test]
        public void CreateViaDIWithApiKeyTest()
        {
            var services = new ServiceCollection();

            services.AddLogging();
            services.AddCoinpaprikaApi("FakeApiKey");

            using var provider = services.BuildServiceProvider();

            var api = provider.GetService<CoinpaprikaClient>();

            Assert.That(api, Is.Not.Null);

            Assert.That(api.CPRestClient.Options.BaseUrl, Is.Not.Null);
            Assert.That(api.CPRestClient.Options.BaseUrl.ToString(), Is.EqualTo(Constants.API_PRO_BASE_URL));
        }
    }
}
