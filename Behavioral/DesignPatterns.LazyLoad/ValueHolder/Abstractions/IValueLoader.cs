namespace DesignPatterns.LazyLoad.ValueHolder.Abstractions
{
    public interface IValueLoader<out T>
    {
        T Load();
    }
}
