using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Helper
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

        public string Serialize(object obj)
        {
            return _builder.Serialize(obj);
        }

        public object Deserialize(string obj)
        {
            return _builder.Deserialize(obj);
        }
    }
}
