using System;

namespace Serialization.Interfaces
{
    public interface IBuilderStream : IBuilder
    {
        Type ObjType { get; set; }
    }
}
