using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Helper
{
    public interface IBuilder
    {
        string FilePath { get; set; }

        bool CreateFile(object obj);
        object GetObjectFromFile();
        string Serialize(object obj);
        object Deserialize(string obj);
    }
}
