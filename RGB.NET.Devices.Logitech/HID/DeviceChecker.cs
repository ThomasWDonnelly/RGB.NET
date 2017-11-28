﻿using System.Collections.Generic;
using System.Linq;
using HidSharp;
using RGB.NET.Core;

namespace RGB.NET.Devices.Logitech.HID
{
    //TODO DarthAffe 04.02.2017: Rewrite this once the SDK supports per-device lighting to get all the devices connected.
    internal static class DeviceChecker
    {
        #region Constants

        private const int VENDOR_ID = 0x046D;
        
        //TODO DarthAffe 14.11.2017: Add devices
        private static readonly List<(string model, RGBDeviceType deviceType, int id, string imageBasePath, string imageLayout, string layoutPath)> PER_KEY_DEVICES
                = new List<(string model, RGBDeviceType deviceType, int id, string imageBasePath, string imageLayout, string layoutPath)>
                  {
                      ("G910", RGBDeviceType.Keyboard, 0xC32B, "Keyboards", "DE", @"Keyboards\G910\UK"), //TODO DarthAffe 15.11.2017: Somehow detect the current layout
                      ("G610", RGBDeviceType.Keyboard, 0xC333, "Keyboards", "DE", @"Keyboards\G610\UK"),
                  };

        private static readonly List<(string model, RGBDeviceType deviceType, int id, string imageBasePath, string imageLayout, string layoutPath)> PER_DEVICE_DEVICES
            = new List<(string model, RGBDeviceType deviceType, int id, string imageBasePath, string imageLayout, string layoutPath)>
              {
                  ("G403", RGBDeviceType.Mouse, 0xC083, "Mice", "default", @"Mice\G403"),
                  ("G502", RGBDeviceType.Mouse, 0xC332, "Mice", "default", @"Mice\G502"),
              };

        #endregion

        #region Properties & Fields

        public static bool IsPerKeyDeviceConnected { get; private set; }
        public static (string model, RGBDeviceType deviceType, int id, string imageBasePath, string imageLayout, string layoutPath) PerKeyDeviceData { get; private set; }

        public static bool IsPerDeviceDeviceConnected { get; private set; }
        public static (string model, RGBDeviceType deviceType, int id, string imageBasePath, string imageLayout, string layoutPath) PerDeviceDeviceData { get; private set; }

        #endregion

        #region Methods

        internal static void LoadDeviceList()
        {
            HidDeviceLoader loader = new HidDeviceLoader();
            List<int> ids = loader.GetDevices(VENDOR_ID).Select(x => x.ProductID).Distinct().ToList();

            foreach ((string model, RGBDeviceType deviceType, int id, string imageBasePath, string imageLayout, string layoutPath) deviceData in PER_KEY_DEVICES)
                if (ids.Contains(deviceData.id))
                {
                    IsPerKeyDeviceConnected = true;
                    PerKeyDeviceData = deviceData;
                    break;
                }

            foreach ((string model, RGBDeviceType deviceType, int id, string imageBasePath, string imageLayout, string layoutPath) deviceData in PER_DEVICE_DEVICES)
                if (ids.Contains(deviceData.id))
                {
                    IsPerDeviceDeviceConnected = true;
                    PerDeviceDeviceData = deviceData;
                    break;
                }
        }

        #endregion
    }
}
