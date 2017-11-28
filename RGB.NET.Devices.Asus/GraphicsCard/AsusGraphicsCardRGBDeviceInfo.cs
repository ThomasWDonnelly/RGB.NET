﻿using System;
using RGB.NET.Core;

namespace RGB.NET.Devices.Asus
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a generic information for a <see cref="T:RGB.NET.Devices.Asus.AsusGraphicsCardRGBDevice" />.
    /// </summary>
    public class AsusGraphicsCardRGBDeviceInfo : AsusRGBDeviceInfo
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Internal constructor of managed <see cref="T:RGB.NET.Devices.Asus.AsusGraphicsCardRGBDeviceInfo" />.
        /// </summary>
        /// <param name="deviceType">The type of the <see cref="IRGBDevice"/>.</param>
        /// <param name="handle">The handle of the <see cref="IRGBDevice"/>.</param>
        internal AsusGraphicsCardRGBDeviceInfo(RGBDeviceType deviceType, IntPtr handle)
            : base(deviceType, handle)
        {
            Image = new Uri(PathHelper.GetAbsolutePath($@"Images\Asus\GraphicsCards\{Model.Replace(" ", string.Empty).ToUpper()}.png"), UriKind.Absolute);
        }

        #endregion
    }
}
