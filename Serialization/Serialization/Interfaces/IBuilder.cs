namespace Serialization.Interfaces
{
    public interface IBuilder
    {
        string FilePath { get; set; }

        bool CreateFile(object obj);
        object GetObjectFromFile();
    }
}
