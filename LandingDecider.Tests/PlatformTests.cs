using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LandingDecider.Tests
{
    [TestClass]
    public class PlatformTests
    {
        private LandingDecider.LandingPlatform landingPlatform;

        [TestMethod]
        public void InitPlatform_DefaultParameters()
        {
            // Init landing platform with default parameters.
            landingPlatform = new LandingPlatform();

            Assert.IsTrue(landingPlatform.ValidateLandingPlatform());
        }

        [TestMethod]
        public void InitPlatform_CustomParameters()
        {
            // Init landing platform with custom parameters.
            Model.SquareModel landingArea = new Model.SquareModel { Width = 345, Height = 343 };
            Model.SquareModel platform = new Model.SquareModel { Width = 66, Height = 68 };
            Model.SquareModel startIndex = new Model.SquareModel { Width = 11, Height = 22 };

            landingPlatform = new LandingPlatform(landingArea, platform, startIndex);

            Assert.IsTrue(landingPlatform.ValidateLandingPlatform());
        }

        [TestMethod]
        public void InitPlatform_WrongParameters()
        {
            // Init landing platform with wrong parameters.
            Model.SquareModel platform = new Model.SquareModel { Width = 345, Height = 343 };
            Model.SquareModel landingArea = new Model.SquareModel { Width = 66, Height = 68 };
            Model.SquareModel startIndex = new Model.SquareModel { Width = 11, Height = 22 };

            landingPlatform = new LandingPlatform(landingArea, platform, startIndex);

            Assert.IsFalse(landingPlatform.ValidateLandingPlatform());
        }
    }
}
