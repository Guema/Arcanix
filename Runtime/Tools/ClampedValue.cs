using UnityEngine;
using System;
using System.Numerics;
using NaughtyAttributes;


public struct ClampedValue<T> where T : IComparable<T>, IConvertible, IEquatable<T>, IFormattable
{
    T _value;
    T _min;
    T _max;

    public ClampedValue(T value, T min, T max)
    {
        _value = value;
        _min = min;
        _max = max;
    }

    public static implicit operator T(ClampedValue<T> operand)
    {
        return operand._value;
    }

    public static implicit operator ClampedValue<T>(T operand)
    {
        return new ClampedValue<T>(operand, default, operand);
    }

    public ClampedValue<T> SetMin(T val)
    {
        this._min = val;
        return this;
    }

    public ClampedValue<T> SetMax(T val)
    {
        this._max = val;
        return this;
    }



}
