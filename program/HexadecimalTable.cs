using System;
using System.Collections.Generic;

namespace Rendlesham
{
    public class HexadecimalTable
    {
        //https://www.best-microcontroller-projects.com/bit-byte.html

        private HexadecimalConversion[] ConversionTable;

        public HexadecimalTable()
        {
            List<HexadecimalConversion> c = new List<HexadecimalConversion>();
            c.Add(new HexadecimalConversion(0, "0", "0000"));
            c.Add(new HexadecimalConversion(1, "1", "0001"));
            c.Add(new HexadecimalConversion(2, "2", "0010"));
            c.Add(new HexadecimalConversion(3, "3", "0011"));
            c.Add(new HexadecimalConversion(4, "4", "0100"));
            c.Add(new HexadecimalConversion(5, "5", "0101"));
            c.Add(new HexadecimalConversion(6, "6", "0110"));
            c.Add(new HexadecimalConversion(7, "7", "0111"));
            c.Add(new HexadecimalConversion(8, "8", "1000"));
            c.Add(new HexadecimalConversion(9, "9", "1001"));
            c.Add(new HexadecimalConversion(10, "A", "1010"));
            c.Add(new HexadecimalConversion(11, "B", "1011"));
            c.Add(new HexadecimalConversion(12, "C", "1100"));
            c.Add(new HexadecimalConversion(13, "D", "1101"));
            c.Add(new HexadecimalConversion(14, "E", "1110"));
            c.Add(new HexadecimalConversion(15, "F", "1111"));
            ConversionTable = c.ToArray();
        }

        public byte BinaryToByte(string binary)
        {
            if (binary.Length != 8)
            {
                throw new Exception("Binary string was not 8 characters");
            }

            //split it
            string p1 = binary.Substring(0, 4);
            string p2 = binary.Substring(4, 4);

            //Find it
            int d1 = NibbleToDecimal(p1);
            int d2 = NibbleToDecimal(p2);

            //Calcualte the byte
            int ToReturnInt = (d1 * 16) + d2;
            byte ToReturn = Convert.ToByte(ToReturnInt);
            return ToReturn;
        }

        private int NibbleToDecimal(string nibble)
        {
            foreach (HexadecimalConversion hc in ConversionTable)
            {
                if (hc.Binary == nibble)
                {
                    return hc.Decimal;
                }
            }
            throw new Exception("Unable to find conversion for nible " + nibble);
        }

        private class HexadecimalConversion
        {
            public int Decimal {get; set;}
            public string HexDigit {get; set;}
            public string Binary {get; set;}

            public HexadecimalConversion(int dec, string hex, string binary)
            {
                Decimal = dec;
                HexDigit = hex;
                Binary = binary;
            }
        }
    }
}