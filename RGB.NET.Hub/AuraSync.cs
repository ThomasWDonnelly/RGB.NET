using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RGB.NET.Devices.Aura;
using RGB.NET.Devices.Corsair;
using System.Threading;
using RGB.NET.Core;
using RGB.NET.Brushes;
using RGB.NET.Decorators;
using RGB.NET.Groups;
using RGB.NET.Brushes.Gradients;
using System.Diagnostics;

namespace RGB.NET.Hub
{
    class AuraSync : AbstractUpdateAwareDecorator
    {
        RGBSurface surface;
        ListLedGroup keyboardLeds;
        ListLedGroup mousepadLeds;

        AuraMainboardRGBDevice auraMb;

        CorsairKeyboardRGBDevice corsairKeyboard;
        CorsairMousepadRGBDevice corsairMousepad;

        public void run()
        {
            surface = RGBSurface.Instance;
            surface.Exception += args => Debug.WriteLine(args.Exception.Message);
            surface.UpdateMode = UpdateMode.Continuous;

            surface.LoadDevices(AuraDeviceProvider.Instance);
            surface.LoadDevices(CorsairDeviceProvider.Instance);

            Color noColor = new Color(0, 0, 0);

            auraMb = surface.Devices.OfType<AuraMainboardRGBDevice>().First();

            corsairKeyboard = surface.Devices.OfType<CorsairKeyboardRGBDevice>().First();
            corsairMousepad = surface.Devices.OfType<CorsairMousepadRGBDevice>().First();

            keyboardLeds = new ListLedGroup(true);
            keyboardLeds.AddLeds(corsairKeyboard);

            mousepadLeds = new ListLedGroup(true);
            mousepadLeds.AddLeds(corsairMousepad);

            Rectangle keyboardLeft = new Rectangle(      10,     5,    150, 150);
            Rectangle keyboardMidLeft = new Rectangle(  100,    15,    150, 160);
            Rectangle keyboardMidRight = new Rectangle( 200,     5,    150, 150);
            Rectangle keyboardRight = new Rectangle(    340,    15,    150, 160);

            Rectangle mousepadTopLeft = new Rectangle(0, 18, 200, 200);
            Rectangle mousepadBottomLeft = new Rectangle(0, 140, 220, 200);
            Rectangle mousepadBottomRight = new Rectangle(150, 140, 220, 220);
            Rectangle mousepadTopRight = new Rectangle(180, 18, 200, 200);

            LinearGradient backIOgradient = new LinearGradient();
            LinearGradient pchGradient = new LinearGradient();
            LinearGradient headerOneGradient = new LinearGradient();
            LinearGradient headerTwoGradient = new LinearGradient();


            /*ConicalGradientBrush backIOConical = new ConicalGradientBrush();
            backIOConical.Center = keyboardLeft.Center;
            backIOConical.Brightness = 200;
            backIOConical.BrushCalculationMode = BrushCalculationMode.Absolute;
            backIOConical.Gradient = backIOgradient;
            RectangleLedGroup keyboardLeftLeds = new RectangleLedGroup(keyboardLeft);
            keyboardLeftLeds.Brush = backIOConical;
            backIOConical.IsEnabled = true;


            ConicalGradientBrush pchConical = new ConicalGradientBrush();
            pchConical.Center = keyboardMidLeft.Center;
            pchConical.Brightness = 200;
            pchConical.BrushCalculationMode = BrushCalculationMode.Absolute;
            pchConical.Gradient = pchGradient;
            RectangleLedGroup keyboardMidLeftLeds = new RectangleLedGroup(keyboardMidLeft);
            keyboardMidLeftLeds.Brush = pchConical;
            pchConical.IsEnabled = true;


            ConicalGradientBrush headerOneConical = new ConicalGradientBrush();
            headerOneConical.Center = keyboardMidRight.Center;
            headerOneConical.Brightness = 200;
            headerOneConical.BrushCalculationMode = BrushCalculationMode.Absolute;
            headerOneConical.Gradient = headerOneGradient;
            RectangleLedGroup keyboardMidRightLeds = new RectangleLedGroup(keyboardMidRight);
            keyboardMidRightLeds.Brush = headerOneConical;
            headerOneConical.IsEnabled = true;


            ConicalGradientBrush headerTwoConical = new ConicalGradientBrush();
            headerTwoConical.Center = keyboardRight.Center;
            headerTwoConical.Brightness = 200;
            headerTwoConical.BrushCalculationMode = BrushCalculationMode.Absolute;
            headerTwoConical.Gradient = headerTwoGradient;
            RectangleLedGroup keyboardRightLeds = new RectangleLedGroup(keyboardRight);
            keyboardRightLeds.Brush = headerTwoConical;
            headerTwoConical.IsEnabled = true;*/


            while (true)
            {
                /*backIOgradient.GradientStops.Add(new Brushes.Gradients.GradientStop(0.1, noColor));
                pchGradient.GradientStops.Add(new Brushes.Gradients.GradientStop(0.1, noColor));
                headerOneGradient.GradientStops.Add(new Brushes.Gradients.GradientStop(0.1, noColor));
                headerTwoGradient.GradientStops.Add(new Brushes.Gradients.GradientStop(0.1, noColor));

                backIOgradient.GradientStops.Clear();
                pchGradient.GradientStops.Clear();
                headerOneGradient.GradientStops.Clear();
                headerTwoGradient.GradientStops.Clear();*/


                byte[] boardColor = auraMb.CurrentColorData();

                Color backIOColor = new Color(boardColor[0], boardColor[2], boardColor[1]);
                Color pchColor = new Color(boardColor[3], boardColor[5], boardColor[4]);
                Color headerOneColor = new Color(boardColor[6], boardColor[8], boardColor[7]);
                Color headerTwoColor = new Color(boardColor[9], boardColor[11], boardColor[10]);

                backIOgradient.GradientStops.Add(new GradientStop(0.0, backIOColor));
                pchGradient.GradientStops.Add(new GradientStop(0.0, pchColor));
                headerOneGradient.GradientStops.Add(new GradientStop(0.0, headerOneColor));
                headerTwoGradient.GradientStops.Add(new GradientStop(0.0, headerTwoColor));

                /*List<BrushRenderTarget> backIORender = new List<BrushRenderTarget>();
                List<BrushRenderTarget> pchRender = new List<BrushRenderTarget>();
                List<BrushRenderTarget> headerOneRender = new List<BrushRenderTarget>();
                List<BrushRenderTarget> headerTwoRender = new List<BrushRenderTarget>();*/

                foreach (Led led in keyboardLeds.GetLeds())
                {
                    if (keyboardLeft.Contains(led))
                    {
                        led.Color = backIOColor;
                        //backIORender.Add(new BrushRenderTarget(led, keyboardLeft));
                    }
                    else if (keyboardMidLeft.Contains(led))
                    {
                        led.Color = pchColor;
                        //pchRender.Add(new BrushRenderTarget(led, keyboardMidLeft));
                    }
                    else if (keyboardMidRight.Contains(led))
                    {
                        led.Color = headerOneColor;
                        //headerOneRender.Add(new BrushRenderTarget(led, keyboardMidRight));
                    }
                    else if (keyboardRight.Contains(led))
                    {
                        led.Color = headerTwoColor;
                        //headerTwoRender.Add(new BrushRenderTarget(led, keyboardRight));
                    }
                    else
                    {
                        led.Color = pchColor;
                    }
                }

                foreach (Led led in mousepadLeds.GetLeds())
                {
                    if (mousepadTopLeft.Contains(led))
                    {
                        //brushRenderTargets.Add(new BrushRenderTarget(led, keyboardLeft));
                        led.Color = backIOColor;
                    }
                    else if (mousepadBottomRight.Contains(led))
                    {
                        led.Color = pchColor;
                    }
                    else if (mousepadBottomLeft.Contains(led))
                    {
                        led.Color = headerOneColor;
                    }
                    else if (mousepadTopRight.Contains(led))
                    {
                        led.Color = headerTwoColor;
                    }
                    else
                    {
                        led.Color = pchColor;
                    }
                }

                /*backIOConical.PerformRender(keyboardLeft, backIORender);
                pchConical.PerformRender(keyboardMidLeft, pchRender);
                headerOneConical.PerformRender(keyboardMidRight, headerOneRender);
                headerTwoConical.PerformRender(keyboardRight, headerTwoRender);*/
                //backIOConical.PerformFinalize();
                //pchConical.PerformFinalize();
                //headerOneConical.PerformFinalize();
                //headerTwoConical.PerformFinalize();

                System.Threading.Thread.Sleep(33);
            };
        }

        //This never really happens?
        protected override void Update(double deltaTime)
        {
            //corsairKeyboard.Update();
            //corsairMousepad.Update();
        }
    }
}
