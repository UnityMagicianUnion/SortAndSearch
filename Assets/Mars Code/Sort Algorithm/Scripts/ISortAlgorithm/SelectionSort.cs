﻿/**************************************************
* 選擇排序法
* 
* 說明:
* 由氣泡排序法演化而來
* 藉由只選擇最小元素來減少元素頻繁調換的次數
* 在每一輪的比對尋找最小元素，並且將範圍內的首位元素與最小元素置換。
* 每一輪比對只會置換一次，而範圍指標會隨著每一輪的結束往右移動。
* 
* 最壞時間: O(n²)
* 平均時間: O(n²)
* 額外空間: O(1)
* 
* 排序方式: 不穩定排序
* 使用時機: n的數量小
**************************************************/


public class SelectionSort : ISortAlgorithm
{

    public override void Sort(int[] data)
    {
        var n = data.Length;
        int i, j, min;

        for(i = 0; i < n - 1; i++)
        {
            // 指標 min 每經過一次迴圈會往右移動
            min = i;

            // 從指標的右邊逐一尋找最小的元素
            for(j = i + 1; j < n; j++)
            {
                if(data[j] < data[min])
                {
                    min = j;
                }
            }

            // 將指標元素與最小元素進行置換
            Swap(data, i, min);
        }
    }

}