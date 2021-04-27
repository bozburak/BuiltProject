namespace Core.CrossCuttingConcerns
{
    public interface ICacheManager
    {
        object Get(string key);
        void Set(string key, object value, int duration);
        bool IsSet(string key);
        void Remove(string key);
    }
}
