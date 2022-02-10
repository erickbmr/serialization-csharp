using Serialization.Interfaces;

namespace Serialization.Builders
{
    public class BuilderString
    {
        private readonly IBuilderString _builder;

        public BuilderString(IBuilderString builder)
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
