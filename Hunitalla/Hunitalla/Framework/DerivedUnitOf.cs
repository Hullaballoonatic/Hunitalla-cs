using System;

namespace Hunitalla.Framework
{
    /// <summary>
    /// Represents a unit which is defined as a transformation of another reference unit
    /// </summary>
    /// <typeparam name="Q"></typeparam>
    public class DerivedUnitOf<Q> : UnitOf<Q> where Q : QuantityOf<Q>
    {
        /// <summary>
        /// Converts a measurement given in reference unit into one given in this unit
        /// </summary>
        public Func<double, double> ConvertFromReference { get; }

        /// <summary>
        /// Converts a measurement given in this unit into one given in reference unit
        /// </summary>
        public Func<double, double> ConvertToReference { get; }

        /// <summary>
        /// The unit this Unit is defined by a mapping to
        /// </summary>
        public UnitOf<Q> ReferenceUnit { get; }

        public override string Name { get; }
        public override string Symbol { get; }
        public override BaseUnitOf<Q> BaseUnit => ReferenceUnit.BaseUnit;

        private readonly Func<double, string>? _customStringifier;

        public override double ConvertFromBase(double amount) => ConvertFromReference(ReferenceUnit.ConvertFromBase(amount));
        public override double ConvertToBase(double amount) => ReferenceUnit.ConvertToBase(ConvertToReference(amount));

        public override string Stringify(double amount)
        {
            if (_customStringifier != null)
            {
                return _customStringifier(amount);
            }

            return base.Stringify(amount);
        }

        public DerivedUnitOf(string name,
                             string symbol,
                             UnitOf<Q> referenceUnit,
                             Func<double, double> convertFromReference,
                             Func<double, double> convertToReference,
                             Func<double, string>? stringify = null)
        {
            Name = name;
            Symbol = symbol;

            ReferenceUnit = referenceUnit;
            ConvertFromReference = convertFromReference;
            ConvertToReference = convertToReference;

            _customStringifier = stringify;
        }

        /// <summary>
        /// Creates a Derived Unit where the transformation from <paramref name="referenceUnit"/> to this unit is defined as a ratio of <paramref name="numReferenceUnits"/> to <paramref name="numDerivedUnits"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="symbol"></param>
        /// <param name="referenceUnit"></param>
        /// <param name="numReferenceUnits"></param>
        /// <param name="numDerivedUnits"></param>
        /// <param name="stringify"></param>
        /// <returns></returns>
        public static DerivedUnitOf<Q> ByRatio(string name,
                                               string symbol,
                                               UnitOf<Q> referenceUnit,
                                               int numReferenceUnits,
                                               int numDerivedUnits = 1,
                                               Func<double, string>? stringify = null)
        {
            if (numReferenceUnits is 0 || numDerivedUnits is 0)
            {
                throw new DivideByZeroException($"Impossible bi-directional conversion with given ratio '{numReferenceUnits}':'{numDerivedUnits}'");
            }

            return new DerivedUnitOf<Q>(name,
                                        symbol,
                                        referenceUnit,
                                        convertFromReference: amount => amount * numDerivedUnits / numReferenceUnits,
                                        convertToReference: amount => amount / numDerivedUnits * numReferenceUnits,
                                        stringify);
        }
    }
}
