﻿// ReSharper disable InconsistentNaming

#pragma warning disable 1591 // Missing XML comment for publicly visible type or member

namespace RGB.NET.Devices.Asus
{
    /// <summary>
    /// Contains list of all LEDs available for all Asus devices.
    /// </summary>
    public enum AsusLedIds
    {
        Invalid = -1,

        //TODO DarthAffe 07.10.2017: Create useful Ids for all devices

        MainboardAudio1 = 0x01,
        MainboardAudio2 = 0x02,
        MainboardAudio3 = 0x03,
        MainboardAudio4 = 0x04,
        MainboardRGBStrip1 = 0x05,

        GraphicsCardLed1 = 0x11,

        DramLed1 = 0x21,

        MouseLed1 = 0x31,

        KeyboardLed1 = 0x41,
    }
}
