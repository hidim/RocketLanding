using System.Collections.Generic;

namespace LandingDecider.Model
{
    internal class LandingPlatformModel
    {
        public int PlatformWidth { get; set; }
        public int PlatgormHeight { get; set; }
        public int LandingAreaWidth { get; set; }
        public int LandingAreaHeight { get; set; }
        public int StartIndexX { get; set; }
        public int StartIndexY { get; set; }
        public List<RocketLandingModel> PreviousRockets { get; set; }
    }
}