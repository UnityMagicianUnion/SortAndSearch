using System.Collections.Generic;
using UnityEngine;
using ListSortAlgorithm; // 注意這邊的引用

public class SortExample2 : SortExample1
{

    [Header("資料串列"), SerializeField]
    List<MyComparableClass> data;

    // Use this for initialization
    void Start()
    {
        var max = 30;
        data = new List<MyComparableClass>();

        for(int i = 0; i < max; i++)
            data.Add(new MyComparableClass(i, Random.Range(0, 100)));

        SetText(GetNumberArray(data), sourceText);

        // 在這裡可以進行不同的排序
        data.ShellSort();

        SetText(GetNumberArray(data), sortedText);
    }


    int[] GetNumberArray(List<MyComparableClass> input)
    {
        var data = new int[input.Count];
        for(int i = 0; i < data.Length; i++)
        {
            data[i] = input[i].Value;
        }

        return data;
    }

}
