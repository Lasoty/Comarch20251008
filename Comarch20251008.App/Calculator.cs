using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comarch20251008.App.Domain;
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

    private void Test()
    {
        Truck truck = new Truck();
        truck.Zatankuj();
    }

    private void Truck_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
    }
}





class Car 
{
    public string Marka { get; set; }

    private string model;
    public string Model
    {
        get
        {
            return model;
        }

        set
        {
            model = value;
        }
    }

    protected bool isBorrowed;

    public virtual void Zatankuj()
    {

    }
}

class Truck : Car
{
    public Truck()
    {
        isBorrowed = false;
    }

    public override void Zatankuj()
    {
    }
}
