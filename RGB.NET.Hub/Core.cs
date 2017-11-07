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

namespace RGB.NET.Hub
{
    class Core
    {
        static void Main(string[] args)
        {

            AuraSync auraControlsCue = new AuraSync();

            LightingNodePro auraControlsLNP = new LightingNodePro();

            Thread lightCue = new Thread(new ThreadStart(auraControlsCue.run));
            Thread lightLNP = new Thread(new ThreadStart(auraControlsLNP.run));

            lightCue.Start();
            lightLNP.Start();

            Console.ReadKey();
        }

    }
}
