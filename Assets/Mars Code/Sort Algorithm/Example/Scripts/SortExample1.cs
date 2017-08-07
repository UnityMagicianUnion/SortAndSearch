using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortExample1 : MonoBehaviour
{

    [Header("原始資料 UI"), SerializeField]
    protected Text sourceText;

    [Header("排序資料 UI"), SerializeField]
    protected Text sortedText;


    // Use this for initialization
    void Start()
    {
        var max = 30;
        var data = new int[max];

        for(int i = 0; i < max; i++)
            data[i] = Random.Range(0, 100);

        SetText(data, sourceText);

        // 在這裡可以實例化不同的排序演算法
        ISortAlgorithm sort = new QuickSort();
        sort.Sort(data);

        SetText(data, sortedText);
    }


    protected void SetText(int[] data, Text text)
    {
        var str = "";
        for(int i = 0; i < data.Length; i++)
        {
            if(i > 0)
            {
                str += ", ";
            }

            str += data[i].ToString();
        }

        text.text = str;
    }

}
