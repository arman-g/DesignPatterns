using DesignPatterns.LazyLoad.ValueHolder.Abstractions;

namespace DesignPatterns.LazyLoad.ValueHolder
{
    public class ValueHolder<T>
    {
        private T _value;
        private readonly IValueLoader<T> _loader;

        public ValueHolder(IValueLoader<T> loader)
        {
            _loader = loader;
        }

        public T Value
        {
            get
            {
                if (_value == null)
                {
                    _value = _loader.Load();
                }

                return _value;
            }
        }
    }
}
