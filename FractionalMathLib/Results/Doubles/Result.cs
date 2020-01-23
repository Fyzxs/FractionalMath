namespace FractionalMathLib.Results.Doubles {
    /// <summary>
    /// A Marker Class for Results. This is the base class for a numeric result.
    ///
    /// This enables building binary trees to express mathematical order of operations.
    ///
    /// Primitives are not allowed. Result represents the concept in the code. A double is... meaningless.
    /// </summary>
    public abstract class Result : ToSystemType<double>{}
}