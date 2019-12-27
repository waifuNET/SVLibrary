using System;

namespace SVLibrary.SVconsole
{
    public partial class SVconsole
    {
        public static void WriteLineArray(object[] text)
        {
            foreach(string temp in text)
            {
                Console.WriteLine(temp);
            }
        }
    }
}
