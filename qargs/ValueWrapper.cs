
namespace QArgs
{
    public interface IValueWrapper
    {
        object Value {get;set;}
        bool HasDefaultValue {get;set;}
        object DefaultValue {get; set;}
    }

    public interface IValueWrapper<T> : IValueWrapper
    {
        new T Value{get;set;}
        bool HasDefaultValue {get;set;} = false;
        new T DefaultValue {get; set;} = default(T);
    }

    public abstract class ValueWrapper<T> : IValueWrapper<T>
    {
        public T Value {get;set;}
        object IValueWrapper.Value {
            get { return Value;}
            set {Value = (T)value;}
        }
        public abstract bool TryParse(string s) ;
        public override string ToString() 
        {
            return Value.ToString();
        }
    }

    public class ValueWrapper_Int : ValueWrapper<int>
    {
        public override bool TryParse(string s)
        {
            var res = int.TryParse(s, out var v);
            if (res)
            {
                Value = v;
            }
            return res;
        }
    }

    public class ValueWrapper_Double : ValueWrapper<double>
    {
        public override bool TryParse(string s)
        {
            var res = double.TryParse(s, out var v);
            if (res)
            {
                Value = v;
            }
            return res;
        }
    }

    public class ValueWrapper_String : ValueWrapper<string>
    {
        public override bool TryParse(string s)
        {
            Value = s;
            return true;
        }
    }
}