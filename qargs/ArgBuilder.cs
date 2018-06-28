using System;
using System.Collections.Generic;

namespace QArgs
{
    public class ArgBuilder : IDisposable
    {
        public List<Argument> Arguments {get; private set;} = new List<Argument>();

        public ArgBuilder()
        {
        }

        public void Dispose()
        {
            if (Arguments != null)
            {
                Arguments = null;
            }
        }

        public ArgBuilder Add(IEnumerable<string> shorts, IEnumerable<string> longs, IValueWrapper valueWrapper)
        {
            var arg = new Argument(shorts, longs, valueWrapper);
            Arguments.Add(arg);
            return this;
        }
    }
}