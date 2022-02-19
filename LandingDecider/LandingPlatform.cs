using LandingDecider.Helper;
using LandingDecider.Model;
using System;
using System.Linq;

namespace LandingDecider
{
    public class LandingPlatform : IDisposable
    {
        private JsonDataHelper jsonDataHelper;

        /// <summary>
        /// Gets or sets Landing area as a square model.
        /// </summary>
        public SquareModel landingArea { get; set; }

        /// <summary>
        /// Gets or sets Landing Platform as a square model.
        /// </summary>
        private SquareModel landingPlatform { get; set; }

        /// <summary>
        /// Gets or sets Start Index as a square model.
        /// </summary>
        private SquareModel startIndex { get; set; }

        /// <summary>
        /// Uses default values as Landing Decider Inits. 
        /// </summary>
        public LandingPlatform()
        {
            // if there is no specification use defaults
            // Landing area is 100x100 box
            this.landingArea = new SquareModel { Width = 100, Height = 100 };

            // Landing Platform 10x10 box
            this.landingPlatform = new SquareModel { Width = 10, Height = 10 };

            // Platform's start index as coordinates (box is a minimum diamater)
            this.startIndex = new SquareModel { Width = 5, Height = 5 };

            jsonDataHelper = new JsonDataHelper();
        }

        /// <summary>
        /// Uses configurable landing decider init. 
        /// </summary>
        /// <param name="landingArea">Square model landing area.</param>
        /// <param name="landingPlatform">Square model landing platform.</param>
        /// <param name="startIndex">Square model start position for landing platform.</param>
        public LandingPlatform(SquareModel landingArea, SquareModel landingPlatform, SquareModel startIndex)
        {
            if (landingArea != null)
            {
                this.landingArea = landingArea;
            }
            else
            {
                this.landingArea = new SquareModel { Width = 100, Height = 100 };
            }

            if (landingPlatform != null)
            {
                this.landingPlatform = landingPlatform;
            }
            else
            {
                this.landingPlatform = new SquareModel { Width = 10, Height = 10 };
            }

            if (startIndex != null)
            {
                this.startIndex = startIndex;
            }
            else
            {
                this.startIndex = new SquareModel { Width = 5, Height = 5 };
            }
        }

        /// <summary>
        /// Validates configurable landing area and platform categories.
        /// </summary>
        /// <returns>Validation result</returns>
        public bool ValidateLandingPlatform()
        {
            bool is_valid = false;

            if (landingArea.Height > landingPlatform.Height && landingArea.Width > landingPlatform.Width
                && landingArea.Width >= landingPlatform.Width + startIndex.Width
                && landingArea.Height >= landingPlatform.Height + startIndex.Height)
                is_valid = true;

            return is_valid;
        }

        public string LandingQuery(string rocketId, int landingXAxis, int landingYAxis)
        {
            string oResponse = string.Empty;

            // Get data from landing platfom.
            LandingPlatformModel landingPlatformModel = new LandingPlatformModel();
            landingPlatformModel = jsonDataHelper.ReadPlatform();

            if (landingPlatformModel == null)
            {
                landingPlatformModel = new LandingPlatformModel
                {
                    LandingAreaHeight = landingArea.Height,
                    LandingAreaWidth = landingArea.Width,

                    PlatformWidth = landingPlatform.Width,
                    PlatgormHeight = landingPlatform.Height,

                    StartIndexX = startIndex.Width,
                    StartIndexY = startIndex.Height,
                };
            }

            // Requested coordinates is in landing platform?
            if (landingXAxis < startIndex.Width || landingXAxis > startIndex.Width + landingPlatform.Width
                || landingYAxis < startIndex.Height || landingYAxis > startIndex.Height + landingPlatform.Height)
                return "out of platform";

            if (landingPlatformModel.PreviousRockets != null)
            {
                foreach (var prevRocket in landingPlatformModel.PreviousRockets)
                {
                    if (prevRocket.RocketName != rocketId)
                    {
                        if (landingXAxis >= prevRocket.LandingArea.Width - 1 && landingXAxis <= prevRocket.LandingArea.Width + 1)
                            return "clash";

                        if (landingYAxis >= prevRocket.LandingArea.Height - 1 && landingYAxis <= prevRocket.LandingArea.Height + 1)
                            return "clash";
                    }
                }
            }
            else
                landingPlatformModel.PreviousRockets = new System.Collections.Generic.List<RocketLandingModel>();

            landingPlatformModel.PreviousRockets.Remove(landingPlatformModel.PreviousRockets.Where(_t => _t.RocketName == rocketId).FirstOrDefault());
            landingPlatformModel.PreviousRockets.Add(new RocketLandingModel { RocketName = rocketId, LandingArea = new SquareModel { Width = landingXAxis, Height = landingYAxis } });

            // Write data to landing platform.
            jsonDataHelper.WritePlatform(landingPlatformModel);

            return "ok for landing";
        }

        ~LandingPlatform()
        {
            // Empties the platform when dispose.
            jsonDataHelper.EmptyPlatform();
        }

        public void Dispose()
        {
            // Empties the platform when dispose.
            jsonDataHelper.EmptyPlatform();
        }
    }
}
