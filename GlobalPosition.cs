using System;
using UnityEngine;
/// <summary>
/// Position in killometers
/// </summary>
public struct GlobalPosition
{
    public double X; 
    public double Z;

    public GlobalPosition(double x, double z)
    {
        this.X = x;
        this.Z = z;
    }

    public double Magnitude => Math.Sqrt(X* X + Z* Z);

    public bool Zero => X == 0 && Z == 0;

    public override string ToString()
    {
        return String.Concat(X.ToString()," ", Z.ToString());
    }

    public static GlobalPosition operator -(GlobalPosition a, GlobalPosition b)
    {
        return new GlobalPosition(a.X - b.X, a.Z - b.Z);
    }

    public static bool operator !=(GlobalPosition lhs, GlobalPosition rhs)
    {
        return !(lhs == rhs);
    }

    public static bool operator ==(GlobalPosition lhs, GlobalPosition rhs)
    {
        double num = lhs.X - rhs.X;
        double num3 = lhs.Z - rhs.Z;
        double num4 = num * num + num3 * num3;
        return num4 < 9.99999944E-11f;
    }

}
