﻿using RGB.NET.Core;
using RGB.NET.Devices.Asus.Native;

namespace RGB.NET.Devices.Asus
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a Asus graphicsCard.
    /// </summary>
    public class AsusGraphicsCardRGBDevice : AsusRGBDevice<AsusGraphicsCardRGBDeviceInfo>
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:RGB.NET.Devices.Asus.AsusGraphicsCardRGBDevice" /> class.
        /// </summary>
        /// <param name="info">The specific information provided by Asus for the graphics card.</param>
        internal AsusGraphicsCardRGBDevice(AsusGraphicsCardRGBDeviceInfo info)
            : base(info)
        { }

        #endregion

        #region Methods

        /// <inheritdoc />
        protected override void InitializeLayout()
        {
            //TODO DarthAffe 07.10.2017: Look for a good default layout
            int ledCount = _AsusSDK.GetGPULedCount(DeviceInfo.Handle);
            for (int i = 0; i < ledCount; i++)
                InitializeLed(new AsusLedId(this, AsusLedIds.GraphicsCardLed1 + i, i), new Rectangle(i * 10, 0, 10, 10));

            //TODO DarthAffe 07.10.2017: We don'T know the model, how to save layouts and images?
            ApplyLayoutFromFile(PathHelper.GetAbsolutePath($@"Layouts\Asus\GraphicsCards\{DeviceInfo.Model.Replace(" ", string.Empty).ToUpper()}.xml"),
                null, PathHelper.GetAbsolutePath(@"Images\Asus\GraphicsCards"));
        }

        /// <inheritdoc />
        protected override void ApplyColorData() => _AsusSDK.SetGPUColor(DeviceInfo.Handle, ColorData);

        /// <inheritdoc />
        public override byte[] GetColors()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
