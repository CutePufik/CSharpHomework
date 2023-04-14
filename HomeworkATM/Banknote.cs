using System;
using System.Linq;

namespace HomeworkATM;

public class Banknote
{
    public int Nominal { get; }
    public string Series { get; }

    public Banknote(int nominal, string series)
    {
        if (!new int[] { 5, 10, 50, 100, 200, 500, 1000, 2000, 5000 }.Contains(nominal)) throw new Exception();
        if (!(series.Substring(0, 2).All(x => char.IsLetter(x)) && series.
                     Substring(2, 8).All(x => char.IsDigit(x)))) throw new Exception();
        Nominal = nominal;
        Series = series;
    }

    public override string ToString()
    {
        return $"Banknote {Nominal} {Series}";
    }
}