/**************************************************
* 堆積排序法
* 
* 說明:
* 選擇排序法的改良演算法
* 將資料轉化為最大堆積樹，並且將首位元素與指標元素進行置換
* 指標元素一開始等同於資料的末位元素，之後指標會持續往左邊移動。
* 
* 最壞時間: O(nlog n)
* 平均時間: O(nlog n)
* 額外空間: O(1)
* 
* 排序方式: 不穩定排序
* 使用時機: n的數量大
**************************************************/


public class HeapSort : ISortAlgorithm
{

    public override void Sort(int[] data)
    {
        var n = data.Length;

        // 取得最後一個父節點 p，並且逐左將資料轉化為最大堆積樹
        for(var p = (n / 2) - 1; p >= 0; p--)
            MaxHeapify(data, p, n);

        // 指標 n 每經過一次迴圈會往左移動。
        for(n = data.Length - 1; n > 0; n--)
        {
            // 將首位元素與指標元素 n 置換。
            Swap(data, 0, n);

            // 首位元素產生了變化
            // 在不包含指標 n 的範圍內將資料執行最大堆積化
            MaxHeapify(data, 0, n);
        }
    }


    // 依據代入的索引取得左右子樹，並且進行資料的最大堆積化
    void MaxHeapify(int[] data, int node, int range)
    {
        // 預設最大值位於根結點
        int max = node;

        // 取得左右子樹的索引
        int leafL = node * 2 + 1;
        int leafR = node * 2 + 2;

        // 與左子樹比較取得最大值
        if(leafL < range && data[leafL] > data[max])
            max = leafL;

        // 與右子樹比較取得最大值
        if(leafR < range && data[leafR] > data[max])
            max = leafR;

        // 若子樹的值較大則與父節點置換，該子樹往下遞迴檢測
        // 所有遞迴完成之後資料將規範化為最大堆積樹
        if(max != node)
        {
            Swap(data, node, max);
            MaxHeapify(data, max, range);
        }
    }

}
