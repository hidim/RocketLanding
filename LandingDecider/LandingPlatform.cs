using LandingDecider.Model;
using System;

namespace LandingDecider
{
    public class LandingPlatform
    {
        /// <summary>
        /// Gets or sets Landing area as a square model.
        /// </summary>
        private SquareModel landingArea { get; set; }

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
    }
}
