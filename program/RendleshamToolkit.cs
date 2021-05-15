using System;
using System.Collections.Generic;

namespace Rendlesham
{
    public class RendleshameToolkit
    {
        public static string[] Chunk(string full, int per_group)
        {
            List<string> ToReturn = new List<string>();

            //Split them
            string Buffer = "";
            foreach (char c in full)
            {
                if (Buffer.Length < 8)
                {
                    Buffer = Buffer + c.ToString();
                }
                else
                {
                    ToReturn.Add(Buffer);
                    Buffer = c.ToString();
                }
            }
            if (Buffer.Length != 0)
            {
                ToReturn.Add(Buffer);
            }

            return ToReturn.ToArray();
        }
    }
}