/**************************************************
* 希爾排序法
* 
* 介紹:
* 插入排序法的改良版
* 定義一個間隔，並且以間隔為依據進行插入排序
* 每經過一次迴圈，間隔的值會除以2
* 
* 最壞時間: O(n^s)
* 平均時間: O(nlog n)
* 額外空間: O(1)
* 
* 排序方式: 不穩定排序
* 使用時機: n的數量小，反轉排序
**************************************************/


public class ShellSort : ISortAlgorithm
{

    public override void Sort(int[] data)
    {
        var n = data.Length;
        var gap = n / 2;
        int i, j, temp;

        while(gap > 0)
        {
            for(i = gap; i < n; i++)
            {
                // 指派該次迴圈的插入元素 temp
                temp = data[i];

                // 設定指標 j 的起始位置
                j = i - gap;

                // 將插入元素與依據間隔逐左的指標元素比對
                // 若指標元素較大則指標元素往右移動
                while(j > -1 && data[j] > temp)
                {
                    data[j + gap] = data[j];
                    j -= gap;
                }

                data[j + gap] = temp;
            }

            // 間隔的範圍除以2
            gap /= 2;
        }
    }

}