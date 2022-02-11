using Serialization.Interfaces;

namespace Serialization.Builders
{
    public class Builder
    {
        private readonly IBuilder _builder;

        public Builder(IBuilder builder)
        {
            _builder = builder;
        }

        public bool CreateFile(object obj)
        {
            return _builder.CreateFile(obj);
        }

        public object GetObjectFromFile()
        {
            return _builder.GetObjectFromFile();
        }
    }
}
