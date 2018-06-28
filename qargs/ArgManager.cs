using System.Collections.Generic;

namespace QArgs
{
    public class ArgManager
    {
        public List<Argument> Arguments {get;}

        public ArgManager(ArgBuilder argBuilder)
        {
            Arguments = argBuilder.Arguments;
            argBuilder.Dispose();
        }

        public IEnumeable<string> MakeArgList()
        {
            
        }
    }
}
