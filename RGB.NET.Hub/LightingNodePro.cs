using HidLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RGB.NET.Core;
using RGB.NET.Devices.Aura;

namespace RGB.NET.Hub
{
    class LightingNodePro
    {
        HidDevice corsairLNP;
        byte[] lnpData = new byte[16];

        RGBSurface surface;
        AuraMainboardRGBDevice auraMb;

        public void run()
        {
            corsairLNP = HidDevices.Enumerate().ToArray().First(d => d.Attributes.ProductHexId == "0x0C0B");
            corsairLNP.MonitorDeviceEvents = true;
            corsairLNP.OpenDevice();

            surface = RGBSurface.Instance;
            surface.LoadDevices(AuraDeviceProvider.Instance);
            auraMb = surface.Devices.OfType<AuraMainboardRGBDevice>().First();

            LightingNodeUtils.firstTransaction(corsairLNP);

            while (true)
            {
                byte[] boardColor = auraMb.CurrentColorData();

                Color backIOColor = new Color(boardColor[0], boardColor[2], boardColor[1]);

                LightingNodeUtils.beignTransaction(corsairLNP);

                //for (int strip = 1; strip <= 4; strip++)
                {
                    byte[][] colorInfo = LightingNodeUtils.fourStrips(backIOColor);
                    
                    for (int i = 0; i < colorInfo.Length; i++)
                    {
                        corsairLNP.Write(colorInfo[i]);
                    }
                }

                //for (int fan = 1; fan <= 7; fan++)
                {
                    byte[][] colorInfo = LightingNodeUtils.sixFans(backIOColor);

                    for (int i = 0; i < colorInfo.Length; i++)
                    {
                        corsairLNP.Write(colorInfo[i]);
                    }
                }

                LightingNodeUtils.submitTransaction(corsairLNP);

                System.Threading.Thread.Sleep(00);
            }

            //lnpData = corsairLNP.Read().Data;
            //Console.Write("\n \n \n {0,2:X}", BitConverter.ToString(lnpData).Replace("-", " "));

        }

    }

}


