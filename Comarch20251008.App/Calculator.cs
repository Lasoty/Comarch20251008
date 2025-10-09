using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comarch20251008.App;
internal class Calculator
{
    private int counter = 0;

    public int Add(int x, int y)
    {
        counter++;
        return x + y;
    }

    public int Subtract(int x, int y)
    {
        return x - y;
    }

    public int Multiply(int x, int y)
    {
        return x * y;
    }

    public float Dividy(float x, float y)
    {
        if (y == 0)
            throw new ArgumentException("Pamiętaj cholero! Nie dziel przez 0!", nameof(y));

        return x / y;
    }

    public int Modulo(int x, int y)
    {
        return x % y;
    }
}
