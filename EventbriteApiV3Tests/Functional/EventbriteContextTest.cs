using System.Linq;
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
            Context = new EventbriteContext(FakeAppKey, Constants.MockServerUrl);
        }

        [TestMethod]
        public void ItShouldReturnAListOfAttendeeWhenGetAttendees()
        {
            var result = Context.GetAttendees(FakeEventId, new BaseSearchCriterias());

            Assert.AreNotEqual(result, null);
            Assert.AreNotEqual(result.Pagination, null);
            Assert.IsTrue(result.Attendees.Any());
        }

        [TestMethod]
        public void ItShouldReturnAListOfEventsWhenGetEvents()
        {
            var result = Context.GetEvents(new BaseSearchCriterias());

            Assert.AreNotEqual(result, null);
            Assert.AreNotEqual(result.Pagination, null);
            Assert.IsTrue(result.Events.Any());
        }
    }
}
