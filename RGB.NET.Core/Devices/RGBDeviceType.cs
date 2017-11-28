﻿using System;

namespace RGB.NET.Core
{
    /// <summary>
    /// Contains a list of different types of device.
    /// </summary>
    [Flags]
    public enum RGBDeviceType
    {
        /// <summary>
        /// Represents a device where the type is not known or not present in the list.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Represents a keyboard.
        /// </summary>
        Keyboard = 1 << 0,

        /// <summary>
        /// Represents a mouse.
        /// </summary>
        Mouse = 1 << 1,

        /// <summary>
        /// Represents a headset.
        /// </summary>
        Headset = 1 << 2,

        /// <summary>
        /// Represents a mousepad.
        /// </summary>
        Mousepad = 1 << 3,

        /// <summary>
        /// Represents a LED-stipe.
        /// </summary>
        LedStripe = 1 << 4,

        /// <summary>
        /// Represents a LED-matrix.
        /// </summary>
        LedMatrix = 1 << 5,

        /// <summary>
        /// Represents a Mainboard.
        /// </summary>
        Mainboard = 1 << 6,

        /// <summary>
        /// Represents a Graphics card
        /// </summary>
        GraphicsCard = 1 << 7,

        /// <summary>
        /// Represents a DRAM-bank
        /// </summary>
        DRAM = 1 << 8,

        /// <summary>
        /// Represents a headset stand.
        /// </summary>
        HeadsetStand = 1 << 9,
    }
}
