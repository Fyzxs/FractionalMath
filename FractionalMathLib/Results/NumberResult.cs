﻿namespace FractionalMathLib.Results {
    public sealed class NumberResult : Result
    {
        private const char FractionSeparator = '/';
        private readonly string _origin;

        public NumberResult(string origin) => _origin = origin;

        private double GetFractionAsDouble()
        {
            if (!_origin.Contains(FractionSeparator.ToString())) return double.Parse(_origin);

            string[] firstFraction = _origin.Split(FractionSeparator);
            return double.Parse(firstFraction[0]) / double.Parse(firstFraction[1]);
        }

        public override double AsSystemType() => GetFractionAsDouble();
    }
}