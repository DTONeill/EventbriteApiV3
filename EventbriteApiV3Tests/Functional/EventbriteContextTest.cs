using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EventbriteApiV3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventbriteApiV3Tests.Functional
{
    [TestClass]
    public class EventbriteContextTest
    {
        public EventbriteContext Context;
        public const double FakeEventId = 198934234;
        public const string FakeAppKey = "fakeAppKey";

        public EventbriteContextTest()
        {
            //TODO
            Context = new EventbriteContext(Mockup.GetMyHandler(""), FakeAppKey, Constants.MockServerUrl);
        }

       //TODO
        [TestMethod]
        public async Task ItShouldReturnAListOfAttendeeWhenGetAttendeesAsync()
        {
            var result = await Context.GetAttendeesAsync(FakeEventId, new BaseSearchCriterias());

            Assert.AreNotEqual(result, null);
            Assert.AreNotEqual(result.Pagination, null);
            Assert.IsTrue(result.Attendees.Any());
        }
        [TestMethod]
        public async Task ItShouldReturnAListOfEventsWhenGetEvents()
        {
            var source = await System.IO.File.ReadAllTextAsync("Resources/events.json");
            Context = new EventbriteContext(Mockup.GetMyHandler(source), FakeAppKey, Constants.MockServerUrl);

            var result = await Context.GetEvents(new BaseSearchCriterias());

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Pagination);
            Assert.IsTrue(result.Events.Any());
        }
       
    }
}
