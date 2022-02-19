using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LandingDecider.Tests
{
    [TestClass]
    public class RocketLandingTests : IDisposable
    {
        private LandingDecider.LandingPlatform landingPlatform;

        [TestMethod]
        public void RocketLanding_DefaultPlatform_OneRocket_SuccessLanding()
        {
            landingPlatform = new LandingPlatform();

            string expectedResult = "ok for landing";

            string oneRocketResult = landingPlatform.LandingQuery("1", 5, 5);

            Assert.AreEqual(expectedResult, oneRocketResult);
        }

        [TestMethod]
        public void RocketLanding_DefaultPlatform_OneRocket_OutOfPlatformLanding()
        {
            landingPlatform = new LandingPlatform();

            string expectedResult = "out of platform";

            string oneRocketResult = landingPlatform.LandingQuery("1", 16, 15);

            Assert.AreEqual(expectedResult, oneRocketResult);
        }

        [TestMethod]
        public void RocketLanding_DefaultPlatform_TwoRocket_SuccessLanding()
        {
            landingPlatform = new LandingPlatform();

            string expectedResult = "ok for landing";

            string firstRocketResult = landingPlatform.LandingQuery("1", 7, 7);
            string secondRocketResult = landingPlatform.LandingQuery("2", 10, 10);

            Assert.AreEqual(expectedResult, secondRocketResult);
        }

        [TestMethod]
        public void RocketLanding_DefaultPlatform_TwoRocket_CrashLanding()
        {
            landingPlatform = new LandingPlatform();

            string expectedResult = "clash";

            string firstRocketResult = landingPlatform.LandingQuery("1", 7, 7);
            string secondRocketResult = landingPlatform.LandingQuery("2", 8, 7);

            Assert.AreEqual(expectedResult, secondRocketResult);
        }

        [TestMethod]
        public void RocketLanding_DefaultPlatform_TwoRocket_MultipleLandingTry()
        {
            landingPlatform = new LandingPlatform();

            string expectedResult = "clash";
            bool multipleResult = false;

            string firstRocketResult = landingPlatform.LandingQuery("1", 7, 7);
            string secondRocketTry1 = landingPlatform.LandingQuery("2", 7, 8);
            string secondRocketTry2 = landingPlatform.LandingQuery("2", 6, 7);
            string secondRocketTry3 = landingPlatform.LandingQuery("2", 6, 6);

            if (secondRocketTry1 == expectedResult && secondRocketTry2 == expectedResult && secondRocketTry3 == expectedResult)
                multipleResult = true;
            else
                multipleResult = false;

            Assert.IsTrue(multipleResult);
        }

        [TestMethod]
        public void RocketLanding_DefaultPlatform_TwoRocket_MultipleLandingCheck()
        {
            landingPlatform = new LandingPlatform();

            string expectedResult = "clash";
            bool multipleResult = false;

            string firstRocketTry1 = landingPlatform.LandingQuery("1", 7, 7);
            string firstRocketTry2 = landingPlatform.LandingQuery("1", 10, 8);
            string secondRocketTry1 = landingPlatform.LandingQuery("2", 7, 8);
            string secondRocketTry2 = landingPlatform.LandingQuery("2", 6, 7);
            string secondRocketTry3 = landingPlatform.LandingQuery("2", 6, 6);

            if (secondRocketTry1 == expectedResult && secondRocketTry2 == expectedResult && secondRocketTry3 == "ok for landing")
                multipleResult = true;
            else
                multipleResult = false;

            Assert.IsTrue(multipleResult);
        }

        ~RocketLandingTests()
        {
            landingPlatform.Dispose();
        }

        public void Dispose()
        {
            landingPlatform.Dispose();
        }
    }
}
