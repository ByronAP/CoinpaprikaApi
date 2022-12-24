namespace Tests
{
    internal class PersonsTests
    {
        [Test]
        public async Task GetPersonTest()
        {
            var callResult = await (await Helpers.GetApiClient()).Persons.GetPersonAsync("vitalik-buterin");

            Assert.That(callResult, Is.Not.Null);
            Assert.That(callResult.Id, Is.EqualTo("vitalik-buterin"));
        }
    }
}
