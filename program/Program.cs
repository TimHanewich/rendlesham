using System;
using System.IO;
using System.Collections.Generic;

namespace Rendlesham
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Users\tahan\Downloads\rendlesham\journal\journal03.txt";
            string content = System.IO.File.ReadAllText(path);
            content = content.Replace(Environment.NewLine, "");

            string[] chunked = RendleshameToolkit.Chunk(content, 8);

            //Assemble into bytes
            HexadecimalTable ht = new HexadecimalTable();
            List<byte> AsBytes = new List<byte>();
            foreach (string s in chunked)
            {
                if (s.Length == 8)
                {
                    byte asbyte = ht.BinaryToByte(s);
                    AsBytes.Add(asbyte);
                }
                
            }

            //Convert the bytes to a string
            string asstr = System.Text.Encoding.ASCII.GetString(AsBytes.ToArray());

            Console.WriteLine(asstr);
        }

        public static void TryThis()
        {
            string path = @"C:\Users\tahan\Downloads\Encounter in Rendlesham Forest The Inside Story of the World’s Best-Documented UFO Incident by Nick Pope,_ John Burroughs,_ Jim Penniston (z-lib.org)";
            string[] files = System.IO.Directory.GetFiles(path);
            foreach (string s in files)
            {
                if (s.ToLower().Contains(".html"))
                {
                    string content = System.IO.File.ReadAllText(s);
                    if (content.ToLower().Contains("humanity"))
                    {
                        Console.WriteLine(s);
                    }
                }
            }
        }
    }
}
