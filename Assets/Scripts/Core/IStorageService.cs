namespace Core
{
    public interface IStorageService<T>
    {
        void SaveState(T state);
        
        void ClearData();
        
        T LoadState();
    }
}