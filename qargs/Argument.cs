using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QArgs
{
    public class Argument
    {
        public string[] Shorts {get;}   // like '-t' but for which should only specify 't'
        public string[] Longs {get;}    // like '--total' for which should only specify 'total'
        public string Description { get;}
        public IValueWrapper ValueWrapper{get;}

        public Argument(IEnumerable<string> shorts, IEnumerable<string> longs, 
            string description, IValueWrapper valueWrapper=null)
        {
            Shorts = shorts.ToArray();
            Longs = longs.ToArray();
            Description = description;
            ValueWrapper = valueWrapper;
        }

        public string GetDescription()
        {
            var sb = new StringBuilder();
            foreach (var s in Shorts)
            {
                sb.Append($"-{s},");
            }
            TrimEndComma();
            foreach (var l in Longs)
            {
                sb.Append($"-{l},");
            }
            TrimEndComma();
            return sb.ToString()
        }

        private void TrimEndComma(StringBuilder sb)
        {
            if (sb.EndsWith(','))
            {
                sb.Remove(sb.Length-1);
            }
        }
    }
}