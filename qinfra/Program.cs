using System;
using System.IO;

namespace QInfra
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var si = new StreamReader(args[0]))
            {
                var s = si.ReadToEnd();
                var ldr = new Loader();
                ldr.Load(s);
            }
        }
    }
}
