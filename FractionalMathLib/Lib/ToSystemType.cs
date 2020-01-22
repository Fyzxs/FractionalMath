using System.Diagnostics;

namespace FractionalMathLib.Lib {

    [DebuggerDisplay("{AsSystemType()}")]
    public abstract class ToSystemType<T>
    {
        public static implicit operator T(ToSystemType<T> origin) => origin.AsSystemType();
        public abstract T AsSystemType();
    }
}