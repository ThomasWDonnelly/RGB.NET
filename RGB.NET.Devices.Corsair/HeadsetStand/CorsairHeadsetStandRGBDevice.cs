﻿// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using RGB.NET.Core;
using RGB.NET.Devices.Corsair.Native;

namespace RGB.NET.Devices.Corsair
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a corsair headset stand.
    /// </summary>
    public class CorsairHeadsetStandRGBDevice : CorsairRGBDevice<CorsairHeadsetStandRGBDeviceInfo>
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:RGB.NET.Devices.Corsair.CorsairHeadsetStandRGBDevice" /> class.
        /// </summary>
        /// <param name="info">The specific information provided by CUE for the headset stand</param>
        internal CorsairHeadsetStandRGBDevice(CorsairHeadsetStandRGBDeviceInfo info)
            : base(info)
        { }

        #endregion

        #region Methods

        /// <inheritdoc />
        protected override void InitializeLayout()
        {
            _CorsairLedPositions nativeLedPositions = 
                (_CorsairLedPositions)
                Marshal.PtrToStructure(_CUESDK.CorsairGetLedPositionsByDeviceIndex(DeviceInfo.CorsairDeviceIndex),
                                       typeof(_CorsairLedPositions));

            int structSize = Marshal.SizeOf(typeof(_CorsairLedPosition));
            IntPtr ptr = nativeLedPositions.pLedPosition;

            // Put the positions in an array for sorting later on
            List<_CorsairLedPosition> positions = new List<_CorsairLedPosition>();
            for (int i = 0; i < nativeLedPositions.numberOfLed; i++)
            {
                _CorsairLedPosition ledPosition = (_CorsairLedPosition)Marshal.PtrToStructure(ptr, typeof(_CorsairLedPosition));
                ptr = new IntPtr(ptr.ToInt64() + structSize);
                positions.Add(ledPosition);
            }

            foreach (_CorsairLedPosition ledPosition in positions.OrderBy(p => p.ledId))
                InitializeLed(new CorsairLedId(this, ledPosition.ledId),
                              new Rectangle(ledPosition.left, ledPosition.top, ledPosition.width, ledPosition.height));

            ApplyLayoutFromFile(PathHelper.GetAbsolutePath($@"Layouts\Corsair\HeadsetStands\{DeviceInfo.Model.Replace(" ", string.Empty).ToUpper()}.xml"),
                null, PathHelper.GetAbsolutePath(@"Images\Corsair\HeadsetStands"));
        }

        #endregion
    }
}
