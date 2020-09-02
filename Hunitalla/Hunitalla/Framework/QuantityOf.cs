using System;
using System.Collections.Generic;
using System.Reflection;

namespace Hunitalla.Framework
{
    /// <summary>
    /// Represents a measurement of <typeparamref name="Q"/> in a given unit
    /// </summary>
    /// <typeparam name="Q"></typeparam>
    public abstract class QuantityOf<Q> : IEquatable<Q>,
                                          IEquatable<QuantityOf<Q>>,
                                          IEqualityComparer<Q>,
                                          IEqualityComparer<QuantityOf<Q>>,
                                          IComparable<Q>,
                                          IComparable<QuantityOf<Q>>
        where Q : QuantityOf<Q>
    {
        /// <summary>
        /// Numerical measurement
        /// </summary>
        public abstract double Amount { get; }

        /// <summary>
        /// Unit of measurement
        /// </summary>
        public abstract UnitOf<Q> Unit { get; }

        /// <summary>
        /// The measurement after being converted to the base unit for this Quantity
        /// </summary>
        public double BaseAmount => Unit.ConvertToBase(Amount);

        /// <summary>
        /// The unit for this quantity from which all other units are derived.
        /// </summary>
        /// <example>Second for Time</example>
        /// <example>Dollar for U.S. Dollars</example>
        public BaseUnitOf<Q> BaseUnit => Unit.BaseUnit;

        /// <summary>
        /// Returns amount after conversion into given <paramref name="unit"/>
        /// </summary>
        /// <param name="unit"></param>
        /// <example><c>2.Hours().In(Duration.Minute) == 120</c></example>
        public double In(UnitOf<Q> unit) => unit.ConvertFromBase(BaseAmount);

        private readonly ConstructorInfo _quantifier;

        protected QuantityOf()
        {
            _quantifier = GetType().GetConstructor(new[] { typeof(double), typeof(UnitOf<Q>) });
        }

        private Q Quantify(double amount) => (Q)_quantifier.Invoke(new object[] { amount, Unit });

        private Q Shift(QuantityOf<Q> other)
        {
            var amount = Unit.ConvertFromBase(BaseAmount + other.BaseAmount);

            return Quantify(amount);
        }

        private Q Scale(double scalar)
        {
            var amount = Unit.ConvertFromBase(scalar * Amount);

            return Quantify(amount);
        }

        private void VerifyComparable(QuantityOf<Q> other)
        {
            if (BaseUnit != other.BaseUnit)
            {
                throw new ArgumentException($"Cannot compare quantities of '{GetType().Name}' to '{other.GetType().Name}' because they have different BaseUnits.");
            }
        }

        public override int GetHashCode() => 31 * Unit.GetHashCode() + Amount.GetHashCode();
        public int GetHashCode(Q obj) => obj.GetHashCode();
        public int GetHashCode(QuantityOf<Q> obj) => obj.GetHashCode();

        public override string ToString() => Unit.Stringify(Amount);

        public override bool Equals(object obj) => obj is QuantityOf<Q> q && Equals(q);
        public bool Equals(QuantityOf<Q> x, QuantityOf<Q> y) => x.Equals(y);
        public bool Equals(Q x, Q y) => x.Equals(y);

        public bool Equals(Q other)
        {
            const double EQUALITY_PRECISION = 1e-10;

            return Math.Abs(BaseAmount - other.BaseAmount) < EQUALITY_PRECISION;
        }

        public bool Equals(QuantityOf<Q> other)
        {
            VerifyComparable(other);

            return Equals((Q)other);
        }

        public int CompareTo(Q other)
        {
            if (Equals(other))
            {
                return 0;
            }

            return BaseAmount.CompareTo(other.BaseAmount);
        }

        public int CompareTo(QuantityOf<Q> other)
        {
            VerifyComparable(other);

            return CompareTo((Q)other);
        }

        public static Q operator -(QuantityOf<Q> a) => a.Scale(-1);
        public static Q operator +(QuantityOf<Q> a, QuantityOf<Q> b) => a.Shift(b);
        public static Q operator -(QuantityOf<Q> a, QuantityOf<Q> b) => a.Shift(-b);
        public static Q operator *(QuantityOf<Q> a, double scalar) => a.Scale(scalar);
        public static Q operator *(QuantityOf<Q> a, int scalar) => a.Scale(scalar);
        public static Q operator *(double a, QuantityOf<Q> quantity) => quantity.Scale(a);
        public static Q operator *(int a, QuantityOf<Q> quantity) => quantity.Scale(a);
        public static Q operator /(QuantityOf<Q> a, double divisor) => a.Scale(1 / divisor);
        public static Q operator /(QuantityOf<Q> a, int divisor) => a.Scale(1.0 / divisor);
        public static double operator /(QuantityOf<Q> a, QuantityOf<Q> b) => a.Amount / b.In(a.Unit);

        public static bool operator ==(QuantityOf<Q> a, QuantityOf<Q> b) => a.Equals(b);
        public static bool operator !=(QuantityOf<Q> a, QuantityOf<Q> b) => !(a == b);

        public static bool operator <(QuantityOf<Q> a, QuantityOf<Q> b) => a.CompareTo(b) < 0;
        public static bool operator <=(QuantityOf<Q> a, QuantityOf<Q> b) => a.CompareTo(b) <= 0;
        public static bool operator >(QuantityOf<Q> a, QuantityOf<Q> b) => !(a <= b);
        public static bool operator >=(QuantityOf<Q> a, QuantityOf<Q> b) => !(a < b);

        public static bool operator <(QuantityOf<Q> a, Q b) => a.CompareTo(b) < 0;
        public static bool operator <=(QuantityOf<Q> a, Q b) => a.CompareTo(b) <= 0;
        public static bool operator >(QuantityOf<Q> a, Q b) => !(a <= b);
        public static bool operator >=(QuantityOf<Q> a, Q b) => !(a < b);
    }
}
