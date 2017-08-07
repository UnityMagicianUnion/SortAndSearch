/**************************************************
* 插入排序法
* 
* 說明:
* 將資料分成"已排序"與"未排序"兩個部分
* 並且將未排序的元素逐一與已排序的元素比對並排序到適當的位置
* 
* 最壞時間: O(n²)
* 平均時間: O(n²)
* 額外空間: O(1)
* 
* 排序方式: 穩定排序
* 使用時機: 已經大致排序過的對象
**************************************************/


public class InsertionSort : ISortAlgorithm
{

    public override void Sort(int[] data)
    {
        var n = data.Length;
        int i, j, temp;

        for(i = 1; i < n; i++)
        {
            // 指派該次迴圈的插入元素 temp
            temp = data[i];

            // 設定指標 j 的起始位置
            j = i - 1;

            // 將插入元素與逐左的指標元素比對
            // 若指標元素較大則指標元素往右移動
            while(j > -1 && data[j] > temp)
            {
                data[j + 1] = data[j];
                j--;
            }

            // 將插入元素放到指標的位置
            data[j + 1] = temp;
        }
    }

}