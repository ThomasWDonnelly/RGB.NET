using HidLibrary;
using RGB.NET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGB.NET.Hub
{
    class LightingNodeUtils
    {

        public static byte[][] colorPacketStrip(int strip, Color color)
        {
            string RR = Convert.ToString(color.R, 16).PadLeft(2, '0');
            string GG = Convert.ToString(color.G, 16).PadLeft(2, '0');
            string BB = Convert.ToString(color.B, 16).PadLeft(2, '0');

            string SS = Convert.ToString((strip - 1) * 10, 16).PadLeft(2, '0');

            string red = "00 " +
               "32 00" + SS + "28 00" + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + "00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";


            string green = "00 " +
               "32 00" + SS + "28 01" + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + "00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";


            string blue = "00 " +
               "32 00" + SS + "28 02" + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + "00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";


            Console.Write(" " + RR + " " + GG + " " + BB + " \n");
            byte[][] colorPacket = new byte[3][] { StringToByteArray(red),
                                                   StringToByteArray(green),
                                                   StringToByteArray(blue) };

            return colorPacket;
        }

        public static byte[][] fourStrips(Color color)
        {
            string RR = Convert.ToString(color.R, 16).PadLeft(2, '0');
            string GG = Convert.ToString(color.G, 16).PadLeft(2, '0');
            string BB = Convert.ToString(color.B, 16).PadLeft(2, '0');

            string red = "00 " +
               "32 00 00 28 00" + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR +
                 RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR +
                 RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + "00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";


            string green = "00 " +
               "32 00 00 28 01" + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG +
                 GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG +
                 GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + "00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";


            string blue = "00 " +
               "32 00 00 28 02" + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB +
                 BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB +
                 BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + "00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";


            //Console.Write(" " + RR + " " + GG + " " + BB + " \n");
            byte[][] colorPacket = new byte[3][] { StringToByteArray(red),
                                                   StringToByteArray(green),
                                                   StringToByteArray(blue) };

            return colorPacket;
        }

        internal static byte[][] fourStripsFromZones(Color c1, Color c2, Color c3, Color c4)
        {
            byte[] red = new byte[] {0x00,
                   0x32, 0x00, 0x00, 0x28, 0x00, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c2.R,
                   c2.R, c2.R, c2.R, c2.R, c2.R, c2.R, c2.R, c2.R, c2.R, c3.R, c3.R, c3.R, c3.R, c3.R, c3.R, c3.R,
                   c3.R, c3.R, c3.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            byte[] green = new byte[] {0x00,
                   0x32, 0x00, 0x00, 0x28, 0x01, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c2.G,
                   c2.G, c2.G, c2.G, c2.G, c2.G, c2.G, c2.G, c2.G, c2.G, c3.G, c3.G, c3.G, c3.G, c3.G, c3.G, c3.G,
                   c3.G, c3.G, c3.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            byte[] blue = new byte[] {0x00,
                   0x32, 0x00, 0x00, 0x28, 0x02, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c2.B,
                   c2.B, c2.B, c2.B, c2.B, c2.B, c2.B, c2.B, c2.B, c2.B, c3.B, c3.B, c3.B, c3.B, c3.B, c3.B, c3.B,
                   c3.B, c3.B, c3.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            return new byte[3][] { red, green, blue }; 
        }

        public static byte[][] colorPacketFan(int fan, Color color)
        {
            string RR = Convert.ToString(color.R, 16).PadLeft(2, '0');
            string GG = Convert.ToString(color.G, 16).PadLeft(2, '0');
            string BB = Convert.ToString(color.B, 16).PadLeft(2, '0');

            string SS = Convert.ToString((fan - 1) * 12, 16).PadLeft(2, '0');

            string red = "00 " +
               "32 01" + SS + "28 00" + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR +
                RR + "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";


            string green = "00 " +
               "32 01" + SS + "28 01" + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG +
                GG + "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";


            string blue = "00 " +
               "32 01" + SS + "28 02" + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB +
                BB + "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";


            Console.Write(" " + RR + " " + GG + " " + BB + " \n");
            byte[][] colorPacket = new byte[3][] { StringToByteArray(red),
                                                   StringToByteArray(green),
                                                   StringToByteArray(blue) };

            return colorPacket;
        }

        public static byte[][] sixFans(Color color)
        {
            string RR = Convert.ToString(color.R, 16).PadLeft(2, '0');
            string GG = Convert.ToString(color.G, 16).PadLeft(2, '0');
            string BB = Convert.ToString(color.B, 16).PadLeft(2, '0');

            string red = "00 " +
               "32 01 00 32 00" + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR +
                 RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR +
                 RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR +
                 RR + RR + RR + RR + RR + RR + RR + "00 00 00 00 00 00 00 00 00";

            string green = "00 " +
               "32 01 00 32 01" + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG +
                 GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG +
                 GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG +
                 GG + GG + GG + GG + GG + GG + GG + "00 00 00 00 00 00 00 00 00";


            string blue = "00 " +
               "32 01 00 32 02" + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB +
                 BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB +
                 BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB +
                 BB + BB + BB + BB + BB + BB + BB + "00 00 00 00 00 00 00 00 00";

            string red2 = "00 " +
               "32 01 32 16 00" + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR +
                 RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + RR + "00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";


            string green2 = "00 " +
               "32 01 32 16 01" + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG +
                 GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + GG + "00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";


            string blue2 = "00 " +
               "32 01 32 16 02" + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB +
                 BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + BB + "00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";

            //Console.Write(" " + RR + " " + GG + " " + BB + " \n");
            byte[][] colorPacket = new byte[6][] { StringToByteArray(red),
                                                   StringToByteArray(green),
                                                   StringToByteArray(blue),
                                                   StringToByteArray(red2),
                                                   StringToByteArray(green2),
                                                   StringToByteArray(blue2)};

            return colorPacket;
        }

        internal static byte[][] sixFansFromZones(Color c1, Color c2, Color c3, Color c4)
        {
            byte[] red1 = new byte[] {0x00,
                   0x32, 0x01, 0x00, 0x32, 0x00, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R,
                   c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c1.R, c2.R, c2.R, c2.R,
                   c2.R, c2.R, c2.R, c2.R, c2.R, c2.R, c2.R, c2.R, c2.R, c3.R, c3.R, c3.R, c3.R, c3.R, c3.R, c3.R,
                   c3.R, c3.R, c3.R, c3.R, c3.R, c4.R, c4.R, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            byte[] green1 = new byte[] {0x00,
                   0x32, 0x01, 0x00, 0x32, 0x01, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G,
                   c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c1.G, c2.G, c2.G, c2.G,
                   c2.G, c2.G, c2.G, c2.G, c2.G, c2.G, c2.G, c2.G, c2.G, c3.G, c3.G, c3.G, c3.G, c3.G, c3.G, c3.G,
                   c3.G, c3.G, c3.G, c3.G, c3.G, c4.G, c4.G, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            byte[] blue1 = new byte[] {0x00,
                   0x32, 0x01, 0x00, 0x32, 0x02, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B,
                   c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c1.B, c2.B, c2.B, c2.B,
                   c2.B, c2.B, c2.B, c2.B, c2.B, c2.B, c2.B, c2.B, c2.B, c3.B, c3.B, c3.B, c3.B, c3.B, c3.B, c3.B,
                   c3.B, c3.B, c3.B, c3.B, c3.B, c4.B, c4.B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            byte[] red2 = new byte[] {0x00,
                   0x32, 0x01, 0x32, 0x16, 0x00, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R,
                   c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, c4.R, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            byte[] green2 = new byte[] {0x00,
                   0x32, 0x01, 0x32, 0x16, 0x01, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G,
                   c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, c4.G, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            byte[] blue2 = new byte[] {0x00,
                   0x32, 0x01, 0x32, 0x16, 0x02, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B,
                   c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, c4.B, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            return new byte[6][] { red1, green1, blue1, red2, green2, blue2 };
        }

        public static void firstTransaction(HidDevice device)
        {
            byte[] first1 = new byte[] {0x00,
                   0x38, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            byte[] first2 = new byte[] {0x00,
                   0x38, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            device.Write(first1);
            device.Write(first2);
        }

        public static void beignTransaction(HidDevice device)
        {
            byte[] first1 = new byte[] {0x00,
                   0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            byte[] first2 = new byte[] {0x00,
                   0x34, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            device.Write(first1);
            device.Write(first2);
        }

        public static void submitTransaction(HidDevice device)
        {

            byte[] submit = StringToByteArray("00 " +
                "33 FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            device.Write(submit);
        }

        public static byte[] StringToByteArray(string hex)
        {
            hex = hex.Replace(" ", "");
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}


/* 
 * 
 * 
 * 
            /*command[0] = StringToByteArray("00 " +
                "33 FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[1] = StringToByteArray("00 " +
                "37 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[2] = StringToByteArray("00 " +
                "39 00 64 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[3] = StringToByteArray("00 " +
                "35 00 00 0A 00 01 01 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[4] = StringToByteArray("00 " +
                "37 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[5] = StringToByteArray("00 " +
                "39 00 64 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[6] = StringToByteArray("00 " +
                "35 01 00 00 00 01 01 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
                */

 /*command[0] = StringToByteArray("00 " +
     "38 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00" +
     "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
     "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
     "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

 command[1] = StringToByteArray("00 " +
     "38 01 02 00 00 00 00 00 00 00 00 00 00 00 00 00" +
     "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
     "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
     "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
 //corsairLNP.Write(command[0]);
 //corsairLNP.Write(command[1]);
 //corsairLNP.Write(command[2]);
 //corsairLNP.Write(command[3]);
 //corsairLNP.Write(command[4]);
 //corsairLNP.Write(command[5]);
 //corsairLNP.Write(command[6]);
  command[0] = StringToByteArray("00 " +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[1] = StringToByteArray("00 " +
                "37 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[2] = StringToByteArray("00 " +
                "39 00 64 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[3] = StringToByteArray("00 " +
                "35 00 00 0A 00 01 01 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[4] = StringToByteArray("00 " +
                "37 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[5] = StringToByteArray("00 " +
                "39 00 64 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[6] = StringToByteArray("00 " +
                "35 01 00 00 00 01 01 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[7] = StringToByteArray("00 " +
                "38 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[8] = StringToByteArray("00 " +
                "38 01 02 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[9] = StringToByteArray("00 " +
                "34 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[10] = StringToByteArray("00 " +
                "34 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[11] = StringToByteArray("00 " +
                "32 00 00 28 00 FF FF FF FF FF FF FF FF FF FF 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[12] = StringToByteArray("00 " +
                "32 00 00 28 01 FF FF FF FF FF FF FF FF FF FF 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[13] = StringToByteArray("00 " +
                "32 00 00 28 02 00 FF 00 FF 00 FF 00 FF 00 FF 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[14] = StringToByteArray("00 " +
                "33 FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[15] = StringToByteArray("00 " +
                "32 00 00 28 00 FF FF FF FF FF FF FF FF FF FF 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[16] = StringToByteArray("00 " +
                "32 00 00 28 01 FF FF FF FF FF FF FF FF FF FF 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[17] = StringToByteArray("00 " +
                "32 00 00 28 02 FF FF FF FF FF FF FF FF FF FF 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

            command[18] = StringToByteArray("00 " +
                "33 FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00" +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
                
    
    byte[][] updt1 = new[]    {new byte[] { 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } };

 byte[][] updt2 = new[]    {new byte[] { 0x37, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } };

 byte[][] updt3 = new[]    {new byte[] { 0x38, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } };

 byte[][] tempHD0 = new[]  {new byte[] { 0x36, 0x01, 0x00, 0x0F, 0x3C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } };

 byte[][] tempHD1 = new[]  {new byte[] { 0x36, 0x01, 0x01, 0x0A, 0x28, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } };

 byte[][] strip1 = new[]      {new byte[] { 0x35, 0x00, 0x00, 0x0A, 0x04, 0x00, 0x00, 0x00, 0xFF, 0x41, 0x42, 0x43, 0x61, 0x62, 0x63, 0x81 },
                            new byte[] { 0x00, 0x00, 0x09, 0xC4, 0x0D, 0xAC, 0x11, 0x94, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } };

 byte[][] strip2 = new[]      {new byte[] { 0x35, 0x00, 0x0A, 0x0A, 0x04, 0x04, 0x01, 0x00, 0xFF, 0x41, 0x42, 0x43, 0x61, 0x62, 0x63, 0x81 },
                            new byte[] { 0x00, 0x00, 0x09, 0xC4, 0x0D, 0xAC, 0x11, 0x94, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } };

 byte[][] strip3 = new[]      {new byte[] { 0x35, 0x00, 0x14, 0x0A, 0x04, 0x01, 0x01, 0x00, 0xFF, 0x41, 0x42, 0x43, 0x61, 0x62, 0x63, 0x81 },
                            new byte[] { 0x00, 0x00, 0x09, 0xC4, 0x0D, 0xAC, 0x11, 0x94, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } };

 byte[][] strip4 = new[]      {new byte[] { 0x35, 0x00, 0x1E, 0x0A, 0x04, 0x01, 0x01, 0x00, 0xFF, 0x41, 0x42, 0x43, 0x61, 0x62, 0x63, 0x81 },
                            new byte[] { 0x00, 0x00, 0x09, 0xC4, 0x0D, 0xAC, 0x11, 0x94, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } };

 byte[][] finalize = new[] {new byte[] { 0x33, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                            new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } };


byte[][] command = new byte[87][];

/*command[0] = StringToByteArray("34 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[1] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[2] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[3] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[4] = StringToByteArray("37 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[5] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[6] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[7] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[8] = StringToByteArray("38 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[9] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[10] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[11] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");


command[12] = StringToByteArray("36 01 00 0F 3C 00 00 00 00 00 00 00 00 00 00 00");
command[13] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[14] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[15] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");


command[16] = StringToByteArray("36 01 01 0A 28 00 00 00 00 00 00 00 00 00 00 00");
command[17] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[18] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[19] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");


command[20] = StringToByteArray("34 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[21] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[22] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[23] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[24] = StringToByteArray("37 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[25] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[26] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[27] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[28] = StringToByteArray("38 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[29] = StringToByteArray("82 83 09 C4 0D AC 11 94 00 00 00 00 00 00 00 00");
command[30] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[31] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[32] = StringToByteArray("35 00 0A 0A 04 01 01 00 FF 41 42 43 FF FF 00 FF");
command[33] = StringToByteArray("00 00 09 C4 0D AC 11 94 00 00 00 00 00 00 00 00");
command[34] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[35] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[36] = StringToByteArray("35 00 14 0A 04 01 01 00 FF 41 42 43 FF FF 00 FF");
command[37] = StringToByteArray("00 00 09 C4 0D AC 11 94 00 00 00 00 00 00 00 00");
command[38] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[39] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[40] = StringToByteArray("35 00 1E 0A 04 01 01 00 FF 41 42 43 FF FF 00 FF");
command[41] = StringToByteArray("00 00 09 C4 0D AC 11 94 00 00 00 00 00 00 00 00");
command[42] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[43] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[44] = StringToByteArray("34 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[45] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[46] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[47] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[48] = StringToByteArray("37 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[49] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[50] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[51] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[52] = StringToByteArray("38 01 01 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[53] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[54] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[55] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[56] = StringToByteArray("35 01 00 0C 05 01 01 00 FF 00 00 FF 00 FF 00 FF");
command[57] = StringToByteArray("00 00 07 D0 0B B8 0F A0 00 00 00 00 00 00 00 00");
command[58] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[59] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[60] = StringToByteArray("35 01 0C 0C 05 01 01 00 FF 00 00 FF 00 FF 00 FF");
command[61] = StringToByteArray("00 00 07 D0 0B B8 0F A0 00 00 00 00 00 00 00 00");
command[62] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[63] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[64] = StringToByteArray("37 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[65] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[66] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[67] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[68] = StringToByteArray("35 01 18 0C 05 01 01 00 FF 00 00 FF 00 FF 00 FF");
command[69] = StringToByteArray("00 00 07 D0 0B B8 0F A0 00 00 00 00 00 00 00 00");
command[70] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[71] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[72] = StringToByteArray("35 01 18 0C 05 01 01 00 FF 00 00 FF 00 FF 00 FF");
command[73] = StringToByteArray("00 00 07 D0 0B B8 0F A0 00 00 00 00 00 00 00 00");
command[74] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[75] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[76] = StringToByteArray("35 01 18 0C 05 01 01 00 FF 00 00 FF 00 FF 00 FF");
command[77] = StringToByteArray("00 00 07 D0 0B B8 0F A0 00 00 00 00 00 00 00 00");
command[78] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[79] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");

command[80] = StringToByteArray("35 01 18 0C 05 01 01 00 FF 00 00 FF 00 FF 00 FF");
command[81] = StringToByteArray("00 00 07 D0 0B B8 0F A0 00 00 00 00 00 00 00 00");
command[82] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
command[83] = StringToByteArray("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");*/
