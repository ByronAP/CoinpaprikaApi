﻿namespace Tests
{
    internal class ContractsTests
    {
        [Test]
        public async Task GetPlatformsTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Contracts.GetPlatformsAsync();

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }

        [Test]
        public async Task GetContractsTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Contracts.GetContractsAsync("eth-ethereum");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }

        [Test]
        public async Task GetTickerByContractAddressTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Contracts.GetTickerByContractAddressAsync("eth-ethereum", "0xd26114cd6ee289accf82350c8d8487fedb8a0c07");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult.Quotes, Is.Not.Empty);
        }

        [Test]
        public async Task GetHistoricalTicksByContractAddressTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Contracts.GetHistoricalTicksByContractAddressAsync("eth-ethereum", "0xd26114cd6ee289accf82350c8d8487fedb8a0c07", DateTimeOffset.UtcNow.AddDays(-5), interval: CoinpaprikaApi.Types.TickerInterval.d1);

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult, Is.Not.Empty);
        }
    }
}
