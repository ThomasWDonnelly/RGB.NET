// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

using System;
using RGB.NET.Core;
using RGB.NET.Devices.Corsair.Native;

namespace RGB.NET.Devices.Corsair
{
    /// <summary>
    /// Represents specific information for a CUE headset stand.
    /// </summary>
    public class CorsairHeadsetStandRGBDeviceInfo : CorsairRGBDeviceInfo
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Internal constructor of managed <see cref="CorsairHeadsetStandDeviceInfo" />.
        /// </summary>
        /// <param name="deviceIndex">The index of the <see cref="T:RGB.NET.Devices.Corsair.CorsairHeadsetStandRGBDevice" />.</param>
        /// <param name="nativeInfo">The native <see cref="T:RGB.NET.Devices.Corsair.Native._CorsairDeviceInfo" />-struct</param>
        internal CorsairHeadsetStandRGBDeviceInfo(int deviceIndex, _CorsairDeviceInfo nativeInfo)
            : base(deviceIndex, RGBDeviceType.HeadsetStand, nativeInfo)
        { }

        #endregion
    }
}