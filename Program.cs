using System;
using TextCopy;

namespace GuidConverterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("GUID >< RAW(16) Converter");
                Console.Write("Enter the value: ");

                string Prompt = Console.ReadLine();
                if (Prompt.Length == 36)
                {
                    if(Guid.TryParse(Prompt, out Guid inputGuid))
                    {
                        Guid guid = Guid.Parse(Prompt);
                        byte[] raw16 = guid.ToByteArray();
                        Console.WriteLine("RAW(16): " + BitConverter.ToString(raw16).Replace("-", ""));
                        ClipboardService.SetText(BitConverter.ToString(raw16).Replace("-", string.Empty));
                        Console.WriteLine("Result Copied! ctrl+v anywhere!\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid GUID\n");
                    }
                }
                else if (Prompt.Length == 32)
                {
                    byte[] raw16Bytes = new byte[16];
                    for (int i = 0; i < 16; i++)
                    {
                        raw16Bytes[i] = Convert.ToByte(Prompt.Substring(i * 2, 2), 16);
                    }
                    Guid convertedGuid = new Guid(raw16Bytes);
                    Console.WriteLine("GUID: " + convertedGuid.ToString());
                    ClipboardService.SetText(convertedGuid.ToString());
                    Console.WriteLine("Result Copied! ctrl+v anywhere!\n");
                }
                else
                {
                    Console.WriteLine("Invalid choice.\n");
                }
            }
        }
    }
}
