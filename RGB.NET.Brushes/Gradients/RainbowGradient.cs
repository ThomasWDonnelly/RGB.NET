﻿// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

using RGB.NET.Core;

namespace RGB.NET.Brushes.Gradients
{
    /// <inheritdoc cref="AbstractDecoratable{T}" />
    /// <inheritdoc cref="IGradient" />
    /// <summary>
    /// Represents a rainbow gradient which circles through all colors of the HUE-color-space.<br />
    /// See <see href="http://upload.wikimedia.org/wikipedia/commons/a/ad/HueScale.svg" /> as reference.
    /// </summary>
    public class RainbowGradient : AbstractDecoratable<IGradientDecorator>, IGradient
    {
        #region Properties & Fields

        /// <summary>
        /// Gets or sets the hue (in degrees) to start from.
        /// </summary>
        public double StartHue { get; set; }

        /// <summary>
        /// Gets or sets the hue (in degrees) to end the with.
        /// </summary>
        public double EndHue { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RainbowGradient"/> class.
        /// </summary>
        /// <param name="startHue">The hue (in degrees) to start from (default: 0)</param>
        /// <param name="endHue">The hue (in degrees) to end with (default: 360)</param>
        public RainbowGradient(double startHue = 0, double endHue = 360)
        {
            this.StartHue = startHue;
            this.EndHue = endHue;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        /// <summary>
        /// Gets the color on the rainbow at the given offset.
        /// </summary>
        /// <param name="offset">The percentage offset to take the color from.</param>
        /// <returns>The color at the specific offset.</returns>
        public Color GetColor(double offset)
        {
            double range = EndHue - StartHue;
            double hue = (StartHue + (range * offset)) % 360f;
            if (hue < 0)
                hue += 360;
            return new Color(hue, 1f, 1f);
        }

        /// <inheritdoc />
        public void Move(double offset)
        {
            // RainbowGradient is calculated inverse
            offset *= -1;

            StartHue += offset;
            EndHue += offset;

            while ((StartHue > 360) && (EndHue > 360))
            {
                StartHue -= 360;
                EndHue -= 360;
            }
            while ((StartHue < -360) && (EndHue < -360))
            {
                StartHue += 360;
                EndHue += 360;
            }
        }

        #endregion
    }
}
