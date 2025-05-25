using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GuiTestingLibrary_Tets.Models")]

namespace gui_tesing_library.Models;

public class Vector2i
{
    public Vector2i(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2i(Vector2i_CS vector2i_CS)
    {
        x = vector2i_CS.X;
        y = vector2i_CS.Y;
    }

    public int x { get; set; }
    public int y { get; set; }

    public float Length => (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

    protected bool Equals(Vector2i other)
    {
        return x == other.x && y == other.y;
    }

    public override bool Equals(object obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;
        return Equals((Vector2i)obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return $"[{x};{y}]";
    }

    public int Area()
    {
        return x * y;
    }

    public Vector2i_CS Native()
    {
        return Vector2i_CS.Create(x, y);
    }

    public static Vector2i operator +(Vector2i a, Vector2i b)
    {
        return new Vector2i(a.x + b.x, a.y + b.y);
    }

    public static Vector2i operator -(Vector2i a, Vector2i b)
    {
        return new Vector2i(a.x - b.x, a.y - b.y);
    }

    public static Vector2i operator /(Vector2i a, int b)
    {
        return new Vector2i(a.x / b, a.y / 2);
    }

    public static Vector2i operator /(Vector2i a, Vector2i b)
    {
        return new Vector2i(a.x / b.x, a.y / b.y);
    }

    public static explicit operator Vector2i(Vector2f v)
    {
        return new Vector2i((int)v.x, (int)v.y);
    }
}

public class Vector2f
{
    public Vector2f(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2f(Vector2f_CS vector2f_CS)
    {
        x = vector2f_CS.x;
        y = vector2f_CS.y;
    }

    public float x { get; set; }
    public float y { get; set; }

    protected bool Equals(Vector2f other)
    {
        return x == other.x && y == other.y;
    }

    public override bool Equals(object obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;
        return Equals((Vector2f)obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return $"[{x};{y}]";
    }

    public float Area()
    {
        return x * y;
    }

    public float DistanceFrom(Vector2f pos)
    {
        var offset = new Vector2f(x - pos.x, y - pos.y);
        return (float)
            Math.Sqrt(Math.Pow(offset.x, 2) + Math.Pow(offset.y, 2));
    }

    public Vector2f_CS Native()
    {
        return new Vector2f_CS(x, y);
    }

    public static Vector2f operator +(Vector2f a, Vector2f b)
    {
        return new Vector2f(a.x + b.x, a.y + b.y);
    }

    public static Vector2f operator -(Vector2f a, Vector2f b)
    {
        return new Vector2f(a.x - b.x, a.y - b.y);
    }

    public static Vector2f operator /(Vector2f a, int b)
    {
        return new Vector2f(a.x / b, a.y / b);
    }

    public static Vector2f operator /(Vector2f a, Vector2f b)
    {
        return new Vector2f(a.x / b.x, a.y / b.y);
    }

    public static explicit operator Vector2f(Vector2i v)
    {
        return new Vector2f(v.x, v.y);
    }
}