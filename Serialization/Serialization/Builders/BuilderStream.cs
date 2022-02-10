using Serialization.Interfaces;

namespace Serialization.Builders
{
    public class BuilderStream
    {
        private readonly IBuilderStream _builder;

        public BuilderStream(IBuilderStream builder)
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
