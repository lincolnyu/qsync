using System;
using System.IO;
using System.Linq;

namespace QInfra
{
    class Program
    {
        static void RunInteractiveSession()
        {
            //TODO implement it...
        }

        static void Main(string[] args)
        {
            if (args.Contains("-i"))
            {
                RunInteractiveSession();
            }
            else if (args.Contains("-s"))
            {
                var pos = Array.IndexOf(args, "-s");
                if (pos >= 0 && pos+1 < args.Length)
                {
                    using (var si = new StreamReader(args[pos+1]))
                    {
                        var s = si.ReadToEnd();
                        var ldr = new Loader();
                        ldr.Load(s);
                    }
                }
            }
            else
            {
                //TODO Print help...
            }
        }
    }
}
