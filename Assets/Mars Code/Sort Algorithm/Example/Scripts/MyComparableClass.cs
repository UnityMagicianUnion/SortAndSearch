using System;
using UnityEngine;

[Serializable]
public class MyComparableClass : IComparable<MyComparableClass>
{

    public MyComparableClass(int num, int val)
    {
        id = num;
        value = val;
    }

    [Header("編號"), SerializeField]
    int id;

    [Header("數值"), SerializeField]
    public int value;

    // value 的屬性
    public int Value
    {
        get { return value; }
    }


    public int CompareTo(MyComparableClass other)
    {
        return value.CompareTo(other.value);
    }

}
