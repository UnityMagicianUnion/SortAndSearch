using System;
using UnityEngine;

[Serializable]
public class MyComparableClass : IComparable<MyComparableClass>
{

    public MyComparableClass(int val)
    {
        value = val;
    }

    [Header("數值"), SerializeField]
    public int value;


    public int CompareTo(MyComparableClass other)
    {
        return value.CompareTo(other.value);
    }

}
