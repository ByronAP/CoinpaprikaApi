namespace Tests
{
    internal class PersonsTests
    {
        [Test]
        public async Task GetPersonTest()
        {
            try
            {
                var callResult = await (await Helpers.GetApiClient()).Persons.GetPersonAsync("vitalik-buterin");

                Assert.That(callResult, Is.Not.Null);
                Assert.That(callResult.Id, Is.EqualTo("vitalik-buterin"));
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.PaymentRequired)
            {
                Assert.Warn(ex.Message);
            }
        }
    }
}
