# Hunitalla

 A library of Quantity types and associated units of measurement, as well as a framework for writing custom ones. The quantities types have fluent api as well as operators for implicit or explicit conversions.

</br>

## Installing
**Package Manager**: `Install-Package Hunitalla -Version 0.0.6`

**.NET CLI**: `dotnet add package Hunitalla --version 0.0.6`

*Symbols available*

</br>

## Features & Usage
### Using Provided Types

#### Summing and Comparisons
```c#
var money = 13.Dollars() + 62.Cents();

Assert.True(money < 14.69.Dollars());

Assert.True(2.Feet() == 24.Inches());
```
#### Converting between units
```c#
var rate = 1.DollarsPerMile();

Assert.True(rate.In(LinearDollarDensity.DollarsPerFoot) == 5280);
```
#### Converting between quantity types explicity
```c#
Distance distance = 120.Miles();
Duration time = 2.Hours();

Velocity velocity = distance / time;

Assert.True(v == 60.Mph());
```
#### Converting between quantity types implicity
```c#
var distance = 120.Miles();
var time = 2.Hours();

Assert.True(distance / time == 60.Mph());
```

</br>

### Using Framework
##### Required
- define a class that implements `QuantityOf<Q>` abstract class, and has a constructor in the form of `public MyQuantity(double amount, UnitOf<MyQuantity> unit)`
- define the units of `MyQuantity`, including one `BaseUnitOf<MyQuantity>` from which all others fundamentally derive. 
    - additional units can be defined conveniently with the `DerivedUnit<MyQuantity>` static builder methods
##### Optional
- for compile-time implicit conversion between Quantities, you will have to define those operators yourself.

*You do not need to define comparison, addition, multiplication by a number, or division by your own `MyQuantity`. Those are all automatically handled.*

</br>

#### Example 
##### Defining a new `Acceleration` Quantity Type and Units
```c#
class Acceleration : QuantityOf<Acceleration>
{
    public readonly static BaseUnitOf<Acceleration> MilesPerHourPerHour = new BaseUnitOf<Acceleration>("Miles per Hour Squared", "mil/h/h");
    public readonly static UnitOf<Acceleration> MilesPerHourPerSecond = DerivedUnitOf<Acceleration>.ByRatio("Miles per Hour per Second", "mil/h/s", MilesPerHourPerHour, 1, 5280);

    public override double Amount { get; }
    public override UnitOf<Acceleration> Unit { get; }

    public Acceleration(double amount, UnitOf<Acceleration> unit)
    {
        Amount = amount;
        Unit = unit;
    }

    public static Velocity operator *(Acceleration a, Duration b)
    {
        var amount = a.In(MilesPerHourPerHour) * b.In(Duration.Hour);

        return new Velocity(amount, Velocity.MilesPerHour);
    }

    public static Velocity operator *(Duration a, Acceleration b) => b * a;
}
```
</br>

### Debugging
You can step into this NuGet's code while debugging by enabling and downloading the symbols.

</br>

---
</br>

### TODO
   #### now:
  * Expand README/documentation
  * Parsing

   #### long-term:
  * Compound Quantities (+ Generalized Compound Units?):
      * Summed Quantities, e.g. 3ft 6inches, 1hr 23 min 15sec, 5'4"
      * Ratio Quantities, e.g. 6 mi/hr, 23 lbs/in²
  * Systems of Units, including Metric
  * Ratios of Units to other Units with a Rational Class
  * BigInteger / BigDecimal