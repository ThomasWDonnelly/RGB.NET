using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RGB.NET.Core;
using RGB.NET.Devices.Aura;
using RGB.NET.Devices.Corsair;
using System.Threading;
using HidLibrary;
using RGB.NET.Groups;
using System.Diagnostics;

namespace RGB.NET.Hub
{
    class Core
    {
        static void Main(string[] args)
        {
           // RunAsInefficientThreads();
            RunAsSingleTask();
        }

        static void RunAsSingleTask()
        {
            HidDevice corsairLNP = HidDevices.Enumerate().ToArray().First(d => d.Attributes.ProductHexId == "0x0C0B");
            corsairLNP.MonitorDeviceEvents = true;
            corsairLNP.OpenDevice();

            RGBSurface surface = RGBSurface.Instance;
            surface.Exception += args => Debug.WriteLine(args.Exception.Message);
            surface.UpdateMode = UpdateMode.Continuous;
            surface.LoadDevices(AuraDeviceProvider.Instance);
            surface.LoadDevices(CorsairDeviceProvider.Instance);

            AuraMainboardRGBDevice auraMb = surface.Devices.OfType<AuraMainboardRGBDevice>().First();
            CorsairKeyboardRGBDevice corsairKeyboard = surface.Devices.OfType<CorsairKeyboardRGBDevice>().First();
            CorsairMousepadRGBDevice corsairMousepad = surface.Devices.OfType<CorsairMousepadRGBDevice>().First();

            LightingNodeUtils.firstTransaction(corsairLNP);

            while (true)
            {
                byte[] boardColor = auraMb.CurrentColorData();

                Color backIOColor = new Color(boardColor[0], boardColor[2], boardColor[1]);
                Color pchColor = new Color(boardColor[3], boardColor[5], boardColor[4]);
                Color headerOneColor = new Color(boardColor[6], boardColor[8], boardColor[7]);
                Color headerTwoColor = new Color(boardColor[9], boardColor[11], boardColor[10]);

                Task[] setColors = new Task[3];
                setColors[0] = Task.Factory.StartNew(() => SetLNP(corsairLNP, backIOColor, headerTwoColor, pchColor, headerOneColor));
                setColors[1] = Task.Factory.StartNew(() => SetKeyboard(corsairKeyboard, backIOColor, pchColor, headerOneColor, headerTwoColor));
                setColors[2] = Task.Factory.StartNew(() => SetMousepad(corsairMousepad, backIOColor, pchColor, headerOneColor, headerTwoColor));

                Task.WaitAll(setColors);
                
            }
        }

        static void SetKeyboard(CorsairKeyboardRGBDevice keyboard, Color c1, Color c2, Color c3, Color c4)
        {
            foreach (Led led in keyboard)
            {
                if (led.LedRectangle.Location.X < 450 / 4)
                {
                    led.Color = c1;
                }
                else if (led.LedRectangle.Location.X < (450 / 4) * 2)
                {
                    led.Color = c2;
                }
                else if (led.LedRectangle.Location.X < (450 / 4) * 3)
                {
                    led.Color = c3;
                }
                else
                {
                    led.Color = c4;
                }
            }
        }
        static void SetMousepad(CorsairMousepadRGBDevice mousepad, Color c1, Color c2, Color c3, Color c4)
        {
            for (int i = 0; i < mousepad.Count(); i++)
            {
                if (i < 4)
                {
                    mousepad.ElementAt(i).Color = c1;
                }
                else if (i < 7)
                {
                    mousepad.ElementAt(i).Color = c2;
                }
                else if (7 < i && i < 11)
                {
                    mousepad.ElementAt(i).Color = c3;
                }
                else if (10 < i && i < 15)
                {
                    mousepad.ElementAt(i).Color = c4;
                }
                else
                {
                    mousepad.ElementAt(i).Color = ColorUtils.colorMixer(c2, c3);
                }
            }
        }
        static void SetLNP(HidDevice lnp, Color c1, Color c2, Color c3, Color c4)
        {
            LightingNodeUtils.beignTransaction(lnp);

            byte[][] stripInfo = LightingNodeUtils.fourStripsFromZones(c1, c2, c3, c4);

            for (int i = 0; i < stripInfo.Length; i++)
            {
                lnp.Write(stripInfo[i]);
            }

            byte[][] fanInfo = LightingNodeUtils.sixFansFromZones(c1, c2, c3, c4);

            for (int i = 0; i < fanInfo.Length; i++)
            {
                lnp.Write(fanInfo[i]);
            }

            LightingNodeUtils.submitTransaction(lnp);
        }


        static void RunAsInefficientThreads()
        {
            AuraSync auraControlsCue = new AuraSync();

            LightingNodePro auraControlsLNP = new LightingNodePro();

            Thread lightCue = new Thread(new ThreadStart(auraControlsCue.run));
            Thread lightLNP = new Thread(new ThreadStart(auraControlsLNP.run));

            lightCue.Start();
            lightLNP.Start();

            Console.ReadKey();

            lightCue.Abort();
            lightLNP.Abort();
        }

    }
}
