/**************************************************
* 快速排序法
* 
* 說明:
* 大部分情況下效率良好的排序法
* 每一輪將
* 
* 最壞時間: O(n²)
* 平均時間: O(nlog n)
* 額外空間: O(log n)~O(n)
* 
* 排序方式: 不穩定排序
* 使用時機: n的數量大
**************************************************/


public class QuickSort : ISortAlgorithm
{

    public override void Sort(int[] data)
    {
        Sort(data, 0, data.Length - 1);
    }


    void Sort(int[] data, int left, int right)
    {
        if(left >= right)
            return;

        var i = left - 1;   // 指派左側索引
        var j = right;      // 指派右側索引

        while(i < j)
        {
            // 往右尋找大於或等於基準的索引值
            while(++i < j && data[i] < data[right])
                ;

            // 往左尋找小於或等於基準的索引值
            while(--j > i && data[j] > data[right])
                ;

            // 交換元素並且繼續迴圈
            if(i < j)
                Swap(data, i, j);
        }

        Swap(data, i, right);       // 調換指標元素與 i 元素
        Sort(data, left, i - 1);    // 切割指標 i 左側物件的遞迴排序
        Sort(data, i + 1, right);   // 切割指標 i 右側物件的遞迴排序
    }

}
