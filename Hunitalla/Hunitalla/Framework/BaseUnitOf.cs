using System;

namespace Hunitalla.Framework
{
    /// <summary>
    /// Represents the Base Unit of Measurement for a Quantity <typeparamref name="Q"/> from which all other Units are derived.
    /// </summary>
    /// <typeparam name="Q"></typeparam>
    public class BaseUnitOf<Q> : UnitOf<Q> where Q : QuantityOf<Q>
    {
        public override string Name { get; }
        public override string Symbol { get; }
        public override BaseUnitOf<Q> BaseUnit => this;

        private readonly Func<double, string>? _customStringifier;

        public override double ConvertFromBase(double amount) => amount;
        public override double ConvertToBase(double amount) => amount;

        public override string Stringify(double amount)
        {
            if (_customStringifier != null)
            {
                return _customStringifier(amount);
            }

            return base.Stringify(amount);
        }

        public BaseUnitOf(string name, string symbol, Func<double, string>? stringify = null)
        {
            Name = name;
            Symbol = symbol;

            _customStringifier = stringify;
        }
    }
}
