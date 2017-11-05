using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RGB.NET.Core;
using RGB.NET.Devices.Aura;
using RGB.NET.Devices.Corsair;
using System.Threading;

namespace RGB.NET.Hub
{
    class Core
    {
        static void Main(string[] args)
        {
            bool lightingUp = true;

            AuraSync asServ = new AuraSync();

            asServ.run();

            var t = new Thread(() => (new AuraSync()).run());

            while (lightingUp)
            {
                System.ConsoleKeyInfo k = System.Console.ReadKey();

                if (k.Equals(System.ConsoleKey.Enter))
                {
                    lightingUp = false;
                }
            }

            
            
        }
    }
}
